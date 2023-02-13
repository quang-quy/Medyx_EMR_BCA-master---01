<template>
  <div class="align-center pa-2" v-if="show">
    <v-progress-linear
      :active="!show"
      :indeterminate="!show"
      absolute
      bottom
      color="deep-purple accent-4"
    ></v-progress-linear>
    <div class="mt-1">
      <el-upload
        :file-list="fileList"
        actions="#"
        :auto-upload="false"
        :on-change="handleUpload"
        list-type="picture-card"
        :on-preview="handlePictureCardPreview"
        :on-remove="handleRemove"
        :disabled="!disableActions.import"
        accept=".jpg,.png,.svg,.pdf,.doc,.docx,.xlsx"
      >
        <i class="el-icon-plus"></i>
        <template #file="{ file }">
          <div class="pa-auto ma-auto text-center flex-grow-1 justify-center">
            <img
              v-if="file.name.includes('jpg') || file.name.includes('png')"
              class="el-upload-list__item-thumbnail imageFile"
              :src="file.url"
            />
            <img
              v-else
              class="el-upload-list__item-thumbnail imageFile"
              src="@/assets/app/file.png"
            />
          </div>
          <strong class="text-caption title font-weight-bold">{{
            handleName(file.name)
          }}</strong>
          <span class="el-upload-list__item-actions">
            <span
              class="el-upload-list__item-preview"
              @click="handlePictureCardPreview(file)"
            >
              <i class="el-icon-zoom-in"></i>
            </span>
            <span
              class="el-upload-list__item-delete"
              @click="handleDownload(file)"
              :disabled="!disableActions.export"
            >
              <i class="el-icon-download"></i>
            </span>
            <span
              class="el-upload-list__item-delete"
              @click="handleRemove(file)"
              :disabled="!disableActions.delete"
            >
              <i class="el-icon-delete"></i>
            </span>
          </span>
        </template>
      </el-upload>
      <el-dialog :visible.sync="dialogVisible" title="Chi tiết file">
        <div class="pb-2 flex-column">
          <div v-if="imageShow && imageShow.maBa">
            Mã bệnh án :
            <span class="blue--text font-weight-bold">
              {{ imageShow.maBa || null }}
            </span>
          </div>
          <div>
            Tên file :
            <span class="blue--text font-weight-bold">
              {{ imageShow.name || null }}
            </span>
          </div>
        </div>
        <v-card class="pa-2" outlined>
          <img
            width="100%"
            height="auto"
            :src="imageShow.url"
            :alt="imageShow.name"
          />
        </v-card>
      </el-dialog>
    </div>
  </div>
</template>
<script>
import {
  getListFile,
  uploadFile,
  deleteFile,
} from "@/api/benhAnToDieuTri/file-dinh-kem";
export default {
  data(vm) {
    return {
      imageShow: {
        url: null,
        name: null,
        maBa: null,
      },
      dialogVisible: false,
      disabled: false,
      fileList: [],
      show: false,
      loading: null,
      disableActions:{
        import: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TepDinhKem/import"
        ),
        export: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TepDinhKem/export"
        ),
        delete: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TepDinhKem/delete"
        ),
      }
    };
  },
  props: {
    idba: [Number, String],
    item: {
      type: Object,
      default: () => {},
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  watch: {
    item: {
      handler: function () {
        this.handleGetListFile();
      },
      deep: true,
    },
  },
  mounted() {
    this.handleGetListFile();
  },
  methods: {
    async handleGetListFile() {
      this.loading = this.$loading({
        lock: true,
        text: "Đang tải",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      this.show = false;
      this.fileList = [];
      const { data } = await getListFile({
        huy: false,
        idba: this.idba,
        loaiTaiLieu: this.item.maLoaiTaiLieu,
      });
      let tempt = data;
      this.fileList = tempt.map((x) => ({
        ...x,
        url: `${window.origin}/${x.link}`,
        name: x.link.slice(x.link.lastIndexOf("\\") + 2, x.link.length),
      }));
      this.loading.close();
      this.loading = null;
      this.show = true;
    },
    async handleRemove(file) {
      const res = await this.$confirm(
        "Xác nhận xóa file đính kèm " + file.name ? file.name : null,
        {
          title: "Xác nhận xóa file",
          buttonTrueText: "Đồng ý",
          buttonFalseText: "Hủy",
        }
      );
      if (res) {
        const response = await deleteFile(file.idba, file.stt);
        if (response.statusCode == 200) {
          this.handleGetListFile();
          this.$message.success("Xoá file thành công");
        }
      }
    },
    handlePictureCardPreview(file) {
      let { url, name, maBa } = file;
      this.imageShow = Object.assign(this.imageShow, { url, name, maBa });
      this.dialogVisible = true;
    },
    async handleDownload(file) {
      window.open(`${file.url}`, "_blank");
      return;
    },
    splliceNameFile(link) {
      return link.splice(link + 2, link.length);
    },
    async handleUpload(file) {
      var formData = new FormData();
      formData.append("file", file.raw);
      formData.append("loaiTaiLieu", this.item.maLoaiTaiLieu);
      formData.append("idba", this.idba);
      try {
        const resUpload = await uploadFile(formData);
        if (resUpload.statusCode == 200) {
          this.$message.success("Tải lên file thành công !");
          this.handleGetListFile()
        } else {
          this.$message.error("Lỗi : " + resUpload.error);
        }
      } catch (error) {
        this.$message.error("Lỗi : " + error);
      }
    },
    handleExtenImage(stringUrl) {
      return ["jpg", "png", "JPEG", "GIF "].includes(
        JSON.stringify(stringUrl).split(".").at(-1)
      );
    },
    handleName(name) {
      if (!name) return;
      let arr = name.split(".");
      arr[0] =
        arr[0].slice(0, 6) +
        "..." +
        arr[0].slice(arr[0].length - 6, arr[0].length);
      return arr.join(".");
    },
  },
};
</script>
<style scoped>
::v-deep .el-upload__input {
  display: none !important;
}
::v-deep .el-dialog__body {
  padding-top: 0px !important;
}
.title {
  position: absolute;
  bottom: 0px;
  left: 15px;
  justify-content: end;
  text-align: end;
  display: inline;
}
.imageFile {
  position: relative;
}
</style>
