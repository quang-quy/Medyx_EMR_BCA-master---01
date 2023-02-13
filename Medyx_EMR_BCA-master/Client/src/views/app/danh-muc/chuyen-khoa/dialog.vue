<template>
  <!-- Edit Dialog -->
  <base-dialog
    v-model="dialog.show"
    max-width="500px"
    min-width="700px"
    scrollable
    :title="`${titleDialog} chức vụ`"
    width="50%"
  >
    <base-form ref="form" lazy-validation @submit.stop="onSubmit">
      <v-row no-gutters>
        <v-col cols="12">
          <v-text-field
            v-model="dialog.data.ten"
            autofocus
            :error-messages="dialog.error.ten"
            filled
            label="Tên hiển thị"
            no-label
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12">
          <v-text-field
            v-model="dialog.data.mo_ta"
            :error-messages="dialog.error.mo_ta"
            filled
            label="Mô tả"
            no-label
            typeInput="v-textarea"
            row="4"
          ></v-text-field>
        </v-col>
        <v-col cols="12">
          <v-text-field
            v-model="dialog.data.trang_thai"
            label="Trạng thái"
            typeInput="v-switch"
            inset
          ></v-text-field>
        </v-col>
        <v-col cols="12">
          <v-text-field
            v-model="dialog.data.thoi_gian_bat_dau"
            :error-messages="dialog.error.thoi_gian_bat_dau"
            filled
            label="Thời gian bắt đầu"
            no-label
            typeInput="field-date"
            persistent-hint
          ></v-text-field>
        </v-col>
        <v-col cols="12">
          <v-text-field
            v-model="dialog.data.thoi_gian_ket_thuc"
            :error-messages="dialog.error.thoi_gian_ket_thuc"
            filled
            label="Thời gian kết thúc"
            no-label
            typeInput="field-date"
            persistent-hint
          ></v-text-field>
        </v-col>
      </v-row>
    </base-form>
    <template v-slot:extra-btn>
      <v-btn
        color="primary"
        :loading="dialog.loading"
        outlined
        :type-action="dialog.type"
        @click="onSubmit"
      >
      </v-btn>
    </template>
  </base-dialog>
</template>

<script>
import BaseDialog from "../components/base-dialog.vue";
import BaseForm from "../components/base-form.vue";
import {EDIT_TYPE} from '../components/type';
export default {
  components: { BaseDialog, BaseForm },
  props: {
    option: { type: Object, default: () => ({}) },
  },
  data: () => ({
    dialog: {
      show: false,
      loading: false,
      data: {},
      type: EDIT_TYPE.CREATE,
      error: {},
    },
    items: [
      { text: "Hoạt động", value: 1 },
      { text: "Dừng hoạt động", value: 0 },
    ],
  }),
  computed: {
    titleDialog() {
      if (this.isCreateDialog) {
        return 'Thêm mới';
      } else {
        return 'Cập nhật';
      }
    },
    isCreateDialog() {
      return this.dialog.type == EDIT_TYPE.CREATE;
    },
  },
  methods: {
    open(item, type) {
      if (this.$refs.form) this.$refs.form.resetValidation();
      this.dialog.show = true;
      this.dialog.type = type;
      this.$set(this.dialog, "data", { ...item });
    },
    dialogClose() {
      this.dialog = {
        show: false,
        loading: false,
        data: {},
        type: EDIT_TYPE.CREATE,
        error: {},
      };
    },

    async onSubmit() {
      this.dialog.error = {};
      if (!(await this.$refs.form.validate())) return;
      try {
        let data = Object.assign({}, this.dialog.data);

        this.dialog.loading = true;
        // let res = this.isCreateDialog
        //   ? await API_ADMIN_SPBANGGIA.create(data)
        //   : await API_ADMIN_SPBANGGIA.update(data.id, data)

        // if (res && !res.error) {
        //   this.dialogClose()
        //   this.getData()
        // }
        // if (
        //   res &&
        //   res.error &&
        //   res.error.response &&
        //   res.error.response.status == 422
        // ) {
        //   const { response } = res.error
        //   this.dialog.error = response.data.errors
        // }
      } finally {
        this.dialog.loading = false;
      }
    },
    getData() {
      this.$emit("reset");
    },
  },
};
</script>

<style scoped>
.v-btn {
  font-weight: 400;
}
</style>
