<template>
  <el-form>
    <div class="d-flex align-flex-end mb-3" v-if="!create">
      <div class="d-flex">
        <v-btn fab small color="primary" depressed outlined @click="goBack()">
          <v-icon dark> mdi-arrow-left </v-icon>
        </v-btn>
        <div class="ml-3">
          <div style="font-size: 20px; font-weight: bold">
            Chi tiết tai biến phẫu thủ thuật
          </div>
        </div>
      </div>
      <div
        class="d-flex flex-grow-1 justify-end mr-10 flex-wrap ml-auto"
        v-if="actions.length"
      >
        <el-button
          v-for="(item, i) in actions"
          :key="`action_${i}`"
          size="small"
          :class="{ 'ml-3': i != 0 }"
          dark
          :disabled="!item.action"
          :title="item.title"
          :type="item.type || 'primary'"
          @click="handleAction(item.title, item.event)"
        >
          <v-icon small class="mr-1" v-if="item.icon" color="white">{{
            item.icon
          }}</v-icon>
          {{ item.title || null }}
        </el-button>
      </div>
    </div>
    <div class="ml-3 mt-1 d-flex flex-grow-1 flex-wrap">
      <div
        v-for="(item, index) in fields"
        :key="`field_${index}`"
        class="mr-10"
      >
        <el-form-item :label="`${index + 1}.${item.label}`">
          <el-input-number
            v-if="item.type == 'number'"
            size="mini"
            outlined
            hide-details
            v-model.number="form[item.value]"
            :disabled="!item.action"
            style="min-width: 450px !important"
            :min="item.min"
            :max="item.max"
          ></el-input-number>
          <el-input
            v-if="item.type == 'text'"
            outlined
            hide-details
            :placeholder="item.placeholder"
            v-model="form[item.value]"
            :type="item.type"
            size="mini"
            style="min-width: 450px !important"
            :disabled="!item.action"
          ></el-input>

          <el-input
            v-if="item.type == 'textarea'"
            outlined
            hide-details
            :placeholder="item.placeholder"
            v-model="form[item.value]"
            :autosize="{ minRows: 5, maxRows: 10 }"
            :type="item.type"
            size="mini"
            :disabled="!item.action"
            class="flex-grow-1"
            style="min-width: 450px !important"
            show-word-limit
            maxlength="5000"
          ></el-input>
          <el-checkbox
            v-if="item.type == 'boolean' || item.type == 'bit'"
            :true-label="item.type == 'bit' ? 1 : undefined"
            :false-label="item.type == 'bit' ? 0 : undefined"
            v-model="form[item.value]"
            :disabled="!item.action"
          ></el-checkbox>
          <base-select-async
            v-if="item.type == 'select-async'"
            v-model="form[item.value]"
            :placeholder="item.placeholder"
            :label="item.labelselect"
            :keyValue="item.keyValue"
            :apiFunc="item.apiFunc"
            style="min-width: 450px !important"
            class="flex-grow-1"
            size="mini"
            :disabled="!item.action"
          ></base-select-async>

          <el-select
            style="min-width: 450px !important"
            class="flex-grow-1"
            v-if="item.type == 'select'"
            v-model="form[item.value]"
            :placeholder="item.placeholder"
            :multiple="item.multiple ? true : false"
            size="mini"
            filterable
            :disabled="!item.action"
          >
            <el-option
              v-for="c in item.category"
              :key="c.value"
              :label="c.text"
              :value="c.value"
            >
            </el-option>
          </el-select>
          <el-date-picker
            v-if="item.type.startsWith('date')"
            v-model="form[item.value]"
            :placeholder="item.placeholder"
            :type="item.type"
            style="min-width: 450px !important"
            end-placeholder="Tới"
            :format="
              'dd/MM/yyyy' + (item.type.includes('time') ? ' HH:mm:ss' : '')
            "
            size="mini"
            :disabled="!item.action"
            :value-format="
              'yyyy-MM-dd' + (item.type.includes('time') ? 'THH:mm:ss' : '')
            "
          >
          </el-date-picker>
          <el-radio-group
            v-model="form[item.value]"
            v-if="item.type == 'radio'"
            style="min-width: 450px !important"
          >
            <el-radio
              v-for="(item, index) in item.category"
              :key="`cate_${index}`"
              :label="item.value"
              >{{ item.text }}</el-radio
            >
          </el-radio-group>
        </el-form-item>
      </div>
    </div>
    <div class="justify-end">
      <slot />
    </div>
    <div
      class="d-flex flex-grow-1 justify-end mr-10 flex-wrap ml-auto"
      v-if="actions.length && create"
    >
      <el-button
        v-for="(item, i) in actions"
        :key="`action_${i}`"
        size="small"
        :class="{ 'ml-3': i != 0 }"
        dark
        :disabled="!item.action"
        :title="item.title"
        :type="item.type || 'primary'"
        @click="handleAction(item.title, item.event)"
      >
        <v-icon small class="mr-1" v-if="item.icon" color="white">{{
          item.icon
        }}</v-icon>
        {{ item.title || null }}
      </el-button>
    </div>
  </el-form>
</template>

<script>
import formMixins from "./formOptionMixins";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import * as ApiPhacDo from "@/api/phac-do-dieu-tri.js";
import { dataChecBox } from "../../theo-doi-va-cham-soc/helperData";
export default {
  mixins: [formMixins],
  data: () => ({ form: {}, listBenh: [] }),
  props: {
    dataForm: {
      type: Object,
      default: () => {},
    },
    fields: {
      type: Array,
      default: () => [],
    },
    actions: {
      type: Array,
      default: () => [],
    },
    edit: {
      type: Boolean,
      default: true,
    },
    create: {
      type: Boolean,
      default: false,
    },
    idba: {
      type: [Number, String],
      required: true,
    },
  },
  mounted() {
    this.$nextTick(() => {});
  },
  created() {
    this.getListBenh();
  },
  watch: {
    dataForm: {
      handler(newValue) {
        this.fields.forEach((element) => {
          this.$set(
            this.form,
            element.value,
            Object.byString(newValue, element.fromValue) || null
          );
        });
      },
      deep: true,
      immediate: true,
    },
  },
  methods: {
    async handleAction(title, event) {
      this.$emit(event, this.form);
    },
    goBack() {
      window.location =
        "/HSBADS/TaiBienThuocThuThuatPhauThuat/" + window.location.href.split("/").at(-3);
    },
    async handleBS(stt) {
      if (!stt) return;
      const { data } = await getBenhAnKhoaDieuTri({
        idba: this.idba,
        huy: false,
        forSelect: true,
      });
      if (data.length) {
        const item = data.find((e) => e.stt == stt);
        if (!item.bsdieuTri.maNv) {
            this.form.bsDieuTri = "Không có dữ liệu bác sỹ điều trị";
          } else {
            this.form.bsDieuTri = `${item.bsdieuTri.maNv}-${item.bsdieuTri.hoTen}-${item.khoa.tenKhoa} `;
            this.form.maBenh = item.benhChinh.maBenh
            this.form.tenBenh = item.benhChinh.tenBenh
          }
      } else {
        this.form.bsDieuTri = "Không có dữ liệu bác sỹ điều trị";
      }
    },
    async getListBenh() {
      const { data } = await ApiPhacDo.dsBenhs();
      this.listBenh = data;
    },
    async handleBenh(maBenh) {
      if (!maBenh) return;
      if (this.listBenh.length) {
        let benh = this.listBenh.find((e) => e.maBenh == maBenh);
        if (benh) {
          this.form.tenBenh = benh.tenBenh;
        } else {
          this.form.tenBenh = "";
        }
      }
    },
  },
};
</script>

<style scoped>
::v-deep .el-form-item__content {
  line-height: 20px;
}
::v-deep .el-form-item__label {
  line-height: 30px;
  padding: 0 0px 0 4px;
  font-size: 14px;
  color: rgb(46, 42, 42);
  font-family: sans-serif;
}
</style>
