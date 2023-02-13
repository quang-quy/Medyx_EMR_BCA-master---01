const state = {
  loader: false,
};
const mutations = {
  SET_LOADER(state, payload) {
    state.loader = payload;
  },
};
const actions = {
  setLoader({ commit }, payload) {
    commit("SET_LOADER", payload);
  },
};
export default {
  namespaced: true,
  state,
  mutations,
  actions,
};
