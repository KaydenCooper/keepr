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
        <button class="btn btn-outline-info btn-block mx-1">Save Post</button>
      </div>
      <div v-else>
        <button class="btn btn-outline-info mx-1">Save Post</button>
        <button class="btn btn-outline-danger mx-1">Remove Post</button>
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
  },
  methods: {},
  components: {},
};
</script>


<style scoped>
.shadow-lg {
  box-shadow: 0 0.5rem 1.5rem rgba(0, 0, 0, 0.616) !important;
}
</style>