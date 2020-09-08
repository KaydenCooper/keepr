<template>
  <div class="vault row justify-content-center">
    <div class="card bg-primary col-10 height text-center shadow-lg mt-4">
      <h1 class="mt-4 text-shadow text-light">{{vault[0] ? vault[0].name: ''}}</h1>
      <!-- <savedPosts v-for="keeps in savedKeeps" :savedKeepData="keeps" :key="keeps.id" /> -->
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  mounted() {
    this.$store.dispatch("getVaults");
  },
  data() {
    return {};
  },
  computed: {
    vault() {
      return this.$store.state.vaults;
    },
  },
  methods: {},
  components: {},
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