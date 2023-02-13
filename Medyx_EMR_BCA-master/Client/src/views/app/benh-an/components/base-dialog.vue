<template>
  <v-dialog
    v-model="dialog"
    v-bind="$attrs"
    close-delay="100"
    :fullscreen="p_fullscreen || fullscreen || isMobile"
    :max-width="maxWidth"
    :min-width="minWidth"
    :persistent="persistent"
    scrollable
    :width="width"
    @keydown.esc="close"
  >
    <v-card
      v-if="loading"
      class="fill-height d-flex flex-column align-center justify-center"
      height="450px"
    >
      <loading />
    </v-card>
    <v-card v-else class="d-flex flex-column" tile :loading="loadingTitle">
      <v-toolbar class="px-3 flex-grow-0" color="primary" dark flat height="60">
        <v-toolbar-title>
          <slot name="title">{{ title }}</slot>
        </v-toolbar-title>
        <v-spacer></v-spacer>
        <v-btn
          icon
          small
          @click="c_fullscreen = !c_fullscreen"
          v-if="showFullscreenBtn && !isMobile"
        >
          <v-icon v-if="!c_fullscreen">mdi-fullscreen</v-icon>
          <v-icon v-else>mdi-fullscreen-exit</v-icon>
        </v-btn>
        <v-btn icon small @click="close">
          <v-icon>mdi-close</v-icon>
        </v-btn>
      </v-toolbar>
      <slot name="content">
        <v-card-text :class="[classContent]" class="flex-grow-1 px-7 pt-7 pb-1">
          <slot></slot>
        </v-card-text>
      </slot>
      <v-card-actions class="flex-grow-0" style="padding: 8px 28px 22px">
        <slot name="action-btn">
          <v-spacer />
          <v-btn class="mr-2 text-none" outlined text @click="close">
            Thoát
          </v-btn>
          <slot name="extra-btn"></slot>
        </slot>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
export default {
  name: "base-dialog",
  inheritAttrs: false,
  props: {
    width: { default: "50%" },
    fullscreen: Boolean,
    value: Boolean,
    title: { type: String, default: "" },
    loading: Boolean,
    persistent: { type: Boolean, default: true },
    maxWidth: { default: 450 },
    minWidth: { default: 300 },
    showFullscreenBtn: Boolean,
    loadingTitle: Boolean,
    classContent: String,
  },
  data() {
    return { bindOnKeyPress: null, p_fullscreen: false, isMobile: false };
  },
  computed: {
    c_fullscreen: {
      set(value) {
        this.p_fullscreen = value;
        this.$emit("update:fullscreen", value);
      },
      get() {
        return this.p_fullscreen;
      },
    },
    dialog: {
      set(value) {
        if (!value) {
          this.$emit("close");
        }
        this.$emit("input", value);
      },
      get() {
        return this.value;
      },
    },
  },
  watch: {
    fullscreen: {
      handler(value) {
        this.p_fullscreen = value;
      },
      immediate: true,
    },
  },
  created() {
    this.bindOnKeyPress = this.onKeyPress.bind(this);
  },
  mounted() {
    window.addEventListener("keydown", this.bindOnKeyPress);
  },
  beforeDestroy() {
    window.removeEventListener("keydown", this.bindOnKeyPress);
  },
  methods: {
    onKeyPress(e) {
      if (this.dialog) {
        if (e.key == "Escape" || e.code == "Escape") {
          this.close();
        }
      }
    },
    close() {
      this.dialog = false;
    },
  },
};
</script>

<style scoped></style>
