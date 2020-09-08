<template>
  <div class="keepDetails row justify-content-center text-dark container-fluid">
    <div class="col-4 card p-4 shadow-lg text-center my-3">
      <img :src="activeKeep.img" alt />
      <h3 class="my-2">{{activeKeep.name}}</h3>
      <p class="my-2">{{activeKeep.description}}</p>
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
            aria-haspopup="true"
            aria-expanded="false"
          >Save Post</button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <a class="dropdown-item" href="#">
              <h4>{{vaults}}</h4>
            </a>
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
            aria-haspopup="true"
            aria-expanded="false"
          >Save Post</button>
          <div class="dropdown-menu text-primary" aria-labelledby="dropdownMenuButton">
            <a class="dropdown-item" href="#">Action</a>
            <a class="dropdown-item" href="#">Another action</a>
            <a class="dropdown-item" href="#">Something else here</a>
          </div>
        </div>
        <button class="btn btn-outline-danger" @click="deletePost(activeKeep.id)">Remove Post</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keepDetails",
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.id);
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