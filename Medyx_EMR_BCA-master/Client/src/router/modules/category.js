export default {
  path: "/danh-muc",
  component: () => import("@/layouts/app/Index"),
  meta: {
    roles: [],
  },

  children: [
    {
      name: "Danh mục bệnh tật",
      path: "benh-tat",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/benh-tat/benh-tat-table.vue"),
    },
    {
      name: "Danh mục bệnh tật YHCT",
      path: "benh-tat-yhct",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/benh-tat-yhct/benh-tat-yhct-table.vue"),
    },
    {
      name: "Danh mục chức danh",
      path: "chuc-danh",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/chuc-danh/chuc-danh-table.vue"),
    },
    {
      name: "Danh mục chức vụ",
      path: "chuc-vu",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/chuc-vu/chuc-vu-table.vue"),
    },
    {
      name: "Danh mục dân tộc",
      path: "dan-toc",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/dan-toc/dan-toc-table.vue"),
    },
    {
      name: "Danh mục khoa buồng",
      path: "khoa-buong",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/khoa-buong/khoa-buong-table.vue"),
    },
    {
      name: "Danh mục khoa",
      path: "khoa",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/khoa/khoa-table.vue"),
    },
    {
      name: "Danh mục khoa giường",
      path: "khoa-giuong",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/khoa-giuong/khoa-giuong-table.vue"),
    },
    {
      name: "Danh nhân viên",
      path: "nhan-vien",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/nhan-vien/nhan-vien-table.vue"),
    },
    {
      name: "Danh mục quoc-gia",
      path: "quoc-gia",
      meta: {
        roles: [],
        drawerContent: "Category",
      },
      component: () => import("@/views/app/danh-muc/quoc-gia/quoc-gia-table.vue"),
    },

    // chua dung
    // {
    //   name: "Danh mục chuyên khoa",
    //   path: "chuyen-khoa",
    //   meta: {
    //     roles: [],
    //     drawerContent: "Category",
    //   },
    //   component: () => import("@/views/app/danh-muc/chuyen-khoa/chuyen-khoa-table.vue"),
    // },
    // {
    //   name: "Danh mục chuyên môn",
    //   path: "chuyen-mon",
    //   meta: {
    //     roles: [],
    //     drawerContent: "Category",
    //   },
    //   component: () => import("@/views/app/danh-muc/chuyen-mon/chuyen-mon-table.vue"),
    // },
  ],
};
