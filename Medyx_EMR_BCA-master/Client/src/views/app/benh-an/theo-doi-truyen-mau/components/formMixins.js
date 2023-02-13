const chuanDoanMixins = {
  watch: {
    "form.nhomMauCpm"(newVal) {
      this.form.dinhNhomMauChePhamTaiGiuong = newVal;
    },
    "form.nhomMau"(newVal) {
      if (!newVal) return;
      this.form.dinhNhomMauNguoiBenhTaiGiuong = newVal + " - " + this.form.rh;
    },
    "form.rh"(newVal) {
      if (!newVal) return;
      this.form.dinhNhomMauNguoiBenhTaiGiuong =
        this.form.nhomMau + " - " + newVal;
    },
  },
};
export default chuanDoanMixins;
