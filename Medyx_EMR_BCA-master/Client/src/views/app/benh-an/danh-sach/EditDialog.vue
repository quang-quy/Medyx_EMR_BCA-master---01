<template>
  <el-dialog title="Chỉnh sửa" :visible.sync="showEditFormDialog" width="30%">
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
        :label="field.text"
      >
        <el-input
          v-if="field.form.type == 'number'"
          outlined
          hide-details
          :placeholder="field.form.text"
          v-model.number="form[field.form.value]"
          :type="field.form.type"
        ></el-input>
        <el-input
          v-if="field.form.type == 'text'"
          outlined
          hide-details
          :placeholder="field.form.text"
          v-model="form[field.form.value]"
          :type="field.form.type"
        ></el-input>
        <el-switch
          v-if="field.form.type == 'boolean'"
          v-model="form[field.form.value]"
        ></el-switch>
        <el-select
          style="width: 100%"
          v-if="field.form.type == 'select'"
          v-model="form[field.form.value]"
          :placeholder="field.form.text"
        >
          <el-option
            v-for="item in categories[field.form.useCategory]"
            :key="item.code"
            :label="item.text"
            :value="item.code"
          >
          </el-option>
        </el-select>
        <el-date-picker
          v-if="field.form.type.startsWith('date')"
          v-model="form[field.form.value]"
          :placeholder="field.form.text"
          :type="field.form.type"
          range-separator="-"
          start-placeholder="Từ"
          style="width: 100%"
          end-placeholder="Tới"
          :format="
            'dd/MM/yyyy' + (field.form.type.includes('time') ? ' HH:mm:ss' : '')
          "
        >
        </el-date-picker>
      </el-form-item>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <el-button @click="updateData">Cập nhật</el-button>
      <el-button type="primary" @click="cancel">Hủy</el-button>
    </span>
  </el-dialog>
</template>

<script>
import formMixin from "@/mixins/crud/form";
export default {
  mixins: [formMixin],
};
</script>
