<template>
    <div>
        <div style="font-size: 16px; font-weight: bold" class="mb-3">IV. TÌNH TRẠNG RA VIỆN</div>
        <el-form>
            <v-row>
                <v-col cols="4" class="padding-cols">
                    <el-form-item label="Kết quả điều trị">
                        <el-select v-model="form.kqdt" style="width:100%" size="small">
                            <el-option v-for="(item, index) in ketQuaDieuTri" :key="index" :value="item.ma" :label="item.ten"></el-option>
                        </el-select>
                    </el-form-item>
                </v-col>
                <v-col cols="4" class="padding-cols">
                    <el-form-item label="Giải phẫu bệnh (khi có sinh thiết)">
                        <el-select v-model="form.giaiPhauBenh" style="width:100%" size="small">
                            <el-option v-for="(item, index) in giaiPhauBenh" :key="index" :value="item.ma" :label="item.ten"></el-option>
                        </el-select>
                    </el-form-item>
                </v-col>
                <v-col cols="4" class="padding-cols">
                    <el-form-item label="Tình Trạng tử vong">
                        <el-select v-model="form.tinhTrangTuVong" style="width:100%" size="small">
                            <el-option v-for="item in tinhTrangTuVong" :key="item.ma" :value="item.ma" :label="item.ten"></el-option>
                        </el-select>
                    </el-form-item>
                </v-col>
                <v-col cols="4" class="padding-cols">
                    <el-form-item label="Nguyên nhân chính tử vong">
                        <el-input v-model="form.nguyenNhanTuVong" size="small"></el-input>
                    </el-form-item>
                </v-col>
                <v-col cols="4" class="padding-cols">
                    <el-form-item label="Khám nghiệm tử thi">
                        <el-radio-group v-model="form.khamNghiemTuThi" style="width:100%">
                            <el-radio :label="1">Có</el-radio>
                            <el-radio :label="2">Không</el-radio>
                        </el-radio-group>
                    </el-form-item>
                </v-col>
            </v-row>
        </el-form>
    </div>
</template>

<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
export default {
    props: ["benhAn"],
    data: () => ({
        form: {
            kqdt: null,
            giaiPhauBenh: null,
            ngayTuVong: null,
            tinhTrangTuVong: null,
            nguyenNhanTuVong: null,
            khamNghiemTuThi: null,
            maBenhGptuThi: null,
            ngayKy: null,
            giamDoc: null,
            truongKhoa: null,
        },
        ketQuaDieuTri: [
            {
                ma: '1',
                ten:'Khỏi',
            },
            {
                ma:'2',
                ten: 'Đỡ',
            },
            {
                ma:'3',
                ten:'Không thay đổi',
            },
            {
                ma:'4',
                ten:'Nặng hơn',
            },
            {
                ma:'5',
                ten:'Tử Vong'
            }
        ],
        giaiPhauBenh: [
            {
                ma: '0',
                ten: 'Bình thường',
            },
            {
                ma: '1',
                ten: 'Lành tính',
            },
            {
                ma: '2',
                ten: 'Nghi ngờ',
            },
            {
                ma: '3',
                ten: 'Ác tính',
            }
        ],
        nhanVien: [],
        chanDoan: [
            {
                maChanDoan: null,
                tenChanDoan: null,
            }
        ],
        tinhTrangTuVong: [
            {
                ma: '1',
                ten:'Do bệnh'
            },
            {
                ma: '2',
                ten: 'Do tai biến điều trị',
            },
            {
                ma: '3',
                ten: 'Khác',
            },
            {
                ma: '4',
                ten: 'Trong 24h vào viện',
            },
            {
                ma: '5',
                ten: 'Sau 24h vào viện'
            },
        ]
    }),
    watch: {
        benhAn: function (val) {
            for (let key in this.form) {
                this.form[key] = val[key]
            }
        },
        form: {
            handler(val) {
                this.$emit('get-tinhTrangRaVien', val)
            },
            deep: true
        }
    },
    mounted() {
        this.getNhanVien();
    },
    methods: {
        async getNhanVien(params) {
            return await apiNhanVien.index(params);
        },
    }
};
</script>

<style scoped>
.padding-cols {
    padding-bottom: 0px !important;
    padding-top: 0px !important;
}
</style>