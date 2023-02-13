<template>
  <v-row>
    <v-col
      v-for="field in filterFields"
      :key="field.filter.value"
      xl="2"
      lg="2"
      md="3"
      sm="4"
      xs="6"
      cols="12"
    >
      <el-input
        v-if="field.filter.type == 'text'"
        outlined
        size="medium"
        hide-details
        :placeholder="field.text"
        v-model="filterParams[field.filter.value]"
        :type="field.filter.type"
        v-debounce:700ms="handleInputChange"
        clearable
        @clear="handleInputChange"
      ></el-input>
      <el-select
        v-if="field.filter.type == 'select'"
        v-model="filterParams[field.filter.value]"
        :placeholder="field.text"
        style="width: 100%"
        @change="handleInputChange"
        clearable
        @clear="handleInputChange"
        :multiple="field.filter.multiple"
        size="medium"
        filterable
      >
        <el-option
          v-for="item in categories[field.filter.useCategory]"
          :key="item.value"
          :label="item.code ? item.text + ' - ' + item.code : item.text"
          :value="item.value"
        >
          <span style="float: left">{{ item.text }}</span>
          <span
            v-if="item.code"
            style="float: right; color: #8492a6; font-size: 13px"
            >{{ item.code }}</span
          >
        </el-option>
      </el-select>
      <el-date-picker
        @change="handleInputChange"
        style="width: 100%"
        v-if="field.filter.type.startsWith('date')"
        v-model="filterParams[field.filter.value]"
        :placeholder="field.text"
        :type="field.filter.type"
        range-separator="-"
        :start-placeholder="`${field.filter.placeholder} từ`"
        :end-placeholder="`${field.filter.placeholder} tới`"
        clearable
        :format="
          'dd/MM/yyyy' + (field.filter.type.includes('time') ? ' HH:mm' : '')
        "
        :value-format="
          'yyyy-MM-dd' + (field.filter.type.includes('time') ? ' HH:mm:ss' : '')
        "
        size="medium"
      >
      </el-date-picker>
    </v-col>
  </v-row>
</template>
<script>
import filtersMixin from "@/mixins/crud/filters";
export default {
  mixins: [filtersMixin],
};
</script>
