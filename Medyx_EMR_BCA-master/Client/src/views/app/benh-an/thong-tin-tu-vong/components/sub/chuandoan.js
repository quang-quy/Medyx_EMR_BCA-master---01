const chuanDoanMixins = {
  watch: {
    "form.phauThuat"(newVal) {
      this.fields.find((e) => e.value == "ngayPhauThuat").action =
        newVal == 1 ? true : false;
      if (this.fields.find((e) => e.value == "ngayPhauThuat").action == false) {
        this.form.ngayPhauThuat = null;
      }
      this.fields.find((e) => e.value == "lyDoPt").action =
        newVal == 1 ? true : false;
      if (this.fields.find((e) => e.value == "lyDoPt").action == false) {
        this.form.lyDoPt = null;
      }
    },
    "form.kntt"(newVal) {
      this.fields.find((e) => e.value == "sdkq").action =
        newVal == 1 ? true : false;
    },
    "form.noiTuVong"(newVal) {
      this.fields.find((e) => e.value == "noiTv").action = newVal.includes(9)
        ? true
        : false;
    },
    "form.maBenhNntv"(val) {
      this.getBenhDetail(val);
    },
  },
};
export default chuanDoanMixins;
