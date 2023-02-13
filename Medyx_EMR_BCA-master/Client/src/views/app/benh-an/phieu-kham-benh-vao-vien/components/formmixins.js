const formMixins = {
  watch: {
    "form.coSutCan"(newVal) {
      if (newVal != 1) {
        this.$set(this.form, "diemSutCan", null);
      }
      this.$set(this.dependense, "diemSutCan", newVal == 1 ? false : true);
      // let csSutCan = Number(newVal) + Number(this.form.diemSutCan);
      // this.$set(this.form, "chiSoSutCan", csSutCan);
    },
    "form.diemSutCan"(newVal) {
      this.$set(this.form, "chiSoSutCan", Number(newVal) || 0);
    },
    "form.chiSoSutCan"(newVal) {
      let total = Number(newVal) + Number(this.form.diemNgonMieng);
      this.$set(this.form, "chiSoMst", total || 0);
    },

    "form.diemNgonMieng"(newVal) {
      let total = Number(newVal) + Number(this.form.chiSoSutCan);
      this.$set(this.form, "chiSoNgonMieng", newVal);
      this.$set(this.form, "chiSoMst", total || 0);
    },
    "form.chiSoMst"(newVal) {
      let danhGia = Number(newVal) <= 1 ? "Không có nguy cơ" : "Có nguy cơ";
      this.$set(this.form, "danhGiaTheoMst", danhGia);
    },
    "form.canNang"(newVal) {
      let danhGiaBmi =
        this.form.chieuCao * 1 > 0
          ? (newVal / Math.pow(this.form.chieuCao / 100, 2)).toFixed(5)
          : 0;
      this.$set(this.form, "bmi", danhGiaBmi);
    },
    "form.chieuCao"(newVal) {
      let danhGiaBmi =
        newVal && newVal * 1 > 0
          ? (this.form.canNang / Math.pow(newVal / 100, 2)).toFixed(5)
          : 0;
      this.$set(this.form, "bmi", danhGiaBmi);
    },
  },
};
export default formMixins;
