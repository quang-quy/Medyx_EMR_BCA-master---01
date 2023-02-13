<template>
  <app-wrapper :idba="id">
    <div class="pa-2">
      <div class="flex-grow-1 mb-2">
        <form-option
          :fields="fieldForms"
          :actions="actionForms"
          :dataForm="data"
          @save="handleSave"
          @print="handlePrint"
          @getNgay="getNgayVaoDieuTri"
          @changeNgayDT="handleShowThucHien"
        >
          <file-dinh-kem
            :idba="id"
            :stt="stt"
            title="8.Danh Sách file đính kèm thực hiện vật lý trị liệu"
          ></file-dinh-kem>
        </form-option>
      </div>
      <div class="flex-grow-1">
        <Crud
          :fields="fields"
          :apiCrudFunctions="apiCrudFunctions"
          :apiCategoryFunctions="apiCategoryFunctions"
          :actions="actions"
          :disableActions="disableActions"
          :headerComponent="headerComponent"
          :wrapper="false"
          primaryKey="stt"
          label-width="100px"
          title="Vật lý trị liệu thực hiện"
          tableHeight="400px"
        />
      </div>
    </div>
  </app-wrapper>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import formOption from "./components/formOptions.vue";
import fileDinhKem from "./fileDinhKem.vue";
import Header from "./Header.vue";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import * as apiDotDTVLTL from "@/api/dot-dieu-tri-vltl";
import * as apiThucHienVLTL from "@/api/thuc-hien-vltl";
import { formatDate, formatDatetime } from "@/utils/formatters";
export default {
  props: {
    id: {
      type: [Number, Array],
      required: true,
    },
    stt: {
      type: [Number, Array],
      required: true,
    },
    permission: {
      type: Array,
      required: true,
    },
  },
  components: {
    Crud,
    formOption,
    fileDinhKem,
  },
  data(vm) {
    return {
      apiThucHienVLTL: apiThucHienVLTL,
      headerComponent: Header,
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
      // form-option
      data: {},
      actionForms: [
        {
          title: "Lưu phiếu vật lý trị liệu",
          type: "success",
          event: "save",
          icon: "mdi-pencil",
          action: vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/ThucHienVatLyTriLieu/modify"
          )
            ? true
            : false,
        },
        {
          title: "In phiếu vật lý trị liệu",
          icon: "mdi-printer",
          type: "primary",
          event: "print",
          icon: "mdi-printer",
          action: vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/ThucHienVatLyTriLieu/export"
          )
            ? true
            : false,
        },
      ],

      // Thuc hien
      apiCategoryFunctions: {},
      actions: ["edit", "delete", "create"],
      disableActions: {
        edit: (item) =>
          (item.huy && !vm.currentUser.is_admin) ||
          !vm.permission.find(
            (e) =>
              e.ActionDetailsName ==
              "/HSBA/ThucHienVatLyTriLieu/ThucHien/modify"
          ),
        delete: (item) =>
          item.huy ||
          !vm.permission.find(
            (e) =>
              e.ActionDetailsName ==
              "/HSBA/ThucHienVatLyTriLieu/ThucHien/delete"
          ),
      },
      ngayYLenhThucHien: null,
      listNgayDT: [],
    };
  },
  async created() {
    await this.getData();
    await this.getNgayVaoDieuTri();
  },
  methods: {
    handleShowThucHien(ngayThucHien) {
      this.ngayYLenhThucHien = ngayThucHien;
    },
    async getNgayVaoDieuTri(sttKhoa = null) {
      const { data } = await apiThucHienVLTL.getListPPVLTL({
        idba: this.id,
        sttKhoa: sttKhoa || this.data.sttkhoa,
      });
      if (!data.length) return;
      data.forEach((e) => {
        let ngayYL = String(formatDate(e.ngayYlenh));
        if (!this.listNgayDT.length) {
          this.listNgayDT.push({
            text: ngayYL,
            value: ngayYL,
          });
        } else {
          let item = this.listNgayDT.find((e) => e.value == ngayYL);
          if (!item) {
            this.listNgayDT.push({
              text: ngayYL,
              value: ngayYL,
            });
          }
        }
      });
      this.data.ngayVaoDieuTri = this.handleNgayVaoDieuTri(
        this.data.ngayVaoDieuTri
      );
    },
    async getData() {
      const { data } = await apiDotDTVLTL.show(this.id, this.stt);
      this.data = data;
      this.ngayYLenhThucHien = this.data.ngayVaoDieuTri;
    },
    async getBenhAnKhoaDieuTris(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.id,
        huy: false,
        forSelect: true,
        ...params,
      });
    },
    async handleSave(data) {
      const { statusCode } = await apiDotDTVLTL.update(this.id, this.stt, data);
      this.handleNotify(statusCode, "Cập nhật");
    },
    handlePrint() {
      return apiDotDTVLTL.print(this.id, this.stt);
    },
    handleNotify(statusCode = true, action = null) {
      if (statusCode == 200) {
        this.getData();
        this.$message.success(
          `${action} vật lý trị liệu đợt điều trị thành công !`
        );
      } else {
        this.$message.error(`${action} vật lý trị liệu đợt điều trị lỗi !`);
      }
    },

    handleSplice20(string) {
      if (string.length <= 20) return string;
      return string.slice(0, 20) + "...";
    },

    handleNgayVaoDieuTri(ngay) {
      if (!ngay) return null;
      let ngayVaoDieuTri = ngay.split("-");
      if (ngayVaoDieuTri.length == 3) {
        return `${ngayVaoDieuTri[2]}/${ngayVaoDieuTri[1]}/${ngayVaoDieuTri[0]}`;
      }
      return ngay;
    },
    handleDate(ngay) {
      if (!ngay) return "null";
      let item = ngay.split("/");
      return `${item[2]}-${item[1]}-${item[0]}`;
    },
  },
  computed: {
    apiCrudFunctions() {
      const vm = this;
      return {
        index: (params) => {
          if (this.currentUser.is_admin) {
            return apiThucHienVLTL.index({
              ...params,
              idba: this.id,
            });
          } else {
            return apiThucHienVLTL.index({
              ...params,
              idba: this.id,
              huy: false,
            });
          }
        },
        store: (data) =>
          apiThucHienVLTL.store({
            idba: this.id,
            SttdotDt: this.stt,
            ...data,
          }),
        update: (...data) =>
          apiThucHienVLTL.update(this.id, data[0], {
            ...data[1],
            SttdotDt: this.stt,
          }),

        destroy: (...data) => apiThucHienVLTL.destroy(this.id, ...data),
      };
    },
    fieldForms() {
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
        {
          label: "Ngày vào điều trị",
          type: "select",
          fromValue: "ngayVaoDieuTri",
          placeholder: "Ngày vào điều trị",
          action: true,
          value: "ngayVaoDieuTri",
          category: this.listNgayDT,
        },
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
        {
          label: "Hủy",
          type: "boolean",
          fromValue: "huy",
          placeholder: "",
          action: this.currentUser.is_admin ? true : false,
          value: "huy",
        },
      ];
    },
    fields() {
      return [
        {
          text: "stt",
          value: "stt",
          searchValue: "stt",
          showable: true,
          filterable: false,
          filterValue: "stt",
          type: "text",
          sortable: true,
          align: "center",
          width: 100,
        },
        {
          text: "Ngày tháng",
          type: "text",
          showable: true,
          filterable: false,
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          value: "ngayThucHien",
          searchValue: "ngayThucHien",
          width: 200,
          sortable: true,
          width: 200,
          align: "center",
          form: {
            value: "ngayThucHien",
            fromValue: "ngayThucHien",
            default: null,
            type: "datetime",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Phương pháp",
          type: "text",
          showable: true,
          filterable: false,
          value: "phuongPhap",
          searchValue: "phuongPhap",
          formatter: function (_, __, value) {
            return `${value.maDv}${value.tenDv ? "-" + value.tenDv : ""}${
              value.donViDo ? "-" + value.donViDo : ""
            }`;
          },
          width: 200,
          sortable: true,
          width: 200,
          align: "center",
          form: {
            value: "sttchiDinh",
            fromValue: "sttchiDinh",
            default: null,
            default: null,
            type: "select-async",
            label: (item) =>
              `${item.dichVu.maDv}${
                item.dichVu.tenDv ? "-" + item.dichVu.tenDv : ""
              }-${this.handleSplice20(item.viTri)}-Số lượng: ${Number(
                item.soLuong
              )}`,
            keyValue: "stt",
            apiFunc: this.apiThucHienVLTL.getListPPVLTL,
            disabled: this.ngayYLenhThucHien ? false : true,
            defaultParams: {
              idba: this.id,
              ngayVaoDieuTri: this.handleDate(this.ngayYLenhThucHien),
            },
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Thời gian",
          type: "text",
          showable: true,
          filterable: false,
          value: "thoiGian",
          searchValue: "thoiGian",
          width: 200,
          sortable: true,
          width: 200,
          align: "center",
          form: {
            value: "thoiGian",
            fromValue: "thoiGian",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Liều lượng",
          value: "lieuLuong",
          searchValue: "lieuLuong",
          showable: true,
          filterable: false,
          filterValue: "lieuLuong",
          type: "text",
          sortable: true,
          align: "center",
          width: 150,
          form: {
            value: "lieuLuong",
            fromValue: "lieuLuong",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Ghi chú",
          value: "ghiChu",
          searchValue: "ghiChu",
          showable: true,
          filterable: false,
          filterValue: "ghiChu",
          type: "text",
          sortable: true,
          align: "center",
          width: 150,
          form: {
            value: "ghiChu",
            fromValue: "ghiChu",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Ngày lập",
          type: "date",
          showable: true,
          filterable: false,
          value: "ngayLap",
          searchValue: "ngayLap",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
          sortable: true,
        },
        {
          text: "Người lập",
          type: "text",
          showable: true,
          filterable: false,
          value: "nguoiLap.hoTen",
          searchValue: "nguoiLap",
          filterValue: "nguoiSua",
          width: 150,
          sortable: true,
        },
        {
          text: "Ngày sửa",
          type: "date",
          showable: true,
          filterable: false,
          value: "ngaySd",
          searchValue: "ngaySd",
          filterValue: "ngaySua",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
          sortable: true,
        },
        {
          text: "Người sửa",
          type: "text",
          showable: true,
          value: "nguoiSD.hoTen",
          searchValue: "nguoiSD",
          filterable: false,
          width: 150,
          sortable: true,
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
          form: {
            value: "huy",
            fromValue: "huy",
            default: null,
            type: "boolean",
            creatable: false,
            editable: true,
          },
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
          width: 150,
          sortable: true,
        },
        {
          text: "Người hủy",
          type: "text",
          showable: true,
          filterable: false,
          value: "nguoiHuy.hoTen",
          searchValue: "nguoiHuy",
          width: 150,
          sortable: true,
        },
      ];
    },
  },
};
</script>

<style lang="scss" scoped></style>
