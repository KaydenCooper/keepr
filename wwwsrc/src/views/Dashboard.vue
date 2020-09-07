<template>
  <div class="dashboard row justify-content-center container-fluid mt-4">
    <div class="col-6 text-center">
      <button class="btn btn-primary btn-block shadow-lg">
        <h5 class="text-light mb-0">Create A Post</h5>
      </button>
      <h1 class="mt-4">
        <u>My Posts</u>
      </h1>
      <myKeepsComponent v-for="keep in activeKeep" :myKeepData="keep" :key="keep.id" />
    </div>
    <div class="col-6 text-center">
      <button class="btn btn-primary btn-block shadow-lg">
        <h5 class="text-light mb-0">Create A Board</h5>
      </button>
      <h1 class="mt-4">
        <u>My Boards</u>
      </h1>
    </div>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
import MyKeeps from "../components/MyKeepsComponent";
export default {
  mounted() {
    // debugger;
    this.$store.dispatch("getUser");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    activeKeep() {
      return this.$store.state.activeKeep;
    },
  },
  components: {
    MyKeeps,
  },
};
</script>

<style scoped>
.shadow-lg {
  box-shadow: 0 1rem 1rem rgba(0, 0, 0, 0.616) !important;
}
</style>
