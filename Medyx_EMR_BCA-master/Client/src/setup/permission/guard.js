import router from "../../router/index";
import store from "../../store/index";
import NProgress from "nprogress";
import "nprogress/nprogress.css";
import { getAuth } from "@/utils/auth";
import getPageTitle from "@/utils/get-page-title";
import roleList from "./roles";
NProgress.configure({ showSpinner: false });

const commonRoutes = ["403", "404"];

router.beforeEach(async (to, _from, next) => {
  NProgress.start();
  document.title = getPageTitle(to.name);
  if (commonRoutes.includes(to.name)) return next();
  const isAuth = getAuth();

  if (isAuth) {
    if (to.name === "Logout") {
      await store.dispatch("auth/logout");
      return next({ name: "Login" });
    }
    if (to.name === "Đăng nhập") {
      next("/");
    }
    const roles =
      store?.state?.auth?.user?.roles ||
      (await store.dispatch("auth/getInfo")).roles;

    if (to.path === "/") {
      const role = roleList.find((r) => r.key === roles[0]);
      next(role.homeUrl);
    }
    if (
      !to.meta.roles ||
      to.meta.roles.length === 0 ||
      to.meta.roles.some((role) => roles && roles.includes(role))
    ) {
      next();
    } else next("/404");
  } else {
    if (to.name === "Đăng nhập") next();
    else next("/dang-nhap");
  }
});

router.afterEach(() => {
  NProgress.done();
});
