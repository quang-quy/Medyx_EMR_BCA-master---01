<template>
  <app-wrapper :idba="id">
    <div class="ma-5">
      <div class="d-flex justify-space-between align-flex-end mb-3">
        <div class="d-flex">
          <v-btn fab small color="primary" depressed outlined @click="goBack()">
            <v-icon dark> mdi-arrow-left </v-icon>
          </v-btn>
          <div class="ml-3">
            <div style="font-size: 20px; font-weight: bold">
              {{
                edit
                  ? "Cập nhật thông tin chẩn đoán hình ảnh"
                  : "Thêm mới thông tin chẩn đoán hình ảnh"
              }}
            </div>
            <i
              >(<span style="color: red; font-weight: bold">*</span>) : Mục bắt
              buộc</i
            >
          </div>
        </div>
        <div v-if="!idhis">
          <div class="d-flex">
            <v-btn
              color="primary"
              @click="submit('form')"
              small
              :disabled="edit ? !disableActions.modify : false"
            >
              <v-icon small left> mdi-pencil </v-icon
              >{{ edit ? "Cập nhật" : "Thêm mới" }}
            </v-btn>
          </div>
        </div>
      </div>
      <v-progress-linear
        color="primary"
        rounded
        value="100"
        height="2"
      ></v-progress-linear>
      <br />
      <el-form :model="form" :rules="rules" ref="form" class="px-2">
        <v-row class="mt-0">
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Khoa">
              <base-select-async
                v-model="form.sttKhoa"
                :disabled="true"
                placeholder="Tìm kiếm theo stt khoa điều trị"
                :label="(item) => `${item.stt} - ${item.khoa.tenKhoa}`"
                keyValue="stt"
                :apiFunc="getKhoaDieuTri"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Tên dịch vụ khám">
              <base-select-async
                v-model="form.maDv"
                :disabled="true"
                placeholder="Tìm kiếm"
                :label="(item) => `${item.maDv} - ${item.tenDv}`"
                keyValue="maDv"
                :apiFunc="getDSDichVu"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Ngày chỉ định">
              <el-date-picker
                type="datetime"
                value-format="yyyy-MM-ddTHH:mm:ss"
                format="dd/MM/yyyy HH:mm"
                v-model="form.ngayYlenh"
                :disabled="true"
                size="small"
                style="width: 100%"
              ></el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ chỉ định">
              <base-select-async
                placeholder="Tìm kiếm theo tên"
                v-model="form.bsChiDinh"
                :disabled="true"
                :label="
                  (item) =>
                    `${item.maNv} - ${item.hoTen} - ${item.khoa.tenKhoa}`
                "
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Khoa phòng thực hiện">
              <base-select-async
                placeholder="Tìm kiếm theo mã khoa"
                v-model="form.maKhoaThucHien"
                :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`"
                keyValue="maKhoa"
                :apiFunc="getKhoa"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Ngày tiếp nhận">
              <el-date-picker
                type="datetime"
                value-format="yyyy-MM-ddTHH:mm:ss"
                format="dd/MM/yyyy HH:mm:ss"
                v-model="form.ngayTiepNhan"
                placeholder="VD: 09/08/2022 08:54:00"
                size="small"
                style="width: 100%"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Cấp cứu (dịch vụ cấp cứu)">
              <br />
              <el-checkbox
                v-model="form.capCuu"
                size="small"
                >Cấp cứu</el-checkbox
              >
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Số phiếu">
              <el-input size="small" v-model="form.soPhieu"></el-input>
            </el-form-item>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="8">
            <v-row>
              <v-col xl="3" lg="6" md="6" class="padding-cols">
                <el-form-item label="Bác sĩ chuyên khoa">
                  <base-select-async
                    placeholder="Tìm kiếm theo tên"
                    v-model="form.bSChuyenKhoa"
                    :label="
                      (item) =>
                        `${item.maNv} - ${item.hoTen} - ${item.khoa.tenKhoa}`
                    "
                    keyValue="maNv"
                    :apiFunc="getNhanVien"
                    style="width: 100%"
                    size="small"
                  ></base-select-async>
                </el-form-item>
              </v-col>
              <v-col xl="3" lg="6" md="6" class="padding-cols">
                <el-form-item label="Ngày thực hiện">
                  <el-date-picker
                    type="datetime"
                    value-format="yyyy-MM-ddTHH:mm:ss"
                    format="dd/MM/yyyy HH:mm:ss"
                    v-model="form.ngayKq"
                    placeholder="VD: 09/08/2022 08:45:00"
                    size="small"
                    style="width: 100%"
                  >
                  </el-date-picker>
                </el-form-item>
              </v-col>
              <v-col xl="6" lg="12" md="12" class="padding-cols">
                <el-form-item label="Đường link xem kết quả từ hệ thống PACS">
                  <el-input size="small" v-model="form.linkPacsLis"></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Kỹ thuật">
                  <el-input
                    type="textarea"
                    rows="3"
                    size="small"
                    v-model="form.kyThuat"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols mt-3">
                <label>Mô tả</label>
                <div class="mb-6 pb-6">
                  <EditerFill v-model="form.moTa" style="height: 400px" />
                </div>
              </v-col>
              <v-col cols="12" class="padding-cols mt-3 mb-4">
                <label
                  ><span style="color: red" class="mr-2">*</span>Kết luận</label
                >
                <el-form-item>
                  <div class="mb-6 pb-6">
                    <EditerFill v-model="form.ketLuan" style="height: 500px" />
                  </div>
                </el-form-item>
              </v-col>
            </v-row>
          </v-col>
          <v-col cols="4">
            <v-col cols="12" class="pt-4">
              <div
                style="height: 450px; border: 1px solid #d5dbdb"
                class="pa-3"
              >
                <div style="font-size: 14px; font-weight: bold">
                  <v-icon>mdi-attachment</v-icon>
                  Tệp đính kèm
                </div>
                <div>
                  <div class="mt-4">
                    <input
                      name="file"
                      ref="upload-image"
                      style="display: none"
                      type="file"
                      :multiple="!edit"
                      @change="handleUpload($event)"
                    />
                    <v-tooltip
                      bottom
                      v-if="tienTrinhUpload == 0 || tienTrinhUpload == 100"
                    >
                      <template v-slot:activator="{ on, attrs }">
                        <div
                          class="box-file d-flex align-center justify-center flex-column"
                          v-bind="attrs"
                          v-on="on"
                          @click="clickUpload"
                          v-if="!loading"
                        >
                          <v-icon large color="#8c939d"> mdi-upload </v-icon>
                          <div style="font-size: 12px" class="mt-1">
                            Tải lên tập tin
                          </div>
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
                            :value="tienTrinhUpload"
                            color="primary"
                          >
                            {{ tienTrinhUpload }}
                          </v-progress-circular>
                        </div>
                      </template>
                      <span>{{
                        !loading ? "Thêm tập tin" : "Đang tải lên..."
                      }}</span>
                    </v-tooltip>
                  </div>
                  <div>
                    <div class="mb-2 mt-4">Danh sách file phi cấu trúc:</div>
                    <div
                      v-if="files && files.length > 0"
                      style="height: 250px; overflow-y: scroll"
                    >
                      <div
                        v-for="(item, index) in files"
                        :key="index"
                        class="pl-3"
                      >
                        <div class="files" v-if="!item.huy">
                          <div class="d-flex align-center">
                            <div>{{ index + 1 }}</div>
                            <v-icon small class="mr-3 ml-3">mdi-file</v-icon>
                            <div
                              style="
                                width: 250px;
                                overflow: hidden;
                                font-size: 13px;
                              "
                            >
                              {{ item.name }}
                            </div>
                          </div>
                          <div class="d-flex align-center">
                            <v-tooltip bottom class="mr-4">
                              <template v-slot:activator="{ on, attrs }">
                                <i
                                  style="padding-right: 10px"
                                  color="rgba(0, 0, 0, 0.54)"
                                  dark
                                  v-bind="attrs"
                                  v-on="on"
                                  @click="
                                    getDownloadFile(
                                      item.idba,
                                      item.stt,
                                      item.name
                                    )
                                  "
                                  class="el-icon-download"
                                >
                                </i>
                              </template>
                              <span>Tải xuống</span>
                            </v-tooltip>
                            <v-tooltip bottom class="mr-4">
                              <template v-slot:activator="{ on, attrs }">
                                <template>
                                  <el-popconfirm
                                    title="Bạn có chắc muốn xóa không?"
                                    @confirm="removeFile(index, item)"
                                  >
                                    <i
                                      slot="reference"
                                      size="medium"
                                      class="el-icon-close"
                                    >
                                    </i>
                                  </el-popconfirm>
                                </template>
                              </template>
                              <span>Hủy</span>
                            </v-tooltip>
                          </div>
                        </div>
                        <div class="files d-flex" v-else>
                          <div class="d-flex align-center" style="flex: 1">
                            <div>{{ index + 1 }}</div>
                            <v-icon class="mr-3 ml-3" small>mdi-file</v-icon>
                            <div
                              style="
                                max-width: 250px;
                                overflow: hidden;
                                text-decoration: line-through;
                              "
                            >
                              {{ item.name }}
                            </div>
                          </div>
                          <div>
                            <v-chip
                              class="ma-2"
                              color="red"
                              text-color="white"
                              small
                            >
                              Đã hủy
                            </v-chip>
                          </div>
                        </div>
                        <div
                          style="
                            border-bottom: 0.5px solid #d9d9d9;
                            width: 100%;
                            height: 0px;
                          "
                        ></div>
                      </div>
                    </div>
                    <div
                      v-else
                      style="height: 160px"
                      class="d-flex align-center justify-center"
                    >
                      <div>
                        <v-icon
                          large
                          color="#8c939d"
                          class="d-flex align-center justify-center mb-2"
                        >
                          mdi-file-find</v-icon
                        >
                        <div style="font-size: 12px">Không có tệp đính kèm</div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </v-col>
            <v-row class="px-3 mt-4" v-if="edit">
              <v-col cols="12">
                <div class="d-flex justify-space-between">
                  <div class="ml-2" style="font-weight: bold">Hình ảnh</div>
                  <v-btn depressed small color="primary" @click="uploadImange">
                    Cập nhật hình ảnh
                    <v-icon right dark> mdi-image </v-icon>
                  </v-btn>
                </div>
              </v-col>
              <v-col cols="12">
                <div class="d-flex flex-wrap justify-space-around">
                  <div
                    v-for="item in 6"
                    style="text-align: center; min-width: 180px"
                    class="mt-3"
                    :key="`item-${item}`"
                  >
                    <el-upload
                      class="avatar-uploader"
                      :show-file-list="false"
                      :on-success="
                        (res, file) => handleImageSuccess(res, file, item)
                      "
                      :before-upload="beforeImageUpload"
                      action="#"
                    >
                      <div v-if="imagesBa[item]">
                        <img :src="imagesBa[item]" class="image-ba" />
                        <i
                          class="el-icon-delete"
                          @click="removeImage($event, item)"
                        ></i>
                      </div>
                      <i v-else class="el-icon-plus avatar-uploader-icon"></i>
                    </el-upload>
                  </div>
                </div>
              </v-col>
            </v-row>
          </v-col>
        </v-row>
      </el-form>
    </div>
  </app-wrapper>
</template>
<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
import * as apiKhoa from "@/api/khoa.js";
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";
import {
  add,
  detailBaCls,
  update,
  getImangeBaCls,
  uploadImangeBaCls,
} from "@/api/benh-an-can-lam-san.js";

import {
  uploadFile,
  getListFile,
  downloadFile,
  deleteFile,
} from "@/api/file-phi-cau-truc.js";
import { saveAs } from "file-saver";
import { getDichVu } from "@/api/danh-muc";
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
      modify: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/ChuanDoanHinhAnh/export"
      ),
    },
    visible: false,
    tienTrinhUpload: 0,
    loading: false,
    files: null,
    edit: true,
    form: {
      sttKhoa: null,
      maDv: null,
      ngayYlenh: null,
      bsChiDinh: null,
      maKhoaThucHien: null,
      bSChuyenKhoa: null,
      ngayTiepNhan: null,
      kyThuat: null,
      ketLuan: null,
      ngayKq: null,
      moTa: null,
      linkPacsLis: null,
      capCuu: 0,
      soPhieu: null,
      loaiTaiLieu: 10,
    },
    dialogVisible: false,
    formDataBa: null,
    rules: {
      // sttKhoa: [
      //   { required: true, message: "Phải chọn khoa", trigger: "change" },
      // ],
      // maKhoaThucHien: [
      //   { required: true, message: "Phải chọn khoa", trigger: "change" },
      // ],
      // ketLuan: [
      //   { required: true, message: "Mục phải điền", trigger: "change" },
      // ],
    },
    imagesBa: {
      1: null,
      2: null,
      3: null,
      4: null,
      5: null,
      6: null,
    },
    fileImages: null,
    idhis: null,
  }),
  created() {
    this.edit = this.stt ? true : false;
  },
  mounted() {
    if (this.edit) {
      this.getDsFile();
      this.getImange();
    }
    this.getData();
  },
  methods: {
    goBack() {
      window.location = "/HSBADS/ThongTinChanDoanHinhAnh/" + this.id;
    },
    clickUpload() {
      this.$refs["upload-image"].click();
    },
    clickUploadImage(item) {
      this.$refs[`upload-image-${item}`][0].click();
    },
    resetForm() {
      this.form = {
        idba: this.id,
        sttKhoa: null,
        maDv: null,
        ngayYlenh: null,
        bsChiDinh: null,
        maKhoaThucHien: null,
        bSChuyenKhoa: null,
        ngayTiepNhan: null,
        kyThuat: null,
        ketLuan: null,
        ngayKq: null,
        moTa: null,
        linkPacsLis: null,
        capCuu: 0,
        soPhieu: null,
        loaiTaiLieu: 10,
      };
    },
    async getNhanVien(params) {
      return await apiNhanVien.index(params);
    },
    async getKhoa(params) {
      return await apiKhoa.index(params);
    },
    async getKhoaDieuTri(params) {
      return await apiKhoaDT.index(this.id, params);
    },
    async getDSDichVu(params) {
      return await getDichVu({ ...params, MaChungLoai: 3 });
    },
    submit(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          if (this.edit) {
            this.updateData();
          } else this.addData();
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    async updateData() {
      try {
        this.form.capCuu = this.form.capCuu === true ? 1 : 2;
        await update(this.id, this.stt, this.form);
        setTimeout(() => {
          // window.location.reload();
          this.getData();
        }, 1000);
        this.$message({
          message: "Cập nhật thành công.",
          type: "success",
        });
      } catch {
        console.log(error);
        this.$message({
          message: "Cập nhật không thành công",
          type: "error",
        });
      }
    },
    async addData() {
      try {
        this.addToFormData();
        await add(this.formDataBa);
        this.resetForm();
        this.$message({
          message: "Thêm mới thành công.",
          type: "success",
        });
      } catch (error) {}
    },
    async getDsFile() {
      let data = await getListFile({
        idba: this.id,
        loaiTaiLieu: 10,
        sttDv: this.stt,
      });
      this.files = data.data;
      this.files.forEach((item) => {
        item.name = item.link.split("\\").at(-1);
      });
    },
    addToFormData() {
      this.formDataBa = new FormData();
      this.form.capCuu = this.form.capCuu ? 1 : 0;
      this.form.idba = this.id;
      for (let key in this.form) {
        this.formDataBa.append(key, this.form[key] ? this.form[key] : "");
      }
      if (this.files) {
        this.files.forEach((el) => this.formDataBa.append("files[]", el));
      }
    },
    async handleUpload(e) {
      this.tienTrinhUpload = 0;
      var isValidate = true;
      let files = e.target.files;
      if (this.edit) {
        this.loading = true;
        var isValidate = true;
        let data = new FormData();
        if (this.file) {
          return;
        }
        data.append("file", files[0]);
        data.append("idba", this.id);
        data.append("loaiTaiLieu", 10);
        data.append("sttDv", this.stt);
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
      } else {
        this.files = this.files ? this.files : [];
        for (let el of files) {
          this.files.push(el);
        }
      }
      this.$refs["upload-image"].value = null;
    },
    async removeFile(index, item) {
      if (!this.edit) {
        this.files.splice(index, 1);
      } else {
        await deleteFile(item.idba, item.stt);
        this.getDsFile();
      }
    },
    async getDownloadFile(idba, stt, name) {
      try {
        let data = await downloadFile(idba, stt);
        var blob = new Blob([data]);
        saveAs.saveAs(blob, `${name}`);
      } catch (error) {
        console.log(error);
      }
    },
    async getData() {
      if (this.stt) {
        let data = await detailBaCls(this.id, this.stt);
        this.idhis = data.data.idhis;
        for (let key in this.form) {
          if (data && data.data && data.data.hasOwnProperty(key)) {
            this.form[key] = data.data[key];
          }
          if (data && data.data && data.data.benhAnClsKq.hasOwnProperty(key)) {
            this.form[key] = data.data.benhAnClsKq[key];
          }
        }
        
        this.$set(this.form, "maDv", data.data.maDv);
        this.$set(this.form, "sttKhoa", +data.data.khoaDieuTri.stt);
        this.$set(this.form, "bsChiDinh", data.data.bsChiDinh.maNv);
        this.$set(this.form, "capCuu", data.data.capcuu === 1 ? true : false);
        this.$set(this.form, "bSChuyenKhoa", data.data.benhAnClsKq.bschuyenKhoa.maNv);
        // this.form.maDv = data.data.maDv;
        // this.form.sttKhoa = +data.data.khoaDieuTri.stt;
        // this.form.bsChiDinh = data.data.bsChiDinh.maNv;
        // this.form.capCuu = Number(data.data.capcuu);
        // this.form.bSChuyenKhoa = data.data.benhAnClsKq.bschuyenKhoa.maNv;
      }
    },
    handleImageSuccess(res, file, item) {
      this.imagesBa[item] = URL.createObjectURL(file.raw);
      if (!this.fileImages || this.fileImages == null) {
        this.fileImages = new FormData();
      }
      this.fileImages.append("Image" + item, file.raw);
    },
    async uploadImange() {
      try {
        await uploadImangeBaCls(this.id, this.stt, this.fileImages);
        this.$message({
          message: "Cập nhật hình ảnh thành công.",
          type: "success",
        });
      } catch (error) {
        console.log(error);
      }
    },
    async getImange() {
      try {
        let data = await getImangeBaCls(this.id, this.stt);
        const imageData = data.data;
        this.imagesBa[1] = imageData.pathImage1 ? imageData.pathImage1 : null;
        this.imagesBa[2] = imageData.pathImage2 ? imageData.pathImage2 : null;
        this.imagesBa[3] = imageData.pathImage3 ? imageData.pathImage3 : null;
        this.imagesBa[4] = imageData.pathImage4 ? imageData.pathImage4 : null;
        this.imagesBa[5] = imageData.pathImage5 ? imageData.pathImage4 : null;
        this.imagesBa[6] = imageData.pathImage6 ? imageData.pathImage4 : null;

        this.fileImages = new FormData();
        for (let key in imageData) {
          this.imagesBa[key] = imageData[key];
          this.fileImages.append(key, imageData[key]);
        }
      } catch (error) {
        console.log(error);
      }
    },
    beforeImageUpload(file) {
      var dinhDangChoPhep = ["image/jpeg", "image/png"];
      const isJPG = dinhDangChoPhep.includes(file.type);
      const isLt2M = file.size / 1024 / 1024 < 10;

      if (!isJPG) {
        this.$message.error("Định dạng không hợp lệ!");
      }
      if (!isLt2M) {
        this.$message.error("File ảnh không được lớn hơn 10MB!");
      }
      return isJPG && isLt2M;
    },
    removeImage(event, index) {
      event.stopPropagation();
      this.imagesBa[index] = null;
      this.fileImages.delete("Image" + index);
      this.fileImages.delete("pathImage" + index);
      this.fileImages.append("pathImage" + index, null);
      this.fileImages.append("Image" + index, null);
    },
  },
};
</script>
<style>
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
  width: 100%;
  height: 90px;
}

.box-file:hover {
  border: 2px dashed #2874a6;
}

.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}

label {
  margin-bottom: -8px !important;
}

.el-form-item {
  margin-bottom: 0px !important;
}

.el-form-item__label {
  font-size: 13px;
}

.el-form-item__content {
  line-height: 35px;
}

.el-dialog__body {
  padding-top: 0px;
}

.avatar-uploader .el-upload {
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}

.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}

.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  width: 178px;
  height: 178px;
  line-height: 178px;
  text-align: center;
}

.image-ba {
  width: 178px;
  height: 178px;
  display: block;
}

.el-upload__input {
  display: none !important;
}
</style>
