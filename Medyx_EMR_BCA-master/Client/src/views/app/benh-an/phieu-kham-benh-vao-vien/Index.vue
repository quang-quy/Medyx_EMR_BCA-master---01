<template>
  <app-wrapper :idba="id">
    <div class="ma-5 thong-tin-benh-an-chung">
      <div class="d-flex justify-space-between align-flex-end mb-3">
        <div>
          <div style="font-size: 20px; font-weight: bold">
            Phiếu khám bệnh vào viện
          </div>
          <div>
            <i>(<span class="red-dot">*</span>) : Mục bắt buộc</i>
          </div>
        </div>
        <div>
          <div class="d-flex">
            <v-btn color="primary" class="mr-4" small :loading="loadingPrint" link :href="printHref" target="_blank"
              :disabled="!disableActions.printPhieuKham">
              <v-icon small left> mdi-printer </v-icon>In phiếu
            </v-btn>
            <v-btn color="primary" @click="submit('form')" small :disabled="!disableActions.modify">
              <v-icon small left> mdi-pencil </v-icon>Cập nhật
            </v-btn>
          </div>
        </div>
      </div>
      <v-progress-linear v-if="loadingForm" indeterminate color="teal"></v-progress-linear>

      <v-progress-linear v-else color="primary" rounded value="100" height="2"></v-progress-linear>
      <br />
      <el-form ref="form" :rules="rules" :model="form">
        <v-row class="mt-4">
          <v-col xl="2" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item label="Thời gian khám" prop="ngayKham">
              <el-date-picker size="small" style="width: 100%" v-model="form.ngayKham" type="datetime"
                :picker-options="pickerOptions" format="dd/MM/yyyy HH:mm" value-format="yyyy-MM-ddTHH:mm:ss">
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item>
              <label style="font-size: 12px">Mã bệnh chẩn đoán nơi giới thiệu</label>
              <base-select-async v-model="form.maBenhNoiChuyenDen" :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                keyValue="maBenh" placeholder="Mã bệnh nơi giới thiệu" :apiFunc="getChanDoanBenh">
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item label="Tên bệnh chẩn đoán nơi giới thiệu">
              <base-select-async v-model="form.maBenhNoiChuyenDen" label="tenBenh" keyValue="maBenh" disabled
                :apiFunc="getChanDoanBenh" placeholder="Tên bệnh nơi giới thiệu">
              </base-select-async>
            </el-form-item>
          </v-col>

          <v-col xl="2" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item label="Mã bệnh Chẩn đoán vào viện" prop="chanDoanKkb">
              <base-select-async v-model="form.chanDoanKkb" :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                keyValue="maBenh" placeholder="Mã bệnh chẩn đoán vào viện" :apiFunc="getChanDoanBenh">
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item label="Tên chẩn đoán vào viện">
              <base-select-async v-model="form.chanDoanKkb" placeholder="Tên bệnh chẩn đoán vào viện" label="tenBenh"
                disabled keyValue="maBenh" :apiFunc="getChanDoanBenh">
              </base-select-async>
            </el-form-item>
          </v-col>

          <v-col xl="2" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item label="Đã xử lý">
              <el-input v-model="form.daXuLy" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item label="Cho điều trị tại khoa">
              <base-select-async v-model="form.maKhoaVv" :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`"
                keyValue="maKhoa" :apiFunc="getSelectKhoa">
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item label="Buồng khám bệnh">
              <base-select-async v-model="form.maKhoaKham" :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`"
                keyValue="maKhoa" :apiFunc="getSelectKhoa">
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" sm="12" class="padding-cols">
            <el-form-item label="Bác sĩ">
              <base-select-async v-model="form.bskham" :label="
                (item) =>
                  `${item.maNv} - ${item.hoTen} - ${item.khoa.tenKhoa}`
              " keyValue="maNv" :apiFunc="getDanhDSNhanVien">
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" sm="12" class="padding-cols">
            <v-row class="mt-0">
              <v-col xl="6" lg="6" md="6" sm="6" class="padding-cols">
                <el-form-item label="Mạch" prop="mach">
                  <el-input v-model="form.mach" type="number" size="small" style="width: 100%">
                  </el-input>
                </el-form-item>
              </v-col>
              <v-col xl="6" lg="6" md="6" sm="6" class="padding-cols">
                <el-form-item label="Nhiệt độ" prop="nhietDo">
                  <el-input v-model="form.nhietDo" type="number" size="small" style="width: 100%">
                  </el-input>
                </el-form-item>
              </v-col>
            </v-row>
          </v-col>
          <v-col xl="3" lg="4" md="4" sm="12" class="padding-cols">
            <v-row class="mt-0">
              <v-col xl="6" lg="6" md="6" sm="6" class="padding-cols">
                <el-form-item label="Huyết áp">
                  <el-input v-model="form.huyetAp" size="small" style="width: 100%"></el-input>
                </el-form-item>
              </v-col>
              <v-col xl="6" lg="6" md="6" sm="6" class="padding-cols">
                <el-form-item label="Nhịp thở" prop="nhipTho">
                  <el-input v-model="form.nhipTho" type="number" size="small" style="width: 100%">
                  </el-input>
                </el-form-item>
              </v-col>
            </v-row>
          </v-col>
          <!--row 1-->
          <v-col xl="2" lg="4" md="4" sm="6" class="padding-cols">
            <el-form-item label="Ngày ký">
              <el-date-picker size="small" v-model="form.ngayKy" format="dd/MM/yyyy HH:mm"
                value-format="yyyy-MM-ddTHH:mm:ss" type="datetime" style="width: 100%" :picker-options="pickerOptions">
              </el-date-picker>
            </el-form-item>
          </v-col>
          <!--2-->
          <v-col xl="10" lg="12" md="12" sm="12" class="padding-cols">
            <el-form-item label="Lý do vào viện">
              <el-input v-model="form.lyDoVv" type="textarea" :rows="1" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" sm="12" class="padding-cols">
            <el-form-item label="Các bộ phận">
              <el-input size="small" type="textarea" :rows="2" v-model="form.cacBoPhan"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" sm="12" class="padding-cols">
            <el-form-item label="Tiền sử bản thân">
              <el-input v-model="form.tienSuBanThan" type="textarea" :rows="2"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" sm="12" class="padding-cols">
            <el-form-item label="Tiền sử gia đình">
              <el-input v-model="form.tienSuGiaDinh" type="textarea" :rows="4"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" sm="12" class="padding-cols">
            <el-form-item label="Quá trình bệnh lý">
              <el-input v-model="form.quaTrinhBenhLy" type="textarea" :rows="4"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" sm="12" class="padding-cols">
            <el-form-item label="Tóm tắt kết quả lâm sàng">
              <el-input v-model="form.tomTatKqcls" type="textarea" :rows="5"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" sm="12" class="padding-cols">
            <el-form-item label="Khám toàn thân">
              <el-input v-model="form.khamToanThan" type="textarea" :rows="5"></el-input>
            </el-form-item>
          </v-col>

          <v-col xl="12" lg="12" md="12" sm="12" class="padding-cols">
            <el-form-item label="Chú ý">
              <el-input v-model="form.chuY" type="textarea" :rows="2"></el-input>
            </el-form-item>
          </v-col>
          <!---->
          <v-col cols="12" sm="12">
            <div class="justify-center">
              <Crud :fields="fields" :apiCrudFunctions="apiCrudFunctions" :apiCategoryFunctions="apiCategoryFunctions"
                :actions="actions" :disableActions="disableActions" :wrapper="false" :fileComponent="dialogComponent"
                :headerComponent="headerComponent" :permission="permission" primaryKey="stt.sttkhoa" label-width="100px"
                title="Phiếu dinh dưỡng" tableHeight="400px" />
            </div>
          </v-col>
          <phieuDinhDuongDialog ref="phieuDinhDuong" @get-phieu="getDanhSachPhieuDanhGia"></phieuDinhDuongDialog>
        </v-row>
      </el-form>
    </div>
  </app-wrapper>
</template>
<script>
import phieuDinhDuongDialog from "./phieudinhduong_dialog.vue";
import Crud from "@/components/crud/Index.vue";
import {
  indexAdmin,
  index,
  store,
  update,
  destroy,
  print,
  dsKhoaDieuTri,
} from "@/api/phieu-kham-dinh-duong";
import { saveAs } from "file-saver";
import {
  getNhanVien,
  getBuongKham,
  getBenhTat,
  getKhoa,
  getChiTietPhieuKhamVaoVien,
  updatePhieuKhamVaoVien,
  downloadFile,
} from "@/api/phieu-kham-benh-vao-vien";
import { formatDatetime, formatDate } from "@/utils/formatters";
import phieuKhamDinhDuongSelection from "./phieuKhamDinhDuongSelection.vue";
import dialog from "./dialogDetail.vue";
import Header from "./components/Header.vue";
export default {
  props: {
    permission: {
      type: Array,
      default: () => [],
    },
    id: {
      type: [Number, String],
      required: true,
    },
  },
  components: {
    phieuDinhDuongDialog,
    Crud,
  },
  data(vm) {
    var checkMach = (rule, value, callback) => {
      // if (!value) {
      //   return callback(new Error("Phải nhập mạch"));
      // }
      setTimeout(() => {
        if (value && (value > 300 || value < 0)) {
          callback(new Error("Giá trị nhập lớn hơn 0 và nhỏ hơn 300"));
        } else {
          callback();
        }
      }, 1000);
    };
    var checkNhietDo = (rule, value, callback) => {
      // if (!value) {
      //   return callback(new Error("Phải nhập mạch"));
      // }
      setTimeout(() => {
        if (value && (value > 42 || value < 34)) {
          callback(new Error("Nhiệt độ phải lớn hơn 34 hoặc nhỏ hơn 42"));
        } else {
          callback();
        }
      }, 1000);
    };
    var checkNhipTho = (rule, value, callback) => {
      // if (!value) {
      //   return callback(new Error("Phải nhập mạch"));
      // }
      setTimeout(() => {
        if (value && (value > 100 || value < 0)) {
          callback(new Error("Nhịp thở phải nằm trong khoảng từ 0-100"));
        } else {
          callback();
        }
      }, 1000);
    };
    return {
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
      pickerOptions: {
        disabledDate(time) {
          return time.getTime() > Date.now();
        },
      },
      loadingPrint: false,
      search: "",
      valid: true,
      showConfirm: false,
      soBuongSelect:[],
      form: {
        maKhoaKham: null,
        bskham: null,
        cacBoPhan: null,
        chanDoanKkb: null,
        chuY: null,
        daXuLy: null,
        huy: null,
        huyetAp: null,
        khamToanThan: null,
        lyDoVv: null,
        maBa: null,
        maBenhNoiChuyenDen: null,
        maBn: null,
        maKhoaVv: null,
        mach: null,
        ngayKham: null,
        ngayKy: null,
        nhietDo: null,
        nhipTho: null,
        quaTrinhBenhLy: null,
        tienSuBanThan: null,
        tienSuGiaDinh: null,
        tomTatKqcls: null,
      },
      rules: {
        buong: [
          {
            required: true,
            message: "Buồng khám bệnh không thể bỏ trống",
            trigger: "change",
          },
        ],
        maBenhNoiChuyenDen: [
          {
            required: true,
            message: "Chọn ít nhất một chẩn đoán",
            trigger: "change",
          },
        ],
        chanDoanKkb: [
          {
            required: true,
            message: "Chọn ít nhất một chẩn đoán",
            trigger: "change",
          },
        ],
        ngayKham: [
          {
            required: true,
            message: "Thời gian khám không thể bỏ trống",
            trigger: "blur",
          },
        ],
        // lyDoVv: [
        //   {
        //     required: true,
        //     message: "Lý do vào viện không thể bỏ trống",
        //     trigger: "blur",
        //   },
        // ],
        mach: [
          {
            validator: checkMach,
            trigger: "blur",
          },
        ],
        // huyetAp: [
        //   {
        //     required: true,
        //     trigger: "blur",
        //   },
        // ],
        nhietDo: [
          {
            validator: checkNhietDo,
            trigger: "blur",
          },
        ],
        nhipTho: [
          {
            validator: checkNhipTho,
            trigger: "blur",
          },
        ],
      },
      loadingListBenh: false,
      phieu_kham_benh: false,
      phieukhams: [],
      i: 0,

      dialogComponent: dialog,
      disableActions: {
        delete: (item) =>
          item.huy ||
          !vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/phieudinhduong/delete"
          ),
        print: (item) =>
          item.huy ||
          !vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/phieudinhduong/export"
          ),
        printPhieuKham: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/phieukhambenhvaovien/export"
        ),
        modify: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/phieukhambenhvaovien/modify"
        ),
      },
      fields: [
        {
          text: "Khoa",
          value: "khoaDieuTri.khoa.tenKhoa",
          searchValue: "tenKhoa",
          showable: true,
          filterable: false,
          searchValue: "KhoaDieuTri",
          filterValue: "KhoaDieuTri",
          type: "text",
          width: 250,
          sortable: true,
        },
        {
          text: "Ngày đánh giá",
          sortable: true,
          showable: true,
          value: "ngayDg",
          type: "date",
          filterable: false,
          filterValue: "ngayDg",
          sortable: true,
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
        },
        {
          text: "Hủy",
          type: "text",
          showable: true,
          filterable: false,
          value: "huy",
          searchValue: "huy",
          width: 100,
          type: "boolean",
          align: "center",
          sortable: true,
        },
        {
          text: "Ngày hủy",
          type: "date",
          showable: true,
          filterable: false,
          value: "ngayHuy",
          searchValue: "ngayHuy",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          sortable: true,
        },
        {
          text: "Người hủy",
          type: "text",
          showable: true,
          filterable: false,
          value: "nguoiHuy.hoTen",
          searchValue: "nguoiHuy",
          sortable: true,
        },
      ],
      headerComponent: Header,
      actions: ["delete", "print", "file:detail"],
      apiCategoryFunctions: {
        dsKhoaDieuTris: {
          func: dsKhoaDieuTri,
          textField: (item) => `${item.stt}-${item.khoa.tenKhoa}`,
          valueField: "stt",
          filterParams: {
            idba: vm.id,
          },
        },
      },
      loadingForm: false,
    };
  },
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => {
          if (this.currentUser.is_admin) {
            return indexAdmin(this.id, params);
          } else {
            return index(this.id, params);
          }
        },
        store: (data) => store({ idba: this.id, ...data }),
        update: (...data) => update(this.id, ...data),
        destroy: (...data) => destroy(this.id, ...data),
        print: (...data) => print(this.id, ...data),
      };
    },
    printHref() {
      return `${window.origin}/api/benh-an-kham-vao-vien/${this.id}/print-ba-file/${this.form.maBa}-BA-KhamVaoVien.pdf`;
    },
  },

  created() {
    this.getData();
  },
  methods: {
    async getData() {
      this.loadingForm = true;
      try {
        const { data } = await getChiTietPhieuKhamVaoVien(this.id);
        if (!data) {
          this.$message({
            message: "Không có dữ liệu",
            type: "info",
          });
          return
        }
        this.form = Object.assign({}, data);
      } catch (e) {
        this.$message({
          message: "Không có dữ liệu",
          type: "info",
        });
      } finally {
        this.loadingForm = false;
      }
    },
    async getSelectKhoa(params) {
      return await getKhoa({ ...params, loai: 1 });
    },
    getBuong(item){
      if(item){
        this.form.buong=null
        this.getBuongKhamBenh(item.maKhoa)
      }
    },
    async getChanDoanBenh(params) {
      return await getBenhTat(params);
    },
    queryChanDoanBenh(query) {
      if (query !== "") {
        this.loading = true;
        setTimeout(() => {
          this.loading = false;
          this.chan_doan_benh_select = this.getChanDoanBenh(query);
        }, 200);
      } else {
        this.getChanDoanBenh();
      }
    },
    async getDanhDSNhanVien(params) {
      return await getNhanVien(params);
    },
    themMoiPhieuDinhDuong() {
      this.$refs.phieuDinhDuong.addDialog();
    },
    editItem(item) {
      this.$refs.phieuDinhDuong.editDialog(item);
    },
    deleteItem(item) {
      this.phieukhams.splice(this.phieukhams.indexOf(item), 1);
    },
    getDanhSachPhieuDanhGia(data) {
      this.phieukhams.push(data);
    },
    submit(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          //alert("submit!");
          this.updateData();
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    async updateData() {
      try {
        await updatePhieuKhamVaoVien(this.id, this.form);
        this.$message({
          message: "Cập nhật thành công.",
          type: "success",
        });
        this.getData();
      } catch (error) {
        this.$message.error("thất bại");
      }
    },
  },
};
</script>
<style>
.title-field {
  font-size: 16px;
}

.red-dot {
  color: red;
}

.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}

.el-select {
  width: 100%;
}

label {
  margin-bottom: -5px !important;
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
</style>
