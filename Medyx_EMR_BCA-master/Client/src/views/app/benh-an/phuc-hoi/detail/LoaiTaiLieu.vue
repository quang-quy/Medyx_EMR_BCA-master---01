<template>
  <v-navigation-drawer>
    <v-list-item>
      <v-list-item-content>
        <v-list-item-title class="text-h6"> Loại tài liệu </v-list-item-title>
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>
    <v-list dense nav>
      <v-list-item-group v-model="selectedItem" color="primary">
        <v-list-item
          v-for="item in danhSachLoaiTaiLieu"
          :key="item.maLoaiTaiLieu"
          link
        >
          <v-list-item-content>
            <v-list-item-title>{{ item.tenLoaiTaiLieu }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
  </v-navigation-drawer>
</template>
<script>
export default {
  props: ["value", "danhSachLoaiTaiLieu"],
  computed: {
    selectedItem: {
      set(val) {
        this.$emit("input", this.danhSachLoaiTaiLieu[val].maLoaiTaiLieu);
      },
      get() {
        return this.danhSachLoaiTaiLieu.findIndex(
          (item) => item.maLoaiTaiLieu === this.value
        );
      },
    },
  },
};
</script>
