<template>
  <el-form>
    <div class="ml-3 mt-1 d-flex flex-grow-1 flex-wrap">
      <div
        v-for="(item, index) in fields"
        :key="`field_${index}`"
        class="mr-10"
      >
        <el-form-item
          :label="`${index + 1}.${item.label}`"
          :class="{ 'mt-3': index != 0 || index != 1 }"
        >
          <el-input-number
            v-if="item.type == 'number'"
            size="mini"
            outlined
            hide-details
            v-model.number="form[item.value]"
            :disabled="dependense[item.value]"
            style="min-width: 150px !important"
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
            style="min-width: 280px !important ; max-width: 320px"
            :disabled="dependense[item.value]"
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
            :disabled="dependense[item.value]"
            class="flex-grow-1"
            style="min-width: 280px !important ; max-width: 320px"
          ></el-input>

          <el-checkbox
            v-if="item.type == 'boolean' || item.type == 'bit'"
            v-show="currentUser.is_admin"
            :true-label="item.type == 'bit' ? 1 : undefined"
            :false-label="item.type == 'bit' ? 0 : undefined"
            v-model="form[item.value]"
            :disabled="dependense[item.value]"
          ></el-checkbox>
          <base-select-async
            v-if="item.type == 'select-async'"
            v-model="form[item.value]"
            :placeholder="item.placeholder"
            :label="item.labelselect"
            :keyValue="item.keyValue"
            :apiFunc="item.apiFunc"
            :defaultParams="item.defaultParams"
            style="min-width: 280px !important ; max-width: 320px"
            class="flex-grow-1"
            size="mini"
            :disabled="dependense[item.value]"
          ></base-select-async>

          <el-select
            style="min-width: 280px !important ; max-width: 320px"
            class="flex-grow-1"
            v-if="item.type == 'select'"
            v-model="form[item.value]"
            :placeholder="item.placeholder"
            :multiple="item.multiple ? true : false"
            size="mini"
            filterable
            :disabled="dependense[item.value]"
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
            style="min-width: 280px !important ; max-width: 320px"
            end-placeholder="Tới"
            :format="
              'dd/MM/yyyy' + (item.type.includes('time') ? ' HH:mm:ss' : '')
            "
            :value-format="
              'yyyy-MM-dd' + (item.type.includes('time') ? 'THH:mm:ss' : '')
            "
            size="mini"
            :disabled="dependense[item.value]"
          >
          </el-date-picker>
          <el-radio-group
            v-model="form[item.value]"
            v-if="item.type == 'radio'"
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
    <div class="d-flex flex-grow-1 justify-end mr-1 mt-3" v-if="actions.length">
      <el-button
        v-for="(item, i) in actions"
        :key="`action_${i}`"
        :type="item.type"
        :icon="item.icon ? item.icon : ''"
        @click="handleAction(item.title, item.event)"
        :disabled="item.disabled"
        size="small"
        >{{ item.title }}</el-button
      >
    </div>
  </el-form>
</template>

<script>
import formmixins from "./formmixins";
export default {
  mixins: [formmixins],
  data: () => ({
    form: {},
    dependense: {},
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
  }),
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
    primaryKey: String,
  },
  mounted() {
    if (Object.keys(this.dataForm).length) {
      this.fields.forEach((element) => {
        this.$set(
          this.form,
          element.value,
          Object.byString(this.dataForm, element.fromValue)
        );
        this.$set(this.dependense, element.value, element.disable);
      });
    }
  },
  watch: {
    dataForm: {
      handler: function (newVal) {
        if (Object.keys(newVal).length) {
          this.fields.forEach((element) => {
            this.$set(
              this.form,
              element.value,
              Object.byString(newVal, element.fromValue)
            );
            this.$set(this.dependense, element.value, element.disable);
          });
        }
      },
      imimmediate: true,
      deep: true,
    },
  },
  methods: {
    async handleAction(title, event) {
      const formData = this.setFormData();
      this.$emit(event, formData);
    },
    setFormData() {
      var formData = this.form;
      return formData;
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
