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
    activeKeep: {},
    user: [],
    vaults: [],

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
    setVaults(state, vaults) {
      state.vaults = vaults
    },

  },
  actions: {

    async deletePost({ commit, dispatch }, id) {
      try {
        let res = await api.delete("keeps/" + id)
        router.push({ name: "dashboard" })
        commit("setUser", {})
      } catch (error) {
        console.log(error);
      }
    },

    async newPost({ commit, dispatch }, postData) {
      try {
        let res = await api.post("keeps", postData)
        dispatch("getUser")
      } catch (error) {
        console.log(error);
      }
    },

    async deleteBoard({ commit, dispatch }, id) {
      try {
        let res = await api.delete("vaults/" + id)
        commit("setVaults", {})
      } catch (error) {
        console.log(error);
      }
    },

    async newBoard({ commit, dispatch }, boardData) {
      try {
        let res = await api.post("vaults", boardData)
        dispatch("getVaults")
      } catch (error) {
        console.log(error);
      }
    },

    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults/user")
        // console.log(res.data);
        commit("setVaults", res.data)
      } catch (error) {
        console.log(error);
      }
    },

    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps")
        // console.log(res.data);
        commit("setKeeps", res.data)
      } catch (error) {
        console.log(error);
      }
    },
    async getUser({ commit }) {
      try {
        let res = await api.get("keeps/user")
        // console.log(res.data);
        commit("setUser", res.data)
      } catch (error) {
        console.log(error);
      }
    },

    async addToVault({ commit, dispatch }, vaultKeep) {
      try {
        let res = await api.post("vaultkeeps", vaultKeep)
        console.log(res.data);
      } catch (error) {
        console.log(error);
      }
    },
    async getVaultKeep({ commit, dispatch }) {
      try {
        let res = await api.get("vaultkeeps")
        console.log(res.data);
        commit("setVaults", res.data)
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
