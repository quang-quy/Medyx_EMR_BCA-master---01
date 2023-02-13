<template>
  <Fragment>
    <el-form
      style="width: 100%"
      ref="form"
      :model="createForm"
      :label-width="labelWidth || '120px'"
      label-position="left"
    >
      <el-form-item
        :style="{ 'margin-bottom': 0 }"
        v-for="field in creatableFields.filter(
          (item) => item.form.type != 'custom'
        )"
        :key="field.form.value"
        :prop="field.form.value"
        :rules="field.form.rules"
      >
        <portal :to="`${crudId}-creating-${field.form.value}`">
          <div v-if="field.form.type == 'text'" class="el-input el-input--mini">
            <input
              type="text"
              class="el-input__inner"
              v-model="createForm[field.form.value]"
              :placeholder="
                field.form.placeholder
                  ? field.form.placeholder
                  : 'Nhập ' + field.text.toLowerCase() + '...' || ''
              "
            />
          </div>
          <div
            v-if="field.form.type == 'number'"
            class="el-input el-input--mini"
          >
            <input
              type="number"
              class="el-input__inner"
              v-model.number="createForm[field.form.value]"
            />
          </div>
          <el-checkbox
            v-if="field.form.type == 'boolean' || field.form.type == 'bit'"
            :true-label="field.form.type == 'bit' ? 1 : undefined"
            :false-label="field.form.type == 'bit' ? 0 : undefined"
            v-model="createForm[field.form.value]"
          ></el-checkbox>
          <base-select-async
            v-if="field.form.type == 'select-async'"
            v-model="createForm[field.form.value]"
            :placeholder="field.form.text"
            :label="field.form.label"
            :keyValue="field.form.keyValue"
            :apiFunc="field.form.apiFunc"
            :disabled="!!field.form.disabled"
            :defaultParams="field.form.defaultParams || {}"
            style="width: 100%"
            size="mini"
          ></base-select-async>
          <el-select
            style="width: 100%"
            v-if="field.form.type == 'select'"
            v-model="createForm[field.form.value]"
            :placeholder="field.text"
            size="mini"
            filterable
          >
            <el-option
              v-for="item in categories[field.form.useCategory]"
              :key="item.value"
              :label="item.text"
              :value="item.value"
            >
            </el-option>
          </el-select>
          <el-date-picker
            v-if="field.form.type.startsWith('date')"
            v-model="createForm[field.form.value]"
            :placeholder="'Chọn ' + field.text.toLowerCase() || null"
            :type="field.form.type"
            range-separator="-"
            start-placeholder="Từ"
            style="width: 100%"
            end-placeholder="Tới"
            :format="
              'dd/MM/yyyy' +
              (field.form.type.includes('time') ? ' HH:mm:ss' : '')
            "
            :value-format="
              'yyyy-MM-dd' +
              (field.form.type.includes('time') ? ' HH:mm:ss' : '')
            "
            size="mini"
          >
          </el-date-picker
        ></portal>
      </el-form-item>

      <component
        :is="customFormFields"
        :crudId="crudId"
        :form="createForm"
      ></component>
      <portal :to="`${crudId}-actions-creating`">
        <v-btn @click="createData" color="success" icon x-small>
          <v-icon dark>mdi-check</v-icon></v-btn
        >
        <v-btn @click="$emit('form-reset')" color="primary" icon x-small>
          <v-icon dark>mdi-close</v-icon>
        </v-btn>
      </portal>
    </el-form>
  </Fragment>
</template>
<script>
import formMixin from "@/mixins/crud/form";
export default {
  mixins: [formMixin],
  props: {
    customFormFields: Object,
  },
  data() {
    return {
      formType: "create",
    };
  },
  methods: {
    handlerFocus() {
      console.log("focus");
    },
  },
};
</script>
