<template>
  <div class="keepDetails row justify-content-center text-dark container-fluid">
    <div class="col-4 card text-light bg-primary p-4 shadow-lg text-center my-3">
      <img class="img-fluid rounded" :src="activeKeep.img" alt />
      <h1 class="my-2 text-light">{{activeKeep.name}}</h1>
      <h3 class="my-2 text-light">{{activeKeep.description}}</h3>
      <span>
        <i class="fa fa-eye m-3">
          <b class="ml-2">{{activeKeep.views}}</b>
        </i>
        <i class="fa fa-share m-3">
          <b class="ml-2">{{activeKeep.shares}}</b>
        </i>
        <i class="fa fa-inbox m-3">
          <b class="ml-2">{{activeKeep.keeps}}</b>
        </i>
      </span>
      <div v-if="activeKeep.isPrivate == false">
        <div class="dropdown">
          <button
            class="btn btn-outline-info btn-block dropdown-toggle"
            type="button"
            id="dropdownMenuButton"
            data-toggle="dropdown"
            data-display="static"
            aria-haspopup="true"
            aria-expanded="false"
          >Save Post</button>
          <div class="dropdown-menu position p-3 shadow-lg" aria-labelledby="dropdownMenuButton">
            <div v-for="vault in vaults" :key="vault.id">
              <a class="dropdown-item" @click="saveToBoard(vault.id)">
                <h4>{{vault.name}}</h4>
              </a>
            </div>
          </div>
        </div>
      </div>
      <div v-else>
        <div class="dropdown">
          <button
            class="btn btn-outline-info btn-block dropdown-toggle"
            type="button"
            id="dropdownMenuButton"
            data-toggle="dropdown"
            data-display="static"
            aria-haspopup="true"
            aria-expanded="false"
          >Save Post</button>
          <div class="dropdown-menu position p-3 shadow-lg" aria-labelledby="dropdownMenuButton">
            <div v-for="vault in vaults" :key="vault.id">
              <a class="dropdown-item" @click="saveToBoard(vault.id)">
                <h4>{{vault.name}}</h4>
              </a>
            </div>
          </div>
        </div>
        <button
          class="btn btn-outline-danger btn-block mt-2"
          @click="deletePost(activeKeep.id)"
        >Remove Post</button>
      </div>
    </div>
  </div>
</template>


<script>
import Swal from "../components/SwalService.js";
export default {
  name: "keepDetails",
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.id);
    this.$store.dispatch("getVaults", this.$route.params.id);
  },
  data() {
    return {};
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    deletePost(id) {
      this.$store.dispatch("deletePost", this.activeKeep.id);
      Swal.toast("Deleted!", "");
    },

    saveToBoard(id) {
      this.$store.dispatch("addToBoard", {
        vaultId: id,
        keepId: this.activeKeep.id,
      });
      Swal.toast("Saved!", "");
    },
  },
  components: {},
};
</script>


<style scoped>
.shadow-lg {
  box-shadow: 0 0.5rem 1.5rem rgba(0, 0, 0, 0.616) !important;
}

.position:active,
.position {
  position: absolute;
  will-change: transform;
  top: 290px;
  left: 100px;
  transform: translate3d(0px, -237px, 0px);
}
</style>