<template>
  <fragment>
    <v-list-item>
      <v-list-item-icon>
        <v-icon>mdi-text-box-outline</v-icon>
      </v-list-item-icon>
      <v-list-item-content>
        <v-list-item-title> Danh sách danh mục </v-list-item-title>
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>
    <Menu :links="links"></Menu>
  </fragment>
</template>

<script>
import Menu from "./Menu.vue";
export default {
  components: { Menu },
  data() {
    return {
      links: [
        { title: "Danh mục chức danh", name: "Danh mục chức danh" },
        { title: "Danh mục chức vụ", name: "Danh mục chức vụ" },
      ],
    };
  },
};
</script>
