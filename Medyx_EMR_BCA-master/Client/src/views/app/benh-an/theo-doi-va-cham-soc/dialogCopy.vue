<template>
    <el-dialog :visible.sync="dialogVisible" width="500px" top="6vh">
        <template slot="title">
            <div class="px-3">
                <div style="font-size: 16px; font-weight: bold" class="mb-3">
                    Sao chép phiếu chăm sóc
                </div>
                <v-progress-linear color="primary" rounded value="100" height="2"></v-progress-linear>
            </div>
        </template>
        <el-form>
            <v-row>
                <v-col cols="6">
                    <el-form-item label="Ngày sao chép">
                        <el-select style="width:100%" size="small" v-model="form.ngaySaoChep">
                            <el-option v-for="(item, index) in select" :key="index" :value="item.ngayChamSoc">
                                {{item.stt}} -
                                {{item.ngayChamSoc}}</el-option>
                        </el-select>
                    </el-form-item>
                </v-col>
                <v-col cols="6">
                    <el-form-item label="Ngày chăm sóc">
                        <el-date-picker style="width:100%" size="small" v-model="form.ngayChamSoc" value-format="yyyy-MM-ddTHH:mm:ss"
                            format="dd/MM/yyyy HH:mm" type="datetime" placeholder="VD: 20/09/2022 14:00">
                        </el-date-picker>
                    </el-form-item>
                </v-col>
            </v-row>
        </el-form>
        <span slot="footer" class="pr-3 pb-4">
            <el-button size="small" @click="dialogVisible = false">Hủy</el-button>
            <el-button size="small" icon="el-icon-copy-document" type="primary" @click="saoChep()">Sao chép
            </el-button>
        </span>
    </el-dialog>
</template>
<script>
import { index, saoChepPhieuChamSoc } from "@/api/benh-an-phieu-cham-soc.js";
export default {
    data() {
        return {
            dialogVisible: false,
            form: {
                ngayChamSoc: null,
                ngaySaoChep: null,
            },
            select: []
        };
    },
    mounted() {
        this.getData()
    },
    methods: {
        showFormCopy() {
            this.dialogVisible = true;
            this.form = {
                ngayChamSoc: null,
                ngaySaoChep: null,
            }
        },
        async getData() {
            this.select = []
            const id = window.location.href.split("/").at(-1);
            let data = await index({ idba: id})
            data.data.forEach((item) => {
                // if (item.huy == false) {
                this.select.push({ stt: item.stt, ngayChamSoc: item.ngayChamSoc })
                // }
                // this.select.push({stt: item.stt, ngayChamSoc: new Date(item.ngayChamSoc).toLocaleDateString('en-TT')})
            })
        },
        async saoChep() {
            try {
                const id = window.location.href.split("/").at(-1);
                this.form.idba=id
                await saoChepPhieuChamSoc(this.form)
                this.$message({
                    message: "Thành công",
                    type: "success",
                });
                location.reload()
            } catch (error) {
                console.log(error);
                this.$message({
                    message: "Tải lên không thành công",
                    type: "error",
                });
            }
        }
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
