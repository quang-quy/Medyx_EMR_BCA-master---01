<template>
    <app-wrapper :idba="id">
        <div class="ma-5">
            <div class="d-flex align-center mb-3">
                <v-btn fab small color="primary" depressed outlined @click="goBack()">
                    <v-icon dark> mdi-arrow-left </v-icon>
                </v-btn>
                <div style="font-size: 20px; font-weight: bold" class="ml-2">
                    Thông tin phẫu thuật thủ thuật
                </div>
            </div>
            <v-progress-linear color="primary" rounded value="100" height="2"></v-progress-linear>
            <br />
            <v-row>
                <v-col xl="3" lg="3" md="6" sm="6" xs="6" cols="6" v-for="item in loaiPhieus" :key="item.name">
                    <el-card shadow="hover" style="width: 100%" class="fill-height" >
                        <div class="pb-0">
                            <div class="d-flex flex-column justify-center align-center pb-4 cusor"  @click="xemPhieu(item.type)">
                                <div>
                                    <v-icon size="40">mdi-file-document</v-icon>
                                </div>
                                <div class="mt-3" style="font-size: 15px; font-weight: bold;">
                                    {{item.name}}
                                </div>
                            </div>
                            <hr />
                            <div class="d-flex pt-3">
                                <v-btn @click="printPhieu(item.type)" icon color="success"
                                    v-if="item.type !== 'CamKetPhauThuat'">
                                    <v-icon>mdi-printer</v-icon>
                                </v-btn>
                                <v-btn icon color="indigo" class="ml-2" @click="xemPhieu(item.type)">
                                    <v-icon>mdi-eye</v-icon>
                                </v-btn>
                            </div>
                        </div>
                    </el-card>
                </v-col>
            </v-row>
        </div>
    </app-wrapper>
</template>
  
<script>
import Crud from "@/components/crud/Index.vue";
import { index, detail, update, detroy } from "@/api/benh-an-phau-thuat";
export default {
    components: {
        Crud,
    },
    props: {
        id: {
            type: Number,
        },
        stt: {
            type: Number,
        },
    },

    data() {
        return {
            loaiPhieus: [
                {
                    name: 'Phiếu duyệt mổ',
                    type: 'PhieuDuyetMo'
                },
                {
                    name: 'Phiếu khám gây mê trước mổ',
                    type: 'PhieuKhamGayMe'
                },
                {
                    name: 'Phiếu phẫu thuật thủ thuật',
                    type: 'PhieuPhauThuat'
                },
                {
                    name: 'Giấy cam đoan chấp nhận phẫu thuật',
                    type: 'CamKetPhauThuat'
                }
            ],
        };
    },
    computed: {
        apiCrudFunctions() {
            return {
                index: (params) => index(this.id, params),
                detail,
                update,
                detroy,
            };
        },
    },
    methods: {
        xemPhieu(type) {
            window.location = `/HSBADS/${type}/${this.id}/${this.stt}`
        },
        goBack() {
            window.location = '/HSBADS/PhauThuatThuThuat/' + this.id
        },
        printPhieu(type) {
            if (type == 'PhieuDuyetMo') {
                window.open(
                    `${window.origin}/api/benh-an-phau-thuat-duyet-mo/${this.id}/print-ba-file/${this.stt}/benh-an-phau-thuat-duyet-mo.pdf`,
                    "_blank"
                );
                return
            }
            if (type == 'PhieuKhamGayMe') {
                window.open(
                    `${window.origin}/api/benh-an-phau-thuat-phieu-kham-gay-me-truoc-mo/${this.id}/print-ba-file/${this.stt}/phieu-kham-gay-me-truoc-mo.pdf`,
                    "_blank"
                );
                return
            }
            if (type == 'PhieuPhauThuat') {
                window.open(
                    `${window.origin}/api/benh-an-phau-thuat-phieu-pttt/${this.id}/print-ba-file/${this.stt}/phieu-phau-thuat-thu-thuat.pdf`,
                    "_blank"
                );
                return
            }
        }
    }
};
</script>
<style>
.el-button {
    padding: 0px !important;
}
</style>
<style scoped>
.cusor{
    cursor: pointer;
}
</style>
  