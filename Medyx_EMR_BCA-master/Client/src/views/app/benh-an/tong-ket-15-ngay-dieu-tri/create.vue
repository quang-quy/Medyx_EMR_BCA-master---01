<template>
    <el-dialog :visible.sync="dialogVisible" width="900px" top="6vh">
        <template slot="title">
            <div class="px-3">
                <div style="font-size: 16px; font-weight: bold" class="mb-3">
                    {{ 
                        edit
                        ? "Cập nhật phiếu sơ kết 15 ngày điều trị"
                        : "Thêm mới phiếu sơ kết 15 ngày điều trị"
                    }}
                </div>
                <v-progress-linear color="primary" rounded value="100" height="2"></v-progress-linear>
            </div>
        </template>
        <el-form :model="form" :rules="rules" ref="form" class="px-3">
            <v-row>
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Khoa" prop="sttKhoa">
                        <base-select-async v-model="form.sttKhoa" placeholder="Tìm kiếm theo stt khoa điều trị"
                            :label="(item) => `${item.stt} - ${item.khoa.tenKhoa}`" keyValue="stt" :apiFunc="getKhoa"
                            style="width: 100%" size="small"></base-select-async>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Từ ngày" prop="tuNgay">
                        <el-date-picker v-model="form.tuNgay" value-format="yyyy-MM-dd" placeholder="VD: 09/08/2022"
                            size="small" style="width: 100%"></el-date-picker>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Đến ngày" prop="denNgay">
                        <el-date-picker v-model="form.denNgay" value-format="yyyy-MM-dd" placeholder="VD: 09/08/2022"
                            size="small" style="width: 100%"></el-date-picker>
                    </el-form-item>
                </v-col>
                <v-col cols="12" class="padding-cols">
                    <el-form-item label="Diễn biến lâm sàng">
                        <el-input type="textarea" rows="2" v-model="form.dienBienLamSang" size="small"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="12" class="padding-cols">
                    <el-form-item label="Xét nghiệm cận lâm sàng">
                        <el-input type="textarea" rows="3" v-model="form.xnlamSang" size="small"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="12" class="padding-cols">
                    <el-form-item label="Quá trình điều trị">
                        <el-input type="textarea" rows="3" v-model="form.quaTrinhDt" size="small"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Đánh giá kết quả">
                        <el-input type="textarea" rows="2" v-model="form.danhGiaKq" placeholder="Tốt" size="small">
                        </el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="6" class="padding-cols">
                    <el-form-item label="Hướng điều trị">
                        <el-input type="textarea" rows="2" v-model="form.huongDt" size="small"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Ngày ký trưởng khoa">
                        <el-date-picker v-model="form.ngayKyTruongKhoa" value-format="yyyy-MM-dd"
                            placeholder="VD: 09/08/2022" size="small" style="width: 100%"></el-date-picker>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Trưởng khoa">
                        <base-select-async v-model="form.truongKhoa" placeholder="Tìm kiếm theo tên"
                            :label="(item) => `${item.hoTen}`" keyValue="maNv" :apiFunc="getNhanVien"
                            style="width: 100%" size="small"></base-select-async>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Ngày ký bác sĩ điều trị" prop="ngayKyBsdieuTri">
                        <el-date-picker v-model="form.ngayKyBsdieuTri" value-format=" yyyy-MM-dd"
                            placeholder="VD: 09/08/2022" size="small" style="width: 100%"></el-date-picker>
                    </el-form-item>
                </v-col>
                <v-col cols="3" class="padding-cols">
                    <el-form-item label="Bác sĩ điều trị">
                        <base-select-async v-model="form.bsDieuTri" placeholder="Tìm kiếm theo tên"
                            :label="(item) => `${item.hoTen}`" keyValue="maNv" :apiFunc="getNhanVien"
                            style="width: 100%" size="small"></base-select-async>
                    </el-form-item>
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
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";
import { addTongKetDieuTri } from "@/api/tong-ket-15-ngay.js";

export default {
    data() {
        return {
            dialogVisible: false,
            edit: true,
            form: {
                sttKhoa: null,
                tuNgay: null,
                denNgay: null,
                dienBienLamSang: null,
                xnlamSang: null,
                quaTrinhDt: null,
                danhGiaKq: null,
                huongDt: null,
                ngayKyTruongKhoa: null,
                ngayKyBsdieuTri: null,
                truongKhoa: null,
                bsDieuTri: null,
            },
            rules: {
                sttKhoa: [
                    { required: true, message: "Phải chọn khoa", trigger: "change" },
                ],
                tuNgay: [
                    { required: true, message: "Phải chọn ngày", trigger: "change" },
                ],
                denNgay: [
                    { required: true, message: "Phải chọn ngày", trigger: "change" },
                ],
                ngayKyBsdieuTri: [
                    { required: true, message: "Phải chọn ngày", trigger: "change" },
                ],
            },
        };
    },
    mounted() {
        this.getKhoaDieuTri()
    },
    methods: {
        showFormAdd() {
            this.form = {
                sttKhoa: null,
                tuNgay: null,
                denNgay: null,
                dienBienLamSang: null,
                xnlamSang: null,
                quaTrinhDt: null,
                danhGiaKq: null,
                huongDt: null,
                ngayKyTruongKhoa: null,
                ngayKyBsdieuTri: null,
                truongKhoa: null,
                bsDieuTri: null,
            };
            this.dialogVisible = true;
            this.edit = false;
        },
        printData() {
            console.log(this.form);
        },
        async getNhanVien(params) {
            return await apiNhanVien.index(params);
        },
        async getKhoa(params) {
            const id = window.location.href.split("/").at(-1);
            return await apiKhoaDT.index(id, params);
        },
        submit(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.addPhieuTongKet();
                } else {
                    console.log("error submit!!");
                    return false;
                }
            });
        },
        async addPhieuTongKet() {
            const id = window.location.href.split("/").at(-1);
            console.log(this.form);
            try {
                await addTongKetDieuTri(id, this.form);
                this.$message({
                    message: "Thêm mới thành công.",
                    type: "success",
                });
            } catch (error) {
                console.log(error);
                this.$message.error("Thất bại");
            }
            this.dialogVisible = false;
            location.reload()
        },
    },
};
</script>
<style>
.padding-cols {
    padding-bottom: 0px !important;
    padding-top: 0px !important;
}

label {
    margin-bottom: -8px !important;
}

.el-form-item {
    margin-bottom: 8px !important;
}

.el-form-item__label {
    font-size: 13px;
}

.el-form-item__content {
    line-height: 35px;
}
</style>
