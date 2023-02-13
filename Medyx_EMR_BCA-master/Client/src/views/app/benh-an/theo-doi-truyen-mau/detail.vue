<template>
  <app-wrapper :idba="id">
    <div class="pa-2">
      <div class="flex-grow-1 mb-2">
        <form-option
          :options="optionHis"
          :fields="fieldHis"
          :actions="actionHis"
          :dataForm="dataHis"
          @update="handleUpdate"
          @create="handleCreate"
          @print="handlePrint"
          :edit="edit"
        >
          <file-dinh-kem
            :idba="id"
            :stt="stt"
            title="32.Danh Sách file đính kèm chế phẩm máu"
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
          title="Theo dõi truyền máu"
          tableHeight="400px"
        />
      </div>
    </div>
  </app-wrapper>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import formOption from "./components/formOptions.vue";
import * as formOps from "./fields/form-option";
import * as tableTm from "./fields/table";
import * as ApiTruyenMau from "@/api/thong-tin-truyen-mau";
import Header from "./Header.vue";
import fileDinhKem from "./fileDinhKem";

export default {
  props: {
    permission: {
      type: Array,
      default: () => [],
    },
    id: {
      type: [Number, String],
    },
    stt: {
      type: [Number, String],
    },
  },
  components: {
    Crud,
    formOption,
    fileDinhKem,
  },
  data(vm) {
    return {
      headerComponent: Header,
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
      // form-option
      optionHis: formOps.options,
      fieldHis: formOps.fileds,
      actionHis: [],
      dataHis: {},
      // table
      fields: tableTm.fileds,
      apiCategoryFunctions: {},
      actions: tableTm.actions,
      disableActions: {
        edit: (item) =>
          (item.huy && !vm.currentUser.is_admin) ||
          !vm.permission.find(
            (e) =>
              e.ActionDetailsName == "/HSBA/ChePhamMau/TheoDoiTruyenMau/modify"
          ),
        delete: (item) =>
          item.huy ||
          !vm.permission.find(
            (e) =>
              e.ActionDetailsName == "/HSBA/ChePhamMau/TheoDoiTruyenMau/delete"
          ),
      },
      edit: false,
      actionUpdate: [
        {
          title: "Cập nhật",
          type: "primary",
          event: "update",
          icon: "mdi-pencil",
          action: vm.permission.find(
            (e) =>
              e.ActionDetailsName == "/HSBA/ChePhamMau/TheoDoiTruyenMau/modify"
          ),
        },
        {
          title: "In theo dõi truyền máu",
          type: "primary",
          event: "print",
          icon: "mdi-printer",
          action: vm.permission.find(
            (e) =>
              e.ActionDetailsName == "/HSBA/ChePhamMau/TheoDoiTruyenMau/export"
          ),
        },
      ],
      actionCreate: [
        {
          title: "Lưu theo dõi truyền máu",
          type: "success",
          event: "create",
          // icon: "mdi-plus",
          action: vm.permission.find(
            (e) =>
              e.ActionDetailsName == "/HSBA/ChePhamMau/TheoDoiTruyenMau/create"
          ),
        },
        {
          title: "In theo dõi truyền máu",
          type: "primary",
          event: "print",
          icon: "mdi-printer",
          action: vm.permission.find(
            (e) =>
              e.ActionDetailsName == "/HSBA/ChePhamMau/TheoDoiTruyenMau/export"
          ),
        },
      ],
    };
  },
  created() {
    this.getData();
  },
  methods: {
    async getData() {
      const res = await ApiTruyenMau.detail(this.id, this.stt);
      this.edit = res && res.data ? true : false;
      if (this.edit) {
        this.actionHis = this.actionUpdate;
        this.dataHis = res.data;
      } else {
        this.actionHis = this.actionCreate;
        this.getDetailTruyenMau();
      }
    },
    async getDetailTruyenMau() {
      const { data } = await ApiTruyenMau.show(this.id, this.stt);
      this.dataHis = {
        khoaDieuTri: {
          stt: data.khoaDieuTri.stt,
        },
        ngayChiDinh: data.ngayYlenh,
        bsChiDinh: {
          maNv: data.bsChiDinh.maNv,
        },
        chePhamMau: {
          maDV: data.chePhamMau.maDV,
        },
      };
    },
    async handleUpdate(data) {
      const { statusCode } = await ApiTruyenMau.update({
        idba: this.id,
        Sttcpm: this.stt,
        ...data,
      });
      if (statusCode == 200) {
        this.getData();
        this.$message.success("Cập nhật thành công");
      } else {
        this.$message.error("Cập nhật thất bại");
      }
    },
    async handleCreate(data) {
      const response = await ApiTruyenMau.store({
        idba: this.id,
        Sttcpm: this.stt,
        ...data,
      });
      if (response.statusCode == 200) {
        this.getData();
        this.$message.success("Thêm mới thành công");
      }
    },
    async handlePrint(data) {
      await ApiTruyenMau.print(this.id, this.stt);
    },
  },
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => {
          if (this.currentUser.is_admin) {
            return ApiTruyenMau.indexC({
              ...params,
              idba: this.id,
              stttruyenMau: this.stt,
            });
          } else {
            return ApiTruyenMau.indexC({
              ...params,
              idba: this.id,
              stttruyenMau: this.stt,
              huy: false,
            });
          }
        },
        store: (data) =>
          ApiTruyenMau.storeC({
            idba: this.id,
            stttruyenMau: this.stt,
            ...data,
          }),
        update: (...data) => ApiTruyenMau.updateC(this.id, ...data),
        destroy: (...data) => ApiTruyenMau.detroyC(this.id, ...data),
      };
    },
  },
};
</script>

<style lang="scss" scoped></style>
