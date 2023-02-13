<template>
  <el-dialog :visible.sync="dialog" width="1050px">
    <template slot="title">
      <div class="px-3">
        <div style="font-size: 16px; font-weight: bold" class="mb-3">
          Thêm mới vật lý trị liệu
        </div>
        <v-progress-linear
          color="primary"
          rounded
          value="100"
          height="2"
        ></v-progress-linear>
      </div>
    </template>
    <!-- form -->
    <form-option
      :create="true"
      :dataForm="data"
      :fields="fields"
      :actions="actions"
      :idba="idba"
      @create="handleCreate"
      >
      <!-- @getNgay="getNgayVaoDieuTri" -->
    </form-option>
  </el-dialog>
</template>
<script>
import dialogMixin from "@/mixins/crud/dialog";
import formOption from "./components/formOptions";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import { formatDate, formatDatetime } from "@/utils/formatters";
import * as apiThucHienVLTL from "@/api/thuc-hien-vltl";
import * as apiDotDTVLTL from "@/api/dot-dieu-tri-vltl";
export default {
  mixins: [dialogMixin],
  components: {
    formOption,
  },

  data(vm) {
    return {
      idba: window.location.href.split("/").at(-1),
      data: {},
      actions: [
        {
          title: "Thêm mới",
          type: "primary",
          event: "create",
          icon: "mdi-plus",
          action: true,
        },
      ],
      isLoading: false,
      listNgayDT: [],
    };
  },
  watch: {},
  async created() {
    // await this.getNgayVaoDieuTri();
  },
  methods: {
    async getBenhAnKhoaDieuTris(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.idba,
        huy: false,
        forSelect: true,
        ...params,
      });
    },
    // async getNgayVaoDieuTri(sttKhoa = null) {
    //   const { data } = await apiThucHienVLTL.getListPPVLTL({
    //     idba:  this.idba,
    //     sttKhoa: sttKhoa || this.data.sttkhoa,
    //   });
    //   if (!data.length) return;
    //   data.forEach((e) => {
    //     let ngayYL = String(formatDate(e.ngayYlenh));
    //     if (!this.listNgayDT.length) {
    //       this.listNgayDT.push({
    //         text: ngayYL,
    //         value: ngayYL,
    //       });
    //     } else {
    //       let item = this.listNgayDT.find((e) => e.value == ngayYL);
    //       if (!item) {
    //         this.listNgayDT.push({
    //           text: ngayYL,
    //           value: ngayYL,
    //         });
    //       }
    //     }
    //   });
    // },

    async handleCreate(data) {
      const { statusCode } = await apiDotDTVLTL.store({
        idba: this.idba,
        ...data,
      });
      if (statusCode == 200) {
        this.dialog = false;
        this.$emit("reload");
        this.data = {};
        this.$message.success(`Thêm mới vật lý trị liệu đợt điều trị thành công !`);
      } else {
        this.$message.error(`Thêm mới vật lý trị liệu đợt điều trị lỗi !`);
      }
    },
  },
  computed: {
    fields() {
      return [
        {
          label: "Khoa",
          type: "select-async",
          fromValue: "sttkhoa",
          placeholder: "Chọn khoa",
          action: true,
          keyValue: "stt",
          apiFunc: this.getBenhAnKhoaDieuTris,
          labelselect: (item) =>
            `${item.khoa.maKhoa} - ${item.khoa.tenKhoa} - ${formatDatetime(
              item.ngayVaoKhoa
            )}`,
          value: "Sttkhoa",
        },
        {
          label: "Tên bác sỹ điều trị",
          type: "text",
          fromValue: "bsdieuTri.hoTen",
          placeholder: "Tên bác sỹ điều trị",
          action: false,
          value: "bsDieuTri",
        },
        // {
        //   label: "Ngày vào điều trị",
        //   type: "select",
        //   fromValue: "ngayVaoDieuTri",
        //   placeholder: "Ngày vào điều trị",
        //   action: true,
        //   value: "ngayVaoDieuTri",
        //   category: this.listNgayDT,
        // },
        {
          label: "Phương pháp điều trị",
          type: "textarea",
          fromValue: "ppdt",
          placeholder: "Phương pháp điều trị",
          action: true,
          value: "ppdt",
        },
        {
          label: "Khám bệnh",
          type: "textarea",
          fromValue: "khamBenh",
          placeholder: "Khám bệnh",
          action: true,
          value: "khamBenh",
        },
        {
          label: "Xử trí",
          type: "textarea",
          fromValue: "xuTri",
          placeholder: "Xử trí",
          action: true,
          value: "xuTri",
        },
        {
          label: "Kết quả",
          type: "textarea",
          fromValue: "kq",
          placeholder: "Kết quả",
          action: true,
          value: "kq",
        },
      ];
    },
  },
};
</script>
<style></style>
