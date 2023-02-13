<template>
  <AppWrapper :showTenBenhAn="false">
    <v-card height="calc(100% - 105px)" width="100%" class="">
      <LoaiTaiLieu
        v-model="loaiTaiLieu"
        :danhSachLoaiTaiLieu="danhSachLoaiTaiLieu"
      />
      <div
        style="
          position: absolute;
          top: 0;
          left: 256px;
          width: calc(100% - 256px);
          padding: 10px;
          height: 100%;
          overflow-y: auto;
        "
      >
        <ThongTinLuuTru
          :id="id"
          :danhSachLoaiTaiLieu="danhSachLoaiTaiLieu"
          :daLuuTru="daLuuTru"
          @regenerate="regenerateReport"
        />
        <DanhSachTaiLieu
          ref="danh-sach-tai-lieu"
          :id="id"
          :loaiTaiLieu="loaiTaiLieu"
          :danhSachLoaiTaiLieu="danhSachLoaiTaiLieu"
          :isGeneratedReport="isGeneratedReport"
        />
      </div>
    </v-card>
  </AppWrapper>
</template>
<script>
import ThongTinLuuTru from "./detail/ThongTinLuuTru.vue";
import LoaiTaiLieu from "./detail/LoaiTaiLieu.vue";
import DanhSachTaiLieu from "./detail/DanhSachTaiLieu.vue";
import { index as getDanhSachLoaiTaiLieu } from "@/api/tap-tin-dinh-kem";
import { generateReport, getThongTinReport, reset } from "@/api/luu-tru";
import reports from "./reports";
export default {
  components: { ThongTinLuuTru, LoaiTaiLieu, DanhSachTaiLieu },
  props: ["id"],
  data() {
    return {
      loaiTaiLieu: null,
      danhSachLoaiTaiLieu: [],
      daLuuTru: false,
      isGeneratedReport: false,
      loading: false,
      reports,
    };
  },

  methods: {
    async getDanhSachLoaiTaiLieu() {
      this.loading = true;
      const { data } = await getDanhSachLoaiTaiLieu();
      this.items = data;
      this.danhSachLoaiTaiLieu = data;
      this.loading = false;
    },

    async init() {
      await this.getDanhSachLoaiTaiLieu();
      const { data: isGeneratedReport } = await getThongTinReport(this.id);
      if (isGeneratedReport === null) window.location = "/";
      if (!isGeneratedReport) await this.generateReport(this.id);
      this.loaiTaiLieu = this.danhSachLoaiTaiLieu[0].maLoaiTaiLieu;
    },

    async generateReport() {
      this.loading = this.$loading({
        lock: true,
        text: "Đang tải",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      let count = 0;
      for (const report of this.reports) {
        this.loading.text = `Đang tạo báo cáo: ${report.text} (${count}/${this.reports.length})`;
        try {
          await generateReport(this.id, report.value);
        } catch (error) {
          console.log("Error when regenerate:", report.text);
        }
        count++;
      }
      this.loading.close();
      this.loaiTaiLieu = null;
      this.$nextTick(
        () => (this.loaiTaiLieu = this.danhSachLoaiTaiLieu[0].maLoaiTaiLieu)
      );
    },
    async regenerateReport() {
      this.loading = this.$loading({
        lock: true,
        text: "Đang xóa dữ liệu cũ",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });

      await reset(this.id);
      this.loading.close();
      this.generateReport();
    },
  },

  created() {
    this.init();
  },
};
</script>
