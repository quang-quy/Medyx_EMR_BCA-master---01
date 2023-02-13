<template>
  <div
    :class="{
      'el-input': true,
      'el-input--medium': size === 'medium',
      'el-input--mini': size === 'mini',
      'el-input--large': size === 'large',
      'el-input--small': size === 'small',
      dis: disabled,
    }"
    style="position: relative"
  >
    <input
      :id="id"
      type="text"
      :placeholder="placeholder"
      class="el-input__inner"
      :disabled="disabled"
      :class="{ dis: disabled }"
    />
    <i
      v-show="value"
      @click="clear"
      style="
        position: absolute;
        cursor: pointer;
        top: calc(50% - 7px);
        right: 9px;
      "
      v-if="!disabled"
      class="el-icon-close"
    ></i>
  </div>
</template>

<script>
export default {
  data() {
    return {
      id: (Math.random() + 1).toString(36).substring(7),
      control: null,
    };
  },
  props: {
    value: String,
    type: {
      type: String,
      default: "date",
    },
    size: {
      type: String,
      default: "medium",
    },
    placeholder: {
      type: String,
      default: "",
    },
    disabled: {
      type: Boolean,
      default: false,
    },
  },
  watch: {
    value: {
      handler: function (val) {
        if (val) {
          this.$nextTick(() => {
            if (this.type === "date")
              this.control.datepicker("setDate", new Date(val));
            else {
              this.control.datetimepicker("setOptions", {
                value: new Date(val),
              });
            }
          });
        }
      },
      immediate: true,
    },
  },
  methods: {
    clear() {
      $(`#${this.id}`).val(null);
      this.$emit("input", null);
      this.$emit("change", null);
    },
  },
  mounted() {
    if (this.type === "datetime") {
      $(`#${this.id}`).datetimepicker({
        format: "d/m/Y H:i",
        formatTime: "H:i",
        formatDate: "d/m/Y",
        regional: "vi",
        language: "vi",
      });
      $(`#${this.id}`).mask("99/99/9999 99:99");
      this.control = $(`#${this.id}`);
    } else {
      this.control = $(`#${this.id}`).datepicker({
        format: "dd/mm/yyyy",
        language: "vi",
        regional: "vi",
      });
      $(`#${this.id}`).mask("99/99/9999");
    }
    $(`#${this.id}`).change((e) => {
      const [d, m, y] = e.target.value.substr(0, 10).split("/");
      const t = e.target.value.substring(10);
      const val = [y, m, d].join("-") + t;
      this.$emit("input", val);
      this.$emit("change", val);
    });
  },
};
</script>
<style scoped>
.dis {
  background-color: #f5f7fa;
  color: darkgrey;
}
</style>
