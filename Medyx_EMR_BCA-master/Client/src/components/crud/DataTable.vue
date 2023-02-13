<template>
  <v-row>
    <v-col cols="12">
      <el-table
        size="small"
        ref="elTable"
        style="width: 100%"
        lazy
        :data="filteredData"
        :height="tableHeight"
        border
        :header-cell-style="{
          padding: '0px',
          fontWeight: 'bold',
          fontSize: '13px',
        }"
        :cell-style="{
          padding: '2px 0px',
          fontWeight: 'bold',
          color: '#212121',
          fontSize: '13px',
        }"
        :row-style="{
          padding: '0px',
        }"
        @cell-dblclick="handleCellDbClick"
        @sort-change="handleSort"
      >
        <el-table-column
          v-for="c in headers"
          :key="c.value"
          :label="c.text"
          :sortable="c.sortable ? 'custom' : false"
          :width="c.width"
          :align="c.align"
          :prop="c.value"
        >
          <template slot-scope="scope">
            <!-- filter -->
            <v-text-field
              :style="{ margin: '3px 0' }"
              dense
              outlined
              hide-details
              :placeholder="c.text"
              v-model="filters[c.value].value"
              v-if="isSearching && scope.$index === 0"
              v-debounce:200ms="filterTableData"
            >
            </v-text-field>
            <!-- edit -->
            <portal-target
              v-else-if="
                editing &&
                scope.row[primaryKey] === currentEditingRowId &&
                actions.includes('edit')
              "
              :name="`${crudId}-editing-${currentEditingRowId}-${
                c.form ? c.form.value : c.value
              }`"
            >
            </portal-target>
            <!-- create -->
            <portal-target
              v-else-if="scope.row[primaryKey] === 0"
              :name="`${crudId}-creating-${c.form ? c.form.value : c.value}`"
            >
            </portal-target>
            <!-- content -->
            <template v-else>
              <el-checkbox
                v-if="c.type == 'boolean'"
                :value="Object.byString(scope.row, c.value)"
                readonly
                size="large"
              />
              <el-checkbox
                v-else-if="c.type == 'bit'"
                :value="Object.byString(scope.row, c.value)"
                :true-label="c.type == 'bit' ? 1 : undefined"
                :false-label="c.type == 'bit' ? 0 : undefined"
                readonly
                size="large"
              />

              <a
                v-else-if="c.type == 'link'"
                :href="Object.byString(scope.row, c.value)"
              >
                {{ Object.byString(scope.row, c.value) }}
              </a>
              <span
                v-else-if="c.type == 'file'"
                title="mở file"
                @click="$emit('clickFile', scope.row)"
                style="cursor: pointer"
              >
                <v-icon color="primary" left>mdi-file</v-icon>
                <span> {{ Object.byString(scope.row, c.value) }}</span>
              </span>
              <span v-else>
                <span>
                  {{
                    c.formatter
                      ? c.formatter(
                          scope.row,
                          scope.column,
                          Object.byString(scope.row, c.value)
                        )
                      : Object.byString(scope.row, c.value)
                  }}
                </span>
              </span>
            </template>
          </template>
        </el-table-column>

        <el-table-column
          v-if="actions.length > 0"
          label="Hành động"
          :width="actions.length < 4 ? 140 : 150"
          fixed="left"
          align="center"
        >
          <template slot-scope="scope">
            <div v-if="isSearching && scope.$index === 0"></div>
            <portal-target
              v-else-if="
                editing &&
                scope.row[primaryKey] === currentEditingRowId &&
                actions.includes('edit')
              "
              :name="`${crudId}-actions-editing-${currentEditingRowId}`"
            >
            </portal-target>
            <portal-target
              v-else-if="scope.row[primaryKey] === 0"
              :name="`${crudId}-actions-creating`"
            >
            </portal-target>
            <template v-else>
              <el-checkbox
                v-if="actions.some((a) => a.startsWith('checkbox'))"
                v-model="scope.row.active"
                class="mr-auto"
              ></el-checkbox>
              <v-btn
                v-if="actions.some((a) => a.startsWith('detail'))"
                @click="
                  goToDetailPage(
                    actions
                      .find((a) => a.startsWith('detail'))
                      .replace('detail:', ''),
                    scope.row
                  )
                "
                color="success"
                icon
                x-small
                :disabled="scope.row.showable === false"
              >
                <v-icon dark>mdi-information-variant</v-icon>
              </v-btn>
              <v-btn
                v-if="actions.includes('print')"
                @click="handlePrint(scope.row)"
                color="indigo"
                icon
                x-small
                :disabled="scope.row.printable === false"
              >
                <v-icon dark>mdi-printer</v-icon>
              </v-btn>
              <v-btn
                v-if="
                  actions.includes('edit') || actions.includes('edit:dialog')
                "
                @click="handleEdit(scope.row)"
                icon
                color="primary"
                x-small
                :disabled="scope.row.editable === false"
              >
                <v-icon dark>mdi-pencil</v-icon>
              </v-btn>
              <v-btn
                v-if="actions.includes('file:dialog')"
                @click="$emit('show-file', scope.row)"
                icon
                color="primary"
                x-small
                :disabled="scope.row.filable === false"
              >
                <v-icon dark>mdi-file</v-icon>
              </v-btn>
              <v-btn
                v-if="actions.includes('file:detail')"
                @click="$emit('show-file', scope.row)"
                icon
                color="primary"
                x-small
                :disabled="scope.row.filable === false"
              >
                <v-icon dark>mdi-information-variant</v-icon>
              </v-btn>
              <v-btn
                v-if="actions.includes('delete')"
                @click="handleDelete(scope.row)"
                color="error"
                icon
                x-small
                :disabled="scope.row.deletable === false"
                class="ml-5"
              >
                <v-icon dark>mdi-delete</v-icon>
              </v-btn></template
            >
          </template>
        </el-table-column>
      </el-table>
    </v-col>
  </v-row>
</template>
<script>
import dataTableMixin from "@/mixins/crud/data-table";
export default {
  mixins: [dataTableMixin],
};
</script>
<style lang="scss">
.v-text-field__slot {
  input {
    font-size: 11px;
    padding: 4px 0 0px;
  }
  fieldset {
    bottom: 0;
    top: 0;
    left: 0;
  }
}
.v-text-field .v-input__control .v-input__slot {
  min-height: 0px !important;
  padding: 0 8px !important;
  margin-bottom: 2px !important;
  display: flex !important;
  align-items: center !important;
}

.v-text-field .v-input__control .v-input__slot .v-input__append-inner {
  margin-top: 3px !important;
}

.v-text-field__details {
  margin: 0px !important;
}
</style>
