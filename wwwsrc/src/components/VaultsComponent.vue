<template>
  <div class="vaultsComponent row justify-content-center">
    <div class="card col-8 m-3 p-2 shadow-lg bg-primary text-light text-center">
      <div class="card-body py-1 text-wrap text-break">
        <router-link :to="{name: 'vault', params: {vaultId: vaultData.id}}">
          <h4 class="card-title text-light">{{vaultData.name}}</h4>
          <p class="card-text text-light mb-2">{{vaultData.description}}</p>
        </router-link>
        <button
          class="btn btn-outline-danger btn-block py-0"
          @click="deleteBoard(vaultData.id)"
        >Delete Board</button>
      </div>
    </div>
  </div>
</template>


<script>
import Swal from "../components/SwalService.js";
export default {
  name: "vaultsComponent",
  props: ["vaultData"],
  mounted() {
    this.$store.dispatch("getVaults");
  },
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteBoard(id) {
      this.$store.dispatch("deleteBoard", this.vaultData.id);
      Swal.toast("Deleted!", "");
    },
  },
  components: {},
};
</script>


<style scoped>
.shadow-lg {
  box-shadow: 0 0.5rem 1.5rem rgba(0, 0, 0, 0.616) !important;
}
</style>