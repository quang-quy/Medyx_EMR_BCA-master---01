<template>
  <Fragment>
    <el-form
      style="width: 100%"
      ref="form"
      :model="form"
      :label-width="labelWidth || '120px'"
      label-position="left"
    >
      <el-form-item
        :style="{ 'margin-bottom': 0 }"
        v-for="field in editableFields.filter(
          (item) => item.form.type != 'custom'
        )"
        :key="field.form.value"
        :prop="field.form.value"
        :rules="field.form.rules"
      >
        <portal
          :to="`${crudId}-editing-${currentEditingRowId}-${field.form.value}`"
        >
          <div v-if="field.form.type == 'text'" class="el-input el-input--mini">
            <input
              type="text"
              class="el-input__inner"
              v-model="form[field.form.value]"
              :placeholder="field.form.placeholder"
              :disabled="!!field.form.disabled"
              :class="{'disable': !!field.form.disabled }"
              />
          </div>
          <div
            v-if="field.form.type == 'number'"
            class="el-input el-input--mini"
          >
            <input
              type="number"
              class="el-input__inner"
              v-model.number="form[field.form.value]"
              :disabled="!!field.form.disabled"
            />
          </div>
          <el-checkbox
            v-if="field.form.type == 'boolean' || field.form.type == 'bit'"
            :true-label="field.form.type == 'bit' ? 1 : undefined"
            :false-label="field.form.type == 'bit' ? 0 : undefined"
            v-model="form[field.form.value]"
            :disabled="!!field.form.disabled"
            :class="{'disable': !!field.form.disabled }"
          ></el-checkbox>
          <base-select-async
            v-if="field.form.type == 'select-async'"
            v-model="form[field.form.value]"
            :placeholder="field.form.text"
            :label="field.form.label"
            :keyValue="field.form.keyValue"
            :apiFunc="field.form.apiFunc"
            :defaultParams="field.form.defaultParams || {}"
            :disabled="!!field.form.disabled"
            style="width: 100%"
            size="mini"
          ></base-select-async>
          <el-select
            style="width: 100%"
            v-if="field.form.type == 'select'"
            v-model="form[field.form.value]"
            :placeholder="field.form.text"
            size="mini"
            filterable
            :disabled="!!field.form.disabled"
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
            v-model="form[field.form.value]"
            :placeholder="field.form.placeholder"
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
              (field.form.type.includes('time') ? 'THH:mm:ss' : '')
            "
            size="mini"
            :disabled="!!field.form.disabled"
            :class="{'disable': !!field.form.disabled }"
          >
          </el-date-picker
        ></portal>
      </el-form-item>

      <component
        :is="customFormFields"
        :crudId="crudId"
        :form="form"
        :currentEditingRowId="currentEditingRowId"
        :isEditForm="true"
      ></component>

      <portal :to="`${crudId}-actions-editing-${currentEditingRowId}`">
        <v-btn @click="updateData" color="success" icon x-small>
          <v-icon dark>mdi-check</v-icon></v-btn
        >
        <v-btn @click="cancel" color="primary" icon x-small>
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
      formType: "edit",
    };
  },
};
</script>
<style scoped>
.disable{
  background-color: #F5F7FA;
  color: #C4C5C6;
}
</style>
