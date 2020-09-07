<template>
  <div class="home row justify-content-center py-2">
    <div class="col-12 text-center">
      <h1>
        <u>Welcome To Keepr</u>
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
