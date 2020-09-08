<template>
  <div class="home row justify-content-center py-2 container-fluid">
    <div class="col-12 text-center mt-4">
      <h1>
        <u class="text-shadow">Welcome To Keepr</u>
      </h1>
    </div>
    <keeps class="row" v-for="keep in publicKeeps" :keepData="keep" :key="keep.id" />
  </div>
</template>

<script>
import Keeps from "../components/keepsComponent";

export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
  components: {
    Keeps,
  },
};
</script>

<style scoped>
.text-shadow {
  text-shadow: 0 0.25rem 0.5rem rgba(0, 0, 0, 0.616) !important;
}
</style>
