<template>
    <el-dialog :visible.sync="dialogVisible" width="850px" top="4vh">
        <template slot="title">
            <div class="px-3">
                <div style="font-size: 16px; font-weight: bold" class="mb-2">
                    {{
                            edit
                                ? 'Cập nhật thông tin chẩn đoán hình ảnh'
                                : 'Thêm mới thông tin chẩn đoán hình ảnh'
                    }}
                </div>
                <v-progress-linear color="primary" rounded value="100" height="2"></v-progress-linear>
            </div>
        </template>
        <el-form :model="form" :rules="rules" ref="form">
            <v-row class="px-3 mt-0">
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Khoa" prop="sttKhoa">
                        <base-select-async v-model="form.sttKhoa" placeholder="Tìm kiếm theo stt khoa điều trị"
                            :label="(item) => `${item.stt} - ${item.khoa.tenKhoa}`" keyValue="stt"
                            :apiFunc="getKhoaDieuTri" style="width: 100%" size="small"></base-select-async>
                    </el-form-item>

                </v-col>
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Tên dịch vụ khám">
                        <base-select-async v-model="form.maDv" placeholder="Tìm kiếm"
                            :label="(item) => `${item.maDv} - ${item.tenDv}`" keyValue="maDv" :apiFunc="getDSDichVu"
                            style="width: 100%" size="small"></base-select-async>
                    </el-form-item>
                </v-col>
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Ngày chỉ định">
                        <el-date-picker type="datetime" value-format="yyyy-MM-ddTHH:mm:ss" format="dd/MM/yyyy HH:mm" v-model="form.ngayYlenh"
                            size="small" style="width:100%"></el-date-picker>
                    </el-form-item>
                </v-col>
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Bác sĩ chỉ định">
                        <base-select-async placeholder="Tìm kiếm theo tên" v-model="form.bSChiDinh"
                            :label="(item) => `${item.hoTen}`" keyValue="maNv" :apiFunc="getNhanVien"
                            style="width: 100%" size="small"></base-select-async>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Khoa phòng thực hiện" prop="maKhoa">
                        <base-select-async placeholder="Tìm kiếm theo mã khoa" v-model="form.maKhoaThucHien"
                            :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`" keyValue="maKhoa" :apiFunc="getKhoa"
                            style="width: 100%" size="small"></base-select-async>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Ngày tiếp nhận">
                        <el-date-picker value-format="yyyy-MM-ddTHH:mm:ss" format="dd/MM/yyyy" v-model="form.ngayTiepNhan"
                            placeholder="VD: 09/08/2022" size="small" style="width:100%"></el-date-picker>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Cấp cứu (dịch vụ cấp cứu)">
                        <br />
                        <el-checkbox v-model="form.capCuu" size="small">Cấp cứu</el-checkbox>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Số phiếu">
                        <el-input size="small" v-model="form.soPhieu"></el-input>
                    </el-form-item>
                </v-col>

                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Kỹ thuật">
                        <el-input type="textarea" rows="3" size="small" v-model="form.kyThuat"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Mô tả">
                        <el-input type="textarea" rows="3" size="small" v-model="form.moTa"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="12" class="padding-cols">
                    <el-form-item label="Kết luận" prop="ketLuan">
                        <el-input type="textarea" rows="2" size="small" v-model="form.ketLuan"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Bác sĩ chuyên khoa">
                        <base-select-async placeholder="Tìm kiếm theo tên" v-model="form.bSChuyenKhoa"
                            :label="(item) => `${item.hoTen}`" keyValue="maNv" :apiFunc="getNhanVien"
                            style="width: 100%" size="small"></base-select-async>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Ngày thực hiện">
                        <el-date-picker value-format="yyyy-MM-ddTHH:mm:ss" format="dd/MM/yyyy" v-model="form.ngayThucHien"
                            placeholder="VD: 09/08/2022" size="small" style="width:100%"></el-date-picker>
                    </el-form-item>
                </v-col>
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Đường link xem kết quả từ hệ thống PACS">
                        <el-input size="small" v-model="form.linkPacsLis"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="12">
                    <div style="height:200px">
                        <v-progress-linear color="primary" rounded value="100" height="1"></v-progress-linear>
                        <div style="font-size: 14px; font-weight: bold" class="mt-4">
                            <v-icon>mdi-attachment</v-icon>
                            Tệp đính kèm
                        </div>
                        <div style="display:flex; justify-content: space-between; align-items: center;">
                            <div class="ma-5">
                                <input name="file" ref="upload-image" style="display: none" type="file" multiple
                                    @change="handleUpload($event)" />
                                <v-tooltip bottom v-if="tienTrinhUpload == 0 || tienTrinhUpload == 100">
                                    <template v-slot:activator="{ on, attrs }">
                                        <div class="box-file d-flex align-center justify-center flex-column"
                                            v-bind="attrs" v-on="on" @click="clickUpload" v-if="!loading">
                                            <v-icon large color="#8c939d"> mdi-upload </v-icon>
                                            <div style="font-size: 12px" class="mt-1">Tải lên tập tin</div>
                                        </div>
                                        <div class="box-file d-flex align-center justify-center mr-6 ml-2"
                                            v-bind="attrs" v-on="on" v-else>
                                            <v-progress-circular :rotate="-90" :size="50" :width="15"
                                                :value="tienTrinhUpload" color="primary">
                                                {{ tienTrinhUpload }}
                                            </v-progress-circular>
                                        </div>
                                    </template>
                                    <span>{{ !loading ? "Thêm tập tin" : "Đang tải lên..." }}</span>
                                </v-tooltip>
                            </div>
                            <div style="width:720px">
                                <div class="mb-2 pl-2">Danh sách file phi cấu trúc:</div>
                                <div v-if="files && files.length > 0" style="height : 160px ; overflow-y: scroll;">
                                    <div v-for="(item, index) in files" :key="index" class="pl-3">
                                        <div class="files">
                                            <div class="d-flex align-center">
                                                <div style="width: 20px">{{ index + 1 }}</div>
                                                <v-icon class="mr-3 ml-3">mdi-file</v-icon>
                                                {{ item.name }}
                                            </div>
                                            <div class="d-flex">
                                                <v-tooltip bottom class="mr-4" v-if="edit">
                                                    <template v-slot:activator="{ on, attrs }">
                                                        <v-icon color="rgba(0, 0, 0, 0.54)" dark v-bind="attrs"
                                                            v-on="on"
                                                            @click="getDownloadFile(item.idba, item.stt, item.name)">
                                                            mdi-download
                                                        </v-icon>
                                                    </template>
                                                    <span>Tải xuống</span>
                                                </v-tooltip>
                                                <v-tooltip bottom class="mr-3 ml-3">
                                                    <template v-slot:activator="{ on, attrs }">
                                                        <v-icon color="rgba(0, 0, 0, 0.54)" dark v-bind="attrs"
                                                            @click="removeFile(index)" v-on="on" class="ml-3">
                                                            mdi-delete
                                                        </v-icon>
                                                    </template>
                                                    <span>Xóa</span>
                                                </v-tooltip>
                                            </div>
                                        </div>
                                        <div style="border-bottom: 0.5px solid #d9d9d9; width: 100%; height: 0px"></div>
                                    </div>
                                </div>
                                <div v-else style="height : 160px ;" class="d-flex align-center justify-center">
                                    <div>
                                        <v-icon large color="#8c939d" class="d-flex align-center justify-center mb-2">
                                            mdi-file-find</v-icon>
                                        <div style="font-size: 12px;">Không có tệp đính kèm</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </v-col>
            </v-row>
        </el-form>
        <span slot="footer" class="pr-3 pb-4">
            <el-button size="small" @click="dialogVisible = false">Hủy</el-button>
            <el-button size="small" icon="el-icon-plus" type="primary" @click="submit('form')">{{
                    edit ? "Cập nhật" : "Thêm mới"
            }}</el-button>
        </span>
    </el-dialog>
</template>
<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
import * as apiKhoa from "@/api/khoa.js";
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";
import { index, add } from "@/api/benh-an-can-lam-san.js";
import {
    uploadFile,
    getListFile,
    downloadFile,
} from "@/api/file-phi-cau-truc.js";
import { saveAs } from "file-saver";
import { getDichVu } from "@/api/danh-muc"
export default {
    data() {
        return {
            tienTrinhUpload: 0,
            loading: false,
            files: null,
            dialogVisible: false,
            edit: true,
            form: {
                sttKhoa: null,
                maDv: null,
                ngayYlenh: null,
                bSChiDinh: null,
                maKhoaThucHien: null,
                bSChuyenKhoa: null,
                ngayTiepNhan: null,
                kyThuat: null,
                ketLuan: null,
                ngayThucHien: null,
                moTa: null,
                linkPacsLis: null,
                capCuu: 0,
                soPhieu: null,
                loaiTaiLieu: 10
            },
            formDataBa: null,
            rules: {
                sttKhoa: [
                    { required: true, message: 'Phải chọn khoa', trigger: 'change' }
                ],
                maKhoaThucHien: [
                    { required: true, message: 'Phải chọn khoa', trigger: 'change' }
                ],
                ketLuan: [
                    { required: true, message: 'Mục phải điền', trigger: 'change' }
                ]
            }
        };
    },
    mounted() {
        this.getDsFile();
    },
    methods: {
        clickUpload() {
            this.$refs["upload-image"].click();
        },
        showFormAdd() {
            const id = window.location.href.split("/").at(-1);
            this.form = {
                idba: id,
                sttKhoa: null,
                maDv: null,
                ngayYlenh: null,
                bSChiDinh: null,
                maKhoaThucHien: null,
                bSChuyenKhoa: null,
                ngayTiepNhan: null,
                kyThuat: null,
                ketLuan: null,
                ngayThucHien: null,
                moTa: null,
                linkPacsLis: null,
                capCuu: 0,
                soPhieu: null,
                loaiTaiLieu: 10
            }
            this.files = null;
            this.dialogVisible = true;
            this.edit = false
        },
        async getNhanVien(params) {
            return await apiNhanVien.index(params);
        },
        async getKhoa(params) {
            return await apiKhoa.index(params);
        },
        async getKhoaDieuTri(params) {
            const id = window.location.href.split("/").at(-1);
            return await apiKhoaDT.index(id, params);
        },
        async getDSDichVu(params) {
            return await getDichVu({ ...params, MaChungLoai: 3 });
        },
        submit(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    if (this.edit) {

                    } else this.addData()
                }
                else {
                    console.log("error submit!!");
                    return false;
                }
            });
        },
        async addData() {
            try {
                this.addToFormData()
                await add(this.formDataBa)
                this.dialogVisible = false;
                // location.reload()
            } catch (error) {

            }
        },
        async getDsFile() {
            const id = window.location.href.split("/").at(-1);
            let data = await getListFile({
                idba: id,
                loaiTaiLieu: 10,
            });
            this.files = data.data;
            this.files.forEach((item) => {
                item.name = item.link.split("\\").at(-1);
            });
            this.$emit("get-total-files", this.files ? this.files.length : 0);
        },
        addToFormData() {
            if (!this.formDataBa) {
                this.formDataBa = new FormData();
            }
            this.form.capCuu = this.form.capCuu ? 1 : 0;
            for (let key in this.form) {
                this.formDataBa.append(key, this.form[key]);
            }
            if (this.files) {
                this.files.forEach(el => this.formDataBa.append('files', el))
            }
        },
        async handleUpload(e) {
            let files = e.target.files;
            if (!this.files) {
                this.files = []
            }
            for (let el of files) {
                this.files.push(el)
            }
            this.$refs["upload-image"].value = null;
        },
        removeFile(index) {
            if (!this.edit) {
                this.files.splice(index, 1)
            }
        },
        async getDownloadFile(idba, stt, name) {
            try {
                let data = await downloadFile(idba, stt)
                var blob = new Blob([data]);
                saveAs.saveAs(blob, `${name}`);
            } catch (error) {
                console.log(error);
            }
        }
    }
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
    width: 150px;
    height: 150px;
}

.box-file:hover {
    border: 2px dashed #2874a6;
    width: 150px;
    height: 150px;
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
</style>