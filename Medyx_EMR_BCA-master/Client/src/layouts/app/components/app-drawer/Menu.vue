<template>
  <v-list dense nav>
    <v-list-item-group color="primary" :value="currentLink">
      <v-list-item
        v-for="item in links"
        :key="item.title"
        link
        :to="{ name: item.name }"
      >
        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item></v-list-item-group
    >
  </v-list>
</template>

<script>
export default {
  props: {
    links: {
      type: Array,
      default: () => [],
    },
  },
  computed: {
    currentLink() {
      return this.links.findIndex((i) => i.name === this.$route.name);
    },
  },
};
</script>
