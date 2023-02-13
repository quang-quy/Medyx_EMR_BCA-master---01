<template>
  <v-app-bar dark app elevation="4" clipped-left color="primary">
    <v-img
      max-width="100"
      class="mr-6"
      :src="require('@/assets/app/logo.png')"
    ></v-img>
    <!-- <v-toolbar-title class="mx-6">BAĐT</v-toolbar-title> -->

    <v-btn
      v-for="link in navigationLinks"
      :key="link.url"
      @click="goto(link.url)"
      text
      dark
      >{{ link.title }}</v-btn
    >

    <v-spacer></v-spacer>
    <v-menu offset-y>
      <template v-slot:activator="{ on, attrs }">
        <v-avatar v-bind="attrs" v-on="on" color="blue darken-4" size="45">
          <v-icon>mdi-account</v-icon>
        </v-avatar>
      </template>
      <v-list>
        <v-list-item dense>
          <v-list-item-title class="text-center">{{
            user.name
          }}</v-list-item-title>
        </v-list-item>
        <v-divider></v-divider>
        <v-list-item
          :to="link.url"
          v-for="link in userLinks"
          :key="link.url"
          link
        >
          <v-list-item-title>{{ link.title }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
  </v-app-bar>
</template>
<script>
import { mapGetters } from "vuex";
export default {
  computed: {
    ...mapGetters(["user"]),
  },
  data() {
    return {
      navigationLinks: [
        {
          title: "Bệnh án",
          url: "/benh-an",
        },
        {
          title: "Danh mục",
          url: "/danh-muc/chuc-danh",
        },
        {
          title: "Báo cáo",
          url: "/bao-cao",
        },
      ],
      userLinks: [
        {
          title: "Thông tin cá nhân",
          url: "/thong-tin-ca-nhan",
        },
        {
          title: "Đăng xuất",
          url: "/logout",
        },
      ],
    };
  },
  methods: {
    goto(url) {
      if (this.$route.path === url) return;
      this.$router.push(url);
    },
  },
};
</script>
