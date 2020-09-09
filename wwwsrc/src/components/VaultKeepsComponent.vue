<template>
  <div
    class="card vaultKeepsComponent col-12 col-md-2 m-3 px-0 shadow-lg bg-primary text-light text-center"
  >
    <img :src="vaultKeepData.img" class="card-img-top" alt="..." />
    <div class="card-body py-1 text-wrap text-break">
      <span>
        <i class="fa fa-eye m-3">
          <b class="ml-2">{{vaultKeepData.views}}</b>
        </i>
        <i class="fa fa-share m-3">
          <b class="ml-2">{{vaultKeepData.shares}}</b>
        </i>
        <i class="fa fa-inbox m-3">
          <b class="ml-2">{{vaultKeepData.keeps}}</b>
        </i>
      </span>
      <h4 class="card-title">{{vaultKeepData.name}}</h4>
      <p class="card-text">{{vaultKeepData.description}}</p>
      <button
        type="button"
        class="btn btn-outline-light btn-block py-0 mb-2"
        @click="keepDetails(vaultKeepData.id)"
      >See Pin Details...</button>
      <button
        type="button"
        class="btn btn-outline-danger btn-block py-0 mb-2"
        @click="removePost(vaultKeepData.vaultKeepId)"
      >Remove Post</button>
    </div>
  </div>
</template>


<script>
import Swal from "../components/SwalService.js";
export default {
  name: "vaultKeepsComponent",
  props: ["vaultKeepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    keepDetails(id) {
      this.$router.push({ name: "keepDetails", params: { id: id } });
    },
    removePost(id) {
      this.$store.dispatch("removeVaultKeep", id);
      // Swal.toast("Removed!", "");
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