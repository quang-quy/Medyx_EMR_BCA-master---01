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
        v-for="field in editableFields"
        :key="field.form.value"
        :prop="field.form.value"
        :rules="field.form.rules"
      >
        <portal :to="`editing-${currentEditingRowId}-${field.form.value}`">
          <el-input
            v-if="field.form.type == 'text' || field.form.type == 'number'"
            outlined
            hide-details
            :placeholder="field.form.text"
            v-model="form[field.form.value]"
            :type="field.form.type"
            size="mini"
          ></el-input>
          <el-switch
            v-if="field.form.type == 'boolean'"
            v-model="form[field.form.value]"
            size="mini"
          ></el-switch>
          <el-select
            style="width: 100%"
            v-if="field.form.type == 'select'"
            v-model="form[field.form.value]"
            :placeholder="field.form.text"
            size="mini"
          >
            <el-option
              v-for="item in categories[field.form.useCategory]"
              :key="item.id"
              :label="item.name"
              :value="item.id"
            >
              <span style="float: left">{{ item.name }}</span>
              <span style="float: right; color: #8492a6; font-size: 13px">{{
                item.code
              }}</span>
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
              'dd/MM/yyyy' +
              (field.form.type.includes('time') ? ' HH:mm:ss' : '')
            "
            size="mini"
          >
          </el-date-picker
        ></portal>
      </el-form-item>
      <portal :to="`actions-editing-${currentEditingRowId}`">
        <v-btn @click="updateData" color="success" icon x-small>
          <v-icon dark>mdi-check</v-icon></v-btn
        >
        <v-btn @click="cancel" color="primary" icon x-small>
          <v-icon dark>mdi-close</v-icon>
        </v-btn>
      </portal>
    </el-form>

    <el-form
      style="width: 100%"
      ref="form"
      :model="createForm"
      :label-width="labelWidth || '120px'"
      label-position="left"
    >
      <el-form-item
        :style="{ 'margin-bottom': 0 }"
        v-for="field in creatableFields"
        :key="field.form.value"
        :prop="field.form.value"
        :rules="field.form.rules"
      >
        <portal :to="`creating-${field.form.value}`">
          <el-input
            v-if="field.form.type == 'text' || field.form.type == 'number'"
            outlined
            hide-details
            :placeholder="field.form.text"
            v-model="createForm[field.form.value]"
            :type="field.form.type"
            size="mini"
          ></el-input>
          <el-switch
            v-if="field.form.type == 'boolean'"
            v-model="createForm[field.form.value]"
            size="mini"
          ></el-switch>
          <el-select
            style="width: 100%"
            v-if="field.form.type == 'select'"
            v-model="createForm[field.form.value]"
            :placeholder="field.form.text"
            size="mini"
          >
            <el-option
              v-for="item in categories[field.form.useCategory]"
              :key="item.id"
              :label="item.name"
              :value="item.id"
            >
              <span style="float: left">{{ item.name }}</span>
              <span style="float: right; color: #8492a6; font-size: 13px">{{
                item.code
              }}</span>
            </el-option>
          </el-select>
          <el-date-picker
            v-if="field.form.type.startsWith('date')"
            v-model="createForm[field.form.value]"
            :placeholder="field.form.text"
            :type="field.form.type"
            range-separator="-"
            start-placeholder="Từ"
            style="width: 100%"
            end-placeholder="Tới"
            :format="
              'dd/MM/yyyy' +
              (field.form.type.includes('time') ? ' HH:mm:ss' : '')
            "
            size="mini"
          >
          </el-date-picker
        ></portal>
      </el-form-item>
      <portal :to="`actions-creating`">
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
};
</script>
