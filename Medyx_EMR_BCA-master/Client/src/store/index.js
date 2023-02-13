import Vue from "vue";
import Vuex from "vuex";
import getters from "./getters";
import auth from "./modules/auth";
import app from "./modules/app";
import hosobenhan from "./modules/hosobenhan";

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    app,
    auth,
    hosobenhan
  },
  getters,
});

export default store;
