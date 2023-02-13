import Vue from "vue";
import VueRouter from "vue-router";
import MedicalRecordDetailRoutes from "./modules/medical-record";
import categoryRoutes from "./modules/category";
import pagesRoutes from "./modules/pages";
Vue.use(VueRouter);

const routes = [
  ...pagesRoutes,
  MedicalRecordDetailRoutes,
  categoryRoutes,
  {
    path: "/",
    redirect: "/benh-an",
  },
  {
    path: "*",
    redirect: "/404",
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
