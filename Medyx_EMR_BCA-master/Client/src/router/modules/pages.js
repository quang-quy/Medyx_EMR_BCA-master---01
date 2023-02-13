export default [
  {
    name: "Đăng nhập",
    path: "/dang-nhap",
    component: () => import("@/views/pages/Login"),
  },

  {
    name: "404",
    path: "/404",
    component: () => import("@/views/pages/404"),
  },
  {
    name: "403",
    path: "/403",
    component: () => import("@/views/pages/403"),
  },
  {
    path: "/logout",
    name: "Logout",
  },
];
