<template>
  <div
    class="align-center pa-2 justify-space-between d-flex"
    style="background-color: #f8f8ff"
  >
    <div class="text-body-1">
      <span>{{ `Tổng ` }}</span>
      <span class="font-weight-bold">{{ total }}</span>
      <span>{{ ` trang` }}</span>
    </div>
    <div class="d-flex">
      <div class="align-center">
        <v-select
          style="max-width: 130px"
          dense
          hide-details
          outlined
          :items="items"
          v-model="itemPerPage"
          @change="$emit('perPageChanged', itemPerPage)"
        />
      </div>
      <div>
        <v-pagination
          class="justify-sm-start"
          circle
          v-model="itemPage"
          :length="length"
          total-visible="5"
          color="#228B22"
          @input="$emit('pageChanged', itemPage)"
        ></v-pagination>
      </div>
    </div>
    <div></div>
  </div>
</template>
<script>
export default {
  props: {
    length: { type: Number, default: 1 },
    itemPerPage: { type: Number, default: 10 },
    itemPage: { type: Number, default: 1 },
    total: { type: Number, default: 0 },
  },
  computed: {
    items() {
      return [
        {
          value: 5,
          text: `5 / trang`,
        },
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
      ];
    },
  },
};
</script>
