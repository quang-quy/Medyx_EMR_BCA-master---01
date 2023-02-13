<template>
  <v-row class="align-center">
    <v-col cols="12" lg="2" sm="4" md="3" class="py-0">
      <v-select
        :style="{
          width: $vuetify.breakpoint.xsOnly ? '100%' : '100px',
        }"
        item-text="text"
        :items="items"
        item-value="value"
        v-model="params.perPage"
        @change="$emit('perPageChanged')"
      ></v-select>
    </v-col>
    <v-col cols="12" lg="10" sm="8" md="9" class="py-0">
      <v-pagination
        class="justify-sm-start"
        v-model="params.page"
        :length="length"
        total-visible="10"
        @input="$emit('pageChanged')"
      ></v-pagination>
    </v-col>
  </v-row>
</template>
<script>
export default {
  props: ["length", "params"],
  computed: {
    items() {
      return [
        {
          value: 10,
          text: `10 / trang`,
        },
        {
          value: 15,
          text: `15 / trang`,
        },
        {
          value: 20,
          text: `20 / trang`,
        },
        {
          value: 50,
          text: `50 / trang`,
        },
        {
          value: 100,
          text: `100 / trang`,
        },
      ];
    },
  },
  methods: {},
};
</script>
