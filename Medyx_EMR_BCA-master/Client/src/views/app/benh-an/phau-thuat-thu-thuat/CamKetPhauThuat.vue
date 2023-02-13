<template>
  <app-wrapper :idba="id">
    <div class="ma-5">
      <div>
        <div class="d-flex justify-space-between align-flex-end mb-3">
          <div class="d-flex align-center mb-3">
            <v-btn class="mr-5" fab small color="primary" depressed outlined @click="goback()">
              <v-icon dark> mdi-arrow-left </v-icon>
            </v-btn>
            <div style="font-size: 20px; font-weight: bold">
              Giấy cam kết phẫu thuật
            </div>
          </div>
          <div>
            <div class="d-flex mb-3">
              <v-btn class="mr-5" color="primary" @click="submit('ruleForm')" small>
                <i class="el-icon-edit mr-2"></i>Cập nhật
              </v-btn>
            </div>
          </div>
        </div>
        <v-progress-linear color="primary" rounded value="100" height="2"></v-progress-linear>
        <br />
        <!-- <div class="ma-5"> -->
        <div class="ma-5" v-if="disableActions.import">
          <input name="file" ref="upload-image" style="display: none" type="file" multiple
            @change="handleUpload($event)" />
          <v-tooltip bottom v-if="tienTrinhUpload == 0 || tienTrinhUpload == 100">
            <template v-slot:activator="{ on, attrs }">
              <div class="box-file d-flex align-center justify-center flex-column" v-bind="attrs" v-on="on"
                @click="clickUpload" v-if="!loading">
                <v-icon large color="#8c939d"> mdi-upload </v-icon>
                <div style="font-size: 12px" class="mt-1">Tải lên tập tin</div>
              </div>
              <div class="box-file d-flex align-center justify-center mr-6 ml-2" v-bind="attrs" v-on="on" v-else>
                <v-progress-circular :rotate="-90" :size="50" :width="15" :value="tienTrinhUpload" color="primary">
                  {{ tienTrinhUpload }}
                </v-progress-circular>
              </div>
            </template>
            <span>{{ !loading ? "Thêm tập tin" : "Đang tải lên..." }}</span>
          </v-tooltip>
        </div>
        <div class="mb-2 pl-4">Danh sách file phi cấu trúc:</div>
        <div v-for="(item, index) in files" :key="index" class="pl-3">
          <div class="files" v-if="!item.huy">
            <div class="d-flex align-center">
              <div style="width: 20px">{{ index + 1 }}</div>
              <v-icon class="mr-3 ml-3">mdi-file</v-icon>
              {{ item.name }}
            </div>
            <div class="d-flex align-center">
              <el-tooltip effect="dark" content="Tải xuống" placement="bottom" v-if="disableActions.export">
                <i style="margin-right: 20px" color="rgba(0, 0, 0, 0.54)" dark
                  @click="getDownloadFile(item.idba,item.stt,item.name)" class="el-icon-download">
                </i>
              </el-tooltip>
              <el-tooltip effect="dark" content="Hủy" placement="bottom" v-if="disableActions.delete">
                <el-popconfirm title="Bạn có chắc muốn hủy không?" @confirm="removeFile(item)">
                  <i slot="reference" size="medium" class="el-icon-close">
                  </i>
                </el-popconfirm>
              </el-tooltip>
            </div>
          </div>
          <div class="files" v-else>
            <div class="d-flex align-center">
              <div style="width: 20px">{{ index + 1 }}</div>
              <v-icon class="mr-3 ml-3">mdi-file</v-icon>
              <div style="
            max-width: 250px;
            overflow: hidden;
            text-decoration: line-through;
          ">
                {{ item.name }}
              </div>
            </div>
            <div>
              <v-chip class="ma-2" color="red" text-color="white" small>
                Đã hủy
              </v-chip>
            </div>
          </div>
          <div style="border-bottom: 0.5px solid #d9d9d9; width: 100%; height: 0px"></div>
        </div>
      </div>
    </div>
  </app-wrapper>
</template>
<script>
import {
  uploadFile,
  getListFile,
  downloadFile,
  deleteFile,
} from "@/api/file-phi-cau-truc.js";
import { saveAs } from "file-saver";


export default {
  props: {
    id: {
      type: Number,
    },
    stt: {
      type: Number,
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  data: (vm) => ({
    disableActions: {
      import: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/CamKetPhauThuat/file/import"
      ),
      delete: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/CamKetPhauThuat/file/delete"
      ),
      export: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/CamKetPhauThuat/file/export"
      ),
    },
    tienTrinhUpload: 0,
    loading: false,
    files: null,
  }),
  mounted() {
    this.getDsFile();
  },
  methods: {
    clickUpload() {
      this.$refs["upload-image"].click();
    },
    async getDsFile() {
      let data = await getListFile({
        idba: this.id,
        loaiTaiLieu: 26,
        sttdv: this.stt
      });
      this.files = data.data;
      this.files.forEach((item) => {
        item.name = item.link.split("\\").at(-1);
      });
      this.$emit("get-total-files", this.files ? this.files.length : 0);
    },
    async handleUpload(e) {
      this.loading = true;
      this.tienTrinhUpload = 0;
      let file = e.target.files;
      var isValidate = true;
      let data = new FormData();
      if (this.file) {
        return;
      }
      data.append("file", file[0]);
      data.append("idba", this.id);
      data.append("loaiTaiLieu", 26);
      data.append("sttdv", this.stt);

      if (!isValidate) return;

      try {
        await uploadFile(data, (e) => {
          this.tienTrinhUpload = e;
          this.loading = false;
        });
        this.$message({
          message: "Tải lên thành công",
          type: "success",
        });
        this.getDsFile();
      } catch (error) {
        console.log(error);
        this.$message({
          message: "Tải lên không thành công",
          type: "error",
        });
      }
      this.$refs["upload-image"].value = null;
    },
    async getDownloadFile(idba, stt, name) {
      try {
        let data = await downloadFile(idba, stt)
        var blob = new Blob([data]);
        saveAs.saveAs(blob, `${name}`);
      } catch (error) {
        console.log(error);
      }
    },
    async removeFile(item) {
      await deleteFile(item.idba, item.stt);
      this.getDsFile();
    },
    goback() {
      window.location = `/HSBADS/LoaiPhieuPhauThuat/${this.id}/loai-phieu/${this.stt}`
    }
  },
};
</script>
    
<style scoped>
.files {
  padding: 10px;
  width: 100%;
  color: rgb(88, 88, 88);
  display: flex;
  align-items: center;
  justify-content: space-between;
  cursor: pointer;
}

.files:hover {
  background: rgba(231, 231, 231, 0.616);
  font-weight: 500;
}

.box-file {
  cursor: pointer;
  border: 2px dashed #d9d9d9;
  width: 100px;
  height: 100px;
}

.box-file:hover {
  border: 2px dashed #2874a6;
  width: 100px;
  height: 100px;
}
</style>