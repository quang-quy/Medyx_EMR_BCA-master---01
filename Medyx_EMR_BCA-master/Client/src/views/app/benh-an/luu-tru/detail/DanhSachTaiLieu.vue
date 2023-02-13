<template>
  <div class="px-3">
    <div class="d-flex mr-auto mb-5">
      <div class="mr-1 align-center">
        <v-avatar color="primary" size="40" tile>
          <v-icon dark>mdi-table</v-icon>
        </v-avatar>
      </div>

      <h3 style="margin-top: 3px" class="ml-2 mt-1 font-weight-regular">
        Danh sách tài liệu
      </h3>
      <el-input
        style="margin-left: auto; width: 200px"
        placeholder="Tìm kiếm file"
        v-model="search"
        size="small"
      >
      </el-input>
    </div>
    <div class="danh-sach-tai-lieu">
      <el-card
        class="tai-lieu"
        v-for="(document, index) in documents.filter((d) =>
          d.name.toLowerCase().includes(search.toLowerCase())
        )"
        :key="index"
        :body-style="{ padding: 0 }"
      >
        <div @click="preview(document)" class="tai-lieu__thumbnail">
          <img
            :src="
              imageExts.includes(document.ext)
                ? origin + '\\' + document.link
                : `https://via.placeholder.com/200x100?text=${document.ext}`
            "
            alt="Không tìm thấy ảnh"
            width="100%"
            height="100%"
          />
          <div class="tai-lieu__thumbnail__preview">
            <v-icon>mdi-eye</v-icon>
          </div>
        </div>
        <h5 class="px-2">{{ document.name }}</h5>
      </el-card>
    </div>
    <el-dialog
      title="Preview tài liệu"
      :visible.sync="dialogVisible"
      width="80%"
      v-if="document"
      top="10px"
    >
      <embed
        :style="{
          width: '100%',
          height:
            document.type === 'application/pdf'
              ? 'calc(100vh - 150px)'
              : 'unset',
        }"
        :src="document.link"
      />
    </el-dialog>
  </div>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { getListFile } from "@/api/file-phi-cau-truc";
export default {
  props: ["loaiTaiLieu", "id"],
  components: {
    Crud,
  },
  data: () => ({
    dialogVisible: false,
    document: null,
    documents: [],
    imageExts: ["png", "jpg"],
    search: "",
    loading: null,
    origin: window.location.origin,
  }),
  watch: {
    loaiTaiLieu(val) {
      if (val) this.getListFile();
    },
  },
  methods: {
    preview(document) {
      let type = null;
      const link = window.location.origin + "/" + document.link;
      if (this.imageExts.includes(document.ext)) {
        type = "image/png";
      } else if (document.ext === "pdf") {
        type = "application/pdf";
      }
      if (!type) return window.open(link, "_blank");
      this.document = {
        link,
        type,
      };
      this.dialogVisible = true;
    },
    async getListFile() {
      this.loading = this.$loading({
        lock: true,
        text: "Đang tải",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      const { data } = await getListFile({
        loaiTaiLieu: this.loaiTaiLieu,
        idba: this.id,
      });

      this.documents = data.map((d) => ({
        ...d,
        name: d.link.split("\\").pop(),
        ext: d.link.split(".").pop(),
      }));
      this.loading.close();
      this.loading = null;
    },
  },
};
</script>

<style lang="scss">
.danh-sach-tai-lieu {
  display: flex;
  flex-wrap: wrap;
  height: calc(100vh - 390px);
  overflow-y: auto;
  .tai-lieu {
    width: 200px;
    height: 155px;
    margin-right: 30px;
    margin-bottom: 30px;
    .tai-lieu__thumbnail {
      cursor: pointer;
      width: 200px;
      height: 100px;
      position: relative;
      padding: 0;
      display: block;
      &:hover {
        .tai-lieu__thumbnail__preview {
          visibility: visible;
        }
      }
      .tai-lieu__thumbnail__preview {
        position: absolute;
        width: 100%;
        height: 100%;
        top: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        background: rgba(0, 0, 0, 0.2);
        visibility: hidden;
      }
    }
  }
}
</style>
