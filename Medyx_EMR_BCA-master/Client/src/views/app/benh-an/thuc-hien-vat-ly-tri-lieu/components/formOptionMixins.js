const formMixins = {
  watch: {
    "form.Sttkhoa"(newVal) {
      if (!newVal) {
        this.form.ngayVaoDieuTri = null;
        this.form.bsDieuTri = null;
        return;
      }
      this.handleBS(newVal);
      this.handleNgayDieuTri(newVal);
      this.form.ngayVaoDieuTri = null;
    },
    "form.ngayVaoDieuTri"(newVal) {
      this.$emit("changeNgayDT", newVal);
    },
  },
};
export default formMixins;
