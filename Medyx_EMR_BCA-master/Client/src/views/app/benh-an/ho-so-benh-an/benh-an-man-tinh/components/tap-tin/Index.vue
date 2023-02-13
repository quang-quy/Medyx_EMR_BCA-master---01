<template>
  <div>
    <v-progress-linear
      color="indigo"
      rounded
      value="100"
      height="3"
    ></v-progress-linear>
    <div style="font-size: 18px; font-weight: bold" class="mt-4">
      <v-icon>mdi-attachment</v-icon>
      Tệp đính kèm
    </div>
    <div class="ma-5">
      <input
        name="file"
        ref="upload-image"
        style="display: none"
        type="file"
        multiple
        @change="handleUpload($event)"
      />
      <v-tooltip bottom v-if="tienTrinhUpload == 0 || tienTrinhUpload == 100">
        <template v-slot:activator="{ on, attrs }">
          <div
            class="box-file d-flex align-center justify-center flex-column"
            v-bind="attrs"
            v-on="on"
            @click="clickUpload"
            v-if="loading"
          >
            <v-icon large color="#8c939d"> mdi-upload </v-icon>
            <div style="font-size: 12px" class="mt-1">Tải lên tập tin</div>
          </div>
          <div
            class="box-file d-flex align-center justify-center mr-6 ml-2"
            v-bind="attrs"
            v-on="on"
            v-else
          >
            <v-progress-circular
              :rotate="-90"
              :size="50"
              :width="15"
              :value="value"
              color="primary"
            >
              {{ value }}
            </v-progress-circular>
          </div>
        </template>
        <span>Thêm tập tin</span>
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
          <el-tooltip  effect="dark" content="Tải xuống" placement="bottom">
            <i style="margin-right: 20px" 
                color="rgba(0, 0, 0, 0.54)" dark  
                @click="getDownloadFile(item.idba,item.stt,item.name)"
                class="el-icon-download">
              </i>
          </el-tooltip>
          <el-tooltip  effect="dark" content="Hủy" placement="bottom">
            <el-popconfirm title="Bạn có chắc muốn hủy không?"
              @confirm="removeFile(item)">
              <i slot="reference" size="medium"
                class="el-icon-close">
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
      <div
        style="border-bottom: 0.5px solid #d9d9d9; width: 100%; height: 0px"
      ></div>
    </div>
  </div>
</template>

<script>
import {
  uploadFile,
  getListFile,
  downloadFile,
} from "@/api/file-phi-cau-truc.js";
export default {
  data: () => ({
    tienTrinhUpload: 100,
    loading: true,
    value: 0,
    interval: {},
    files: null,
  }),
  mounted() {
    this.getDsFile();
  },
  methods: {
    clickUpload() {
      this.$refs["upload-image"].click();
    },
    loadingFile() {
      this.value = 0;
      this.interval = setInterval(() => {
        if (this.value === 100) {
          this.loading = true;
          this.getDsFile();
        }
        this.value += 10;
      }, 1000);
    },
    async getDsFile() {
      const id = window.location.href.split("/").at(-1);
      let data = await getListFile({
        idba: id,
        loaiTaiLieu: 1,
      });
      this.files = data.data;
      this.files.forEach((item) => {
        item.name = item.link.split("\\").at(-1);
      });
      this.$emit("get-total-files", this.files ? this.files.length : 0);
    },
    async handleUpload(e) {
      this.loading = false;
      this.loadingFile();
      let file = e.target.files;
      var isValidate = true;
      let data = new FormData();
      if (this.file) {
        return;
      }
      data.append("file", file[0]);
      data.append("idba", 1);
      data.append("loaiTaiLieu", 1);

      if (!isValidate) return;

      try {
        await uploadFile(data, (e) => {
          this.tienTrinhUpload = e;
        });
      } catch (error) {
        console.log(error);
      }
      this.$refs["upload-image"].value = null;
    },
        async getDownloadFile(idba, stt, name){
      try {
        let data = await downloadFile(idba, stt)
        var blob = new Blob([data]);
        saveAs.saveAs(blob, `${name}`);
      } catch (error) {
        console.log(error);
      }
    },
    async removeFile( item) {
      await deleteFile(item.idba, item.stt);
      this.getDsFile();
    },
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
