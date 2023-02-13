const state = {
    dataChanDoan: {},
    tongKetRaVien:{},
    chanDoanYHHD: {},
  };
  const mutations = {
    SET_CHANDOAN(state, payload) {
      state.dataChanDoan = payload;
    },
    SET_TONGKETRAVIEN(state, payload) {
      state.tongKetRaVien = payload;
    },
    SET_CHANDOANYHHD(state, payload) {
      state.chanDoanYHHD = payload;
    },
  };
  const actions = {
    setChanDoan({ commit }, payload) {
      commit("SET_CHANDOAN", payload);
    },
    setTongKetRaVien({ commit }, payload) {
      commit("SET_TONGKETRAVIEN", payload);
    },
    setChanDoanYHHD({ commit }, payload) {
      commit("SET_CHANDOANYHHD", payload);
    },
  };
  export default {
    namespaced: true,
    state,
    mutations,
    actions,
  };
  