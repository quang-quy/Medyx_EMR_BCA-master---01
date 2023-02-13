<template>
  <v-app>
    <app-bar />
    <app-drawer />
    <app-footer />
    <app-view />
    <Loader />
  </v-app>
</template>

<script>
export default {
  components: {
    AppBar: () => import("./components/AppBar"),
    AppDrawer: () => import("./components/app-drawer/Index.vue"),
    AppFooter: () => import("./components/AppFooter"),
    AppView: () => import("./components/AppView"),
    Loader: () => import("../../components/Loader"),
  },
};
</script>
