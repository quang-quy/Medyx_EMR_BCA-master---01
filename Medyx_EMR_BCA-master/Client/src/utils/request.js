import axios from "axios";
import store from "@/store";
import Vue from "vue";
import localforage from "localforage";

const request = async (config) => {
  if (!config.cache) return service(config);
  const url = axios.getUri(config);
  const cachedData = await localforage.getItem(url);
  if (cachedData) return cachedData;
  const data = await service(config);
  await localforage.setItem(url, data);
  return data;
};

const service = axios.create({
  baseURL: "/api",
  withCredentials: true,
  timeout: 60000,
});

service.interceptors.request.use(
  (config) => {
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

service.interceptors.response.use(
  (response) => {
    return response.data;
  },
  (error, a, b, c) => {
    const vue = new Vue();
    switch (error.response.status) {
      case 401:
        vue.$message.error("Hết phiên đăng nhập");
        store.dispatch("auth/removeAuth").then(() => {
          location.reload();
        });
        break;
      case 403:
        vue.$message.error(error.response.data.Error);
        break;
      case 404:
        router.push("/404");
        break;
      case 400:
        let quantityError = Object.keys(error.response.data.errors).length;
        if (quantityError <= 1) {
          vue.$message.error(
            error.response.data.errors[
              Object.keys(error.response.data.errors)[0]
            ][0]
          );
        } else {
          for (let index = 0; index < quantityError; index++) {
            setTimeout((e) => {
              vue.$message.error(
                error.response.data.errors[
                  Object.keys(error.response.data.errors)[index]
                ][0]
              );
            }, 200);
          }
        }
        break;

      default:
        if (error.response.data.errors) {
          return vue.$message.error(
            error.response.data.errors[
              Object.keys(error.response.data.errors)[0]
            ][0]
          );
        }
        break;
    }

    return Promise.reject(error);
  }
);

export default request;
