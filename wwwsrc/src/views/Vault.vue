<template>
  <div class="vault row justify-content-center container-fluid">
    <div class="card bg-primary col-11 text-center shadow-lg mt-4">
      <h1 class="mt-4 text-shadow text-light">{{vault[0] ? vault[0].name: ''}}</h1>
    </div>
    <vaultKeep class="row" v-for="keep in vaultkeep" :vaultKeepData="keep" :key="keep.id" />
  </div>
</template>


<script>
import vaultKeep from "../components/VaultKeepsComponent";
export default {
  name: "vault",
  mounted() {
    this.$store.dispatch("getVaultKeep", this.$route.params.vaultId);
  },
  data() {
    return {};
  },
  computed: {
    vaultkeep() {
      return this.$store.state.vaultKeeps;
    },
    vault() {
      return this.$store.state.vaults;
    },
  },
  methods: {},
  components: {
    vaultKeep,
  },
};
</script>


<style scoped>
.height {
  height: 75vh;
}
.shadow-lg {
  box-shadow: 0 1rem 1rem rgba(0, 0, 0, 0.616) !important;
}
.text-shadow {
  text-shadow: 0 0.5rem 0.5rem rgba(0, 0, 0, 0.616) !important;
}
</style>