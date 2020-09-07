import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    privateKeeps: [],
    activeKeep: {},
    user: {},
    vaults: []

  },
  mutations: {
    setKeeps(state, keeps) {
      state.publicKeeps = keeps
    },
    setUser(state, user) {
      state.user = user
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    },
    setPrivateKeep(state, privateKeep) {
      state.privateKeeps = privateKeep
    }

  },
  actions: {
    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps")
        console.log(res.data);
        commit("setKeeps", res.data)
      } catch (error) {
        console.log(error);
      }
    },
    async getUser({ commit }) {
      try {
        let res = await api.get("keeps/" + "user")
        console.log(res.data);
        commit("setUser", res.data)
      } catch (error) {
        console.log(error);
      }
    },

    async getActiveKeep({ commit, dispatch }, keepId) {
      try {
        let res = await api.get("keeps/" + keepId)
        commit("setActiveKeep", res.data)
      } catch (error) {
        console.log(error);
      }
    },


    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    }
  }
});
