<template>
  <div class="card myKeepsComponent col-12 col-md-2 m-3 px-0 shadow-lg text-center">
    <img :src="myKeepData.img" class="card-img-top" alt="..." />
    <div class="card-body py-1 text-wrap text-break">
      <span>
        <i class="fa fa-eye m-3">
          <b class="ml-2">{{myKeepData.views}}</b>
        </i>
        <i class="fa fa-share m-3">
          <b class="ml-2">{{myKeepData.shares}}</b>
        </i>
        <i class="fa fa-inbox m-3">
          <b class="ml-2">{{myKeepData.keeps}}</b>
        </i>
      </span>
      <h4 class="card-title">{{myKeepData.name}}</h4>
      <p class="card-text">{{myKeepData.description}}</p>
      <button
        type="button"
        class="btn btn-outline-primary btn-block py-1 mb-2"
        @click="keepDetails(myKeepData.id)"
      >See Pin Details...</button>
    </div>
  </div>
</template>


<script>
export default {
  name: "myKeepsComponent",
  props: ["myKeepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    keepDetails(id) {
      this.$router.push({ name: "keepDetails", params: { id: id } });
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