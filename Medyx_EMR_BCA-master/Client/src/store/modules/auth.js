import { login, logout, getInfo } from "@/api/user";
import { getAuth, setAuth } from "@/utils/auth";

const state = {
  auth: getAuth(),
  user: null,
};

const mutations = {
  SET_AUTH: (state, payload) => {
    state.auth = payload;
    setAuth(payload);
  },
  SET_USER: (state, user) => {
    state.user = user;
  },
};

const actions = {
  login({ commit }, userInfo) {
    const { username, password } = userInfo;
    return new Promise((resolve, reject) => {
      login({ username, password })
        .then((_res) => {
          commit("SET_AUTH", true);
          resolve();
        })
        .catch((error) => {
          reject(error);
        });
    });
  },

  getInfo({ commit }) {
    return new Promise((resolve, reject) => {
      getInfo()
        .then((response) => {
          const { data } = response;
          if (!data) {
            reject("Verification failed, please Login again.");
          }
          commit("SET_USER", {
            id: data.pub_sNguoiSD,
            username: data.pub_sAccount,
            name: data.pub_sTenNguoiSD,
            roles: ["admin"],
          });
          resolve(data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  },

  // user logout
  logout({ commit }) {
    return new Promise((resolve, reject) => {
      logout()
        .then(() => {
          commit("SET_AUTH", false);
          resolve();
        })
        .catch((error) => {
          reject(error);
        });
    });
  },

  // remove auth
  removeAuth({ commit }) {
    return new Promise((resolve) => {
      commit("SET_AUTH", false);
      resolve();
    });
  },
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
};
