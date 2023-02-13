export default {
  path: "/benh-an",
  component: () => import("@/layouts/app/Index"),
  meta: {
    roles: [],
  },
  children: [
    {
      name: "Danh sách bệnh án",
      path: "/",
      meta: {
        roles: [],
      },
      component: () => import("@/views/app/benh-an/danh-sach/Index.vue"),
    },
    {
      name: "Hồ sơ bệnh án",
      path: ":id/ho-so-benh-an",
      meta: {
        roles: [],
        drawerContent: "MedicalRecordDetail",
      },
      component: () => import("@/views/app/benh-an/ho-so-benh-an/Index.vue"),
    },
    {
      name: "Phiếu khám bệnh vào viện",
      path: ":id/phieu-kham-benh-vao-vien",
      meta: {
        roles: [],
        drawerContent: "MedicalRecordDetail",
      },
      component: () =>
        import("@/views/app/benh-an/phieu-kham-benh-vao-vien/Index.vue"),
    },
    {
      name: "Phác đồ điều trị",
      path: ":id/phac-do-dieu-tri",
      meta: {
        roles: [],
        drawerContent: "MedicalRecordDetail",
      },
      component: () => import("@/views/app/benh-an/phac-do-dieu-tri/Index.vue"),
    },
    {
      name: "Thực hiện vật lý trị liệu",
      path: ":id/thuc-hien-vat-ly-tri-lieu",
      meta: {
        roles: [],
        drawerContent: "MedicalRecordDetail",
      },
      component: () => import("@/views/app/benh-an/thuc-hien-vat-ly-tri-lieu/Index.vue"),
    },
    {
      name: "Khoa điều trị",
      path: ":id/khoa-dieu-tri",
      meta: {
        roles: [],
        drawerContent: "MedicalRecordDetail",
      },
      component: () => import("@/views/app/benh-an/khoa-dieu-tri/Index.vue"),
    },
    // Thông tin ra viện
    {
      name: "Thông tin ra viện",
      path: ":id/thong-tin-ra-vien",
      meta: {
        roles: [],
        drawerContent: "MedicalRecordDetail",
      },
      component: () =>
        import("@/views/app/benh-an/thong-tin-ra-vien/Index.vue"),
    },
    {
      name: "Thông tin ra viện chi tiết",
      path: ":id/thong-tin-ra-vien/:id_details/details",
      meta: {
        roles: [],
        drawerContent: "MedicalRecord",
      },
      component: () =>
        import("@/views/app/benh-an/thong-tin-ra-vien/Details.vue"),
    },

    // Thông tin tử vong
    {
      name: "Thông tin tử vong",
      path: ":id/thong-tin-tu-vong",
      meta: {
        roles: [],
        drawerContent: "MedicalRecordDetail",
      },
      component: () =>
        import("@/views/app/benh-an/thong-tin-tu-vong/Index.vue"),
    },
    {
      name: "Thông tin tử vong",
      path: ":id/thong-tin-tu-vong",
      meta: {
        roles: [],
        drawerContent: "MedicalRecordDetail",
      },
      component: () =>
        import("@/views/app/benh-an/thong-tin-tu-vong/Index.vue"),
    },
  ],
};
