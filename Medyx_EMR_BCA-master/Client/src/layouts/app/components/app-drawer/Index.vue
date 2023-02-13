<template>
  <v-navigation-drawer :value="show" clipped app stateless>
    <component :is="drawerContent" />
  </v-navigation-drawer>
</template>
<script>
import Category from "./Category.vue";
import MedicalRecordDetail from "./MedicalRecordDetail.vue";
import MedicalRecordList from "./MedicalRecordList.vue";
export default {
  components: { Category, MedicalRecordDetail },
  data() {
    return {
      components: {
        Category: Category,
        MedicalRecordDetail: MedicalRecordDetail,
        MedicalRecordList: MedicalRecordList,
      },
    };
  },
  computed: {
    drawerContent() {
      return this.components[this.$route.meta.drawerContent];
    },
    show() {
      return !!this.drawerContent;
    },
  },
};
</script>
