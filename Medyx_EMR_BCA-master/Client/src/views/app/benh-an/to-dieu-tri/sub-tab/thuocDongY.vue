<template>
  <div>
    <Crud
      :fields="fields"
      :apiCrudFunctions="apiCrudFunctions"
      :apiCategoryFunctions="apiCategoryFunctions"
      :actions="actions"
      :disableActions="disableActions"
      primaryKey="stt"
      label-width="100px"
      tableHeight="400px"
      :wrapper="false"
      onlyTable
      :hasExit="false"
      ref="table"
      :title="title"
      :customFormFields="customFormFields"
    >
      <template #slot-header>
        <div class="mb-2 mt-3 mb-5">
          <div class="d-flex">
            <div>
              <div class="body-2 my-2 font-weight-bold">
                3.1 Danh sách bài thuốc
              </div>
              <base-select-async
                v-model="maBaiThuoc"
                :label="(item) => `${item.maBthuoc} - ${item.tenBthuoc}`"
                keyValue="maBthuoc"
                :apiFunc="getdsBaiThuocs"
                placeholder="Chọn bài thuốc"
                :disabled="
                  !permission.find(
                    (e) =>
                      e.ActionDetailsName == '/HSBA/todieutri/thuocdongy/create'
                  )
                "
              >
              </base-select-async>
            </div>
            <div class="ml-5">
              <div class="body-2 my-2 font-weight-bold">3.2 Tên bài thuốc</div>
              <el-input
                v-model="form.tenBaiThuoc"
                style="width: 350px"
                size="small"
              />
            </div>
            <div class="ml-5">
              <div class="body-2 my-2 font-weight-bold">3.3 Số lượng thang</div>
              <el-input-number
                v-model="form.soLuongThang"
                :min="0"
                :max="15"
                :step="1"
                style="width: 150px"
                size="small"
              />
            </div>
            <div class="ml-auto">
              <div style="height: 37px"></div>
              <v-btn
                small
                color="green"
                @click="submit()"
                :loading="isLoading"
                :disabled="
                  !permission.find(
                    (e) =>
                      e.ActionDetailsName == '/HSBA/todieutri/thuocdongy/modify'
                  )
                "
              >
                <v-icon small left color="#ffffff">mdi-check</v-icon>
                <span class="white--text"> Lưu đơn thuốc </span>
              </v-btn>
            </div>
          </div>
          <div class="flex-grow-0 d-flex mt-2">
            <div class="flex-grow-1" style="min-width: 200px">
              <div>
                <div class="body-2 my-2 font-weight-bold">3.4 Cách sắc</div>
                <el-input
                  v-model="form.cachSacThuoc"
                  type="textarea"
                  rows="5"
                  size="small"
                />
              </div>
              <div>
                <div class="body-2 my-2 font-weight-bold">3.5 Cách dùng</div>
                <el-input
                  v-model="form.cachDung"
                  type="textarea"
                  rows="5"
                  size="small"
                />
              </div>
            </div>
            <div class="ml-5 flex-grow-0">
              <sub-table
                v-model="listThuoc"
                title="Danh sách thuốc"
                @handleCreate="handleCreate"
                @handleDelete="handleDelete"
                @selectThuoc="selectThuoc"
              ></sub-table>
            </div>
          </div>
        </div>
        <div class="body-2 font-weight-bold mb-2">
          Danh sách bệnh án thuốc đông y
        </div>
      </template>
    </Crud>
  </div>
</template>

<script>
import { formatDate, formatDatetime } from "@/utils/formatters";
import {
  index,
  update,
  store,
  destroy,
  getYHCT,
  updateYHCT,
  storeFromBaiThuoc,
  ds_thuocDongY,
  ds_baiThuocDongY,
  getThuocBaiThuoc,
} from "@/api/benhAnToDieuTri/thuoc-dong-y";

import Crud from "@/components/crud/Index.vue";
import layoutOption from "../components/layout-option.vue";
import { getNhanVien } from "@/api/to-dieu-tri";
import subTable from "../components/sub-table.vue";
import thuocDongYSelection from "../selections/thuocDongYSelection.vue";
export default {
  components: {
    Crud,
    layoutOption,
    subTable,
  },
  props: {
    title: {
      type: String,
      default: "Danh sách",
    },
    params: {
      type: Object,
      default: () => {},
    },
    dataDetail: {
      type: Object,
      default: () => {},
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  watch: {
    params: {
      handler: function (neVal) {
        this.getYHCTs();
        this.$refs.table.reset();
      },
      deep: true,
    },
    maBaiThuoc: {
      handler: function (newVal) {
        this.addBaiThuoc(newVal);
      },
      immediate: true,
    },
  },
  data: (vm) => ({
    isLoading: false,
    customFormFields: thuocDongYSelection,
    maBaiThuoc: null,
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    form: {
      soLuongThang: 1,
      cachDung: null,
      cachSacThuoc: null,
      tenBaiThuoc: null,
    },
    fields: [
      {
        text: "STT",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "stt",
        searchValue: "stt",
        width: 70,
        align: "center",
      },
      {
        text: "Mã thuốc",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "thuoc.maThuoc",
        searchValue: "maThuoc",
        width: 120,
        align: "center",
      },
      {
        text: "Tên thuốc",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "thuoc.tenTm",
        searchValue: "tenTm",
        width: 200,
        align: "center",
        form: {
          value: "maThuoc",
          fromValue: "thuoc.maThuoc",
          default: null,
          creatable: true,
          editable: true,
          type: "custom",
        },
      },
      {
        text: "Đơn vị tính",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "thuoc.donViTinh.tenDvt",
        searchValue: "donVi",
        width: 120,
        align: "center",
        form: {
          value: "donViTinh",
          fromValue: "thuoc.donViTinh.tenDvt",
          default: null,
          creatable: true,
          editable: true,
          type: "custom",
        },
      },
      {
        text: "Số lượng",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "soLuong",
        searchValue: "soLuong",
        width: 120,
        align: "center",
        form: {
          value: "soLuong",
          fromValue: "soLuong",
          default: null,
          type: "number",
          creatable: true,
          editable: true,
          rules: [
            {
              validator: (v) => v !== null && v !== undefined,
              message: "Trường này bắt buộc nhập",
            },
            {
              validator: (v) => v > 0,
              message: "Trường này bắt buộc lớn hơn 0",
            },
          ],
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
        width: 120,
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
        width: 120,
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
        width: 120,
        sortable: true,
      },
      {
        text: "Người sửa",
        type: "text",
        showable: true,
        value: "nguoiSD.hoTen",
        searchValue: "nguoiSD",
        filterable: false,
        width: 170,
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
        width: 120,
        sortable: true,
      },
      {
        text: "Người hủy",
        type: "text",
        showable: true,
        filterable: false,
        value: "nguoiHuy.hoTen",
        searchValue: "nguoiHuy",
        width: 170,
        sortable: true,
      },
    ],
    apiCategoryFunctions: {},
    actions: ["create", "edit", "delete"],
    disableActions: {
      edit: (item) =>
        (item.huy && !vm.currentUser.is_admin) ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/thuocdongy/modify"
        ),
      delete: (item) =>
        item.huy ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/thuocdongy/delete"
        ),
    },
    listThuoc: [
      {
        baiThuoc: null,
        thuoc: {
          maThuoc: "",
          tenTm: "",
        },
        donViTinh: {
          maDvt: "",
        },
        soluong: 1,
      },
    ],
    thuocFilter: [],
    baiThuocFilter: [],
  }),
  created() {
    Promise.all([this.getYHCTs(), this.getThuocs(), this.getBaiThuocs()]);
  },
  methods: {
    async getYHCTs() {
      this.form = this.$options.data.call(this).form;
      const { data } = await getYHCT(this.params);
      if (data.length > 0) {
        this.form = Object.assign(this.form, { ...data[0] });

        this.$refs.table.reset();
      } else {
        this.$refs.table.reset();
      }
    },
    async getBaiThuocs() {
      const { data } = await ds_baiThuocDongY();
      this.baiThuocFilter = data;
    },
    async getThuocs() {
      const { data } = await ds_thuocDongY();
      this.thuocFilter = data;
    },
    async addBaiThuoc(maBaiThuoc) {
      if (!maBaiThuoc) return;
      const { data } = await getThuocBaiThuoc({
        maBthuoc: maBaiThuoc,
      });

      var dsThuocBaiThuoc = data;
      const baiThuoc = this.baiThuocFilter.find(
        (e) => e.maBthuoc == maBaiThuoc
      );
      dsThuocBaiThuoc = dsThuocBaiThuoc.map((x) => ({
        ...x,
        baiThuoc: baiThuoc ? baiThuoc.tenBthuoc : null,
      }));
      if (this.listThuoc.length > 1) {
        dsThuocBaiThuoc.forEach((item) => {
          const tempt = this.listThuoc.find(
            (e) => e.thuoc.maThuoc == item.thuoc.maThuoc
          );
          if (tempt) {
            this.listThuoc.find(
              (e) => e.thuoc.maThuoc == item.thuoc.maThuoc
            ).soluong += item.soluong;
          } else {
            this.listThuoc = this.listThuoc.push(item);
          }
        });
      } else {
        this.listThuoc = this.listThuoc.concat(dsThuocBaiThuoc);
      }

      this.maBaiThuoc = this.$options.data.call(this).maBaiThuoc;
    },
    async getdsBaiThuocs(params) {
      return await ds_baiThuocDongY(params);
    },
    async addThuocYHCTC(data) {
      const response = await store({ ...data });
      return true;
    },
    async submit() {
      if (!this.form.stt) {
        let benhAnThuocYhctCs = [];
        if (this.listThuoc.length) {
          this.listThuoc.forEach((e, index) => {
            if (index != 0) {
              if (!e.soluong) {
                this.$message.error(
                  "Số lượng thuốc của " + e.thuoc.tenTm + " phải lớn hơn 0"
                );
                return;
              }
              benhAnThuocYhctCs.push({
                maThuoc: e.thuoc.maThuoc,
                soLuong: e.soluong,
                huy: false,
              });
            }
          });
        }
        this.form.idba = this.params.idba;
        this.form.sttKhoa = this.dataDetail.sttkhoa;
        this.form.ngayYLenh = this.params.ngayylenh;
        this.form.thuocYhctCs = benhAnThuocYhctCs.length
          ? benhAnThuocYhctCs
          : [];
        try {
          this.$loader(true);
          const resAdd = await storeFromBaiThuoc(this.form);
          if (resAdd.statusCode == 200) {
            this.isLoading = true;
            this.listThuoc = this.$options.data.call(this).listThuoc;
            this.getYHCTs();
            this.isLoading = false;
            this.$message.success("Thêm mới thành công");
          } else {
            this.$message.error("Thêm mới thất bại");
          }
          this.$loader(false);
        } catch (error) {
          this.$message.error("Lỗi : " + error);
        }
      } else {
        if (this.listThuoc.length > 1) {
          // Kiem tra so luong cua cac thuoc trong bang thuoc con phai lon hon 0 ? ket thuc
          this.listThuoc.forEach((e, index) => {
            if (index != 0) {
              if (!e.soluong) {
                this.$message.error(
                  "Số lượng thuốc của " + e.thuoc.tenTm + " phải lớn hơn 0"
                );
                return;
              }
            }
          });
          const data = {
            idba: this.params.idba,
            sttKhoa: this.dataDetail.sttkhoa,
            sttThuoc: this.form.stt,
            thuocs: this.listThuoc
              .slice(1, this.listThuoc.length)
              .map((x) => ({ soLuong: x.soluong, maThuoc: x.thuoc.maThuoc })),
          };
          await store(data);
        }
        const resAdd = await updateYHCT(
          this.params.idba,
          this.form.stt,
          this.form
        );
        if (resAdd.statusCode == 200) {
          this.isLoading = true;
          this.listThuoc = this.$options.data.call(this).listThuoc;
          this.$refs.table.reset();
          this.isLoading = false;
          this.$message.success("Cập nhật thành công");
        } else {
          this.$message.error("Cập nhật không thành công");
        }
      }
    },
    handleCreate(item) {
      if (!item.thuoc || !item.thuoc.maThuoc) {
        this.$message.error("Chưa chọn thuốc");
        return;
      }
      var thuoc = this.thuocFilter.find((e) => e.maThuoc == item.thuoc.maThuoc);
      if (thuoc) {
        this.listThuoc.push({
          thuoc,
          donViTinh: {
            ...thuoc.donViTinh,
          },
          soluong: item.soluong,
        });
      }
      this.listThuoc.shift();
      this.listThuoc.unshift({
        thuoc: {
          maThuoc: "",
          tenTm: "",
          maThuoc: "",
        },
        donViTinh: {
          maDvt: "",
        },
        soluong: 1,
      });
    },
    selectThuoc(event) {
      var thuoc = this.thuocFilter.find((e) => e.maThuoc == event);
      if (thuoc) {
        this.listThuoc[0].thuoc.tenTm = thuoc.tenTm;
        this.listThuoc[0].donViTinh.maDvt = thuoc.donViTinh.maDvt;
      }
    },
    handleDelete(index) {
      if (index < 1) return;
      this.listThuoc.splice(index, 1);
    },
  },
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => {
          if (this.form && this.form.stt) {
            if (this.currentUser.is_admin) {
              return index({
                ...params,
                idba: this.params.idba,
                sttThuoc: this.form.stt,
              });
            } else {
              return index({
                ...params,
                idba: this.params.idba,
                sttThuoc: this.form.stt,
                huy: false,
              });
            }
          }
          return {
            data: [],
            meta: {},
          };
        },
        store: (data) =>
          store({
            idba: this.params.idba,
            sttKhoa: this.dataDetail.sttkhoa,
            ngayYLenh: this.dataDetail.ngayYLenh,
            sttThuoc: this.form.stt,
            ...data,
          }),
        update: (...data) => update(this.params.idba, ...data),
        destroy: (...item) => destroy(this.params.idba, ...item),
      };
    },
  },
};
</script>
