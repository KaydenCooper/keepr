<template>
  <div class="card keepsComponent col-12 col-md-2 m-3 px-0 shadow-lg text-center">
    <img :src="keepData.img" class="card-img-top" alt="..." />
    <div class="card-body py-1 text-wrap text-break">
      <span>
        <i class="fa fa-eye m-3">
          <b class="ml-2">{{keepData.views}}</b>
        </i>
        <i class="fa fa-share m-3">
          <b class="ml-2">{{keepData.shares}}</b>
        </i>
        <i class="fa fa-inbox m-3">
          <b class="ml-2">{{keepData.keeps}}</b>
        </i>
      </span>
      <h4 class="card-title">{{keepData.name}}</h4>
      <p class="card-text">{{keepData.description}}</p>
      <button
        type="button"
        class="btn btn-outline-primary btn-block py-1 mb-2"
        @click="keepDetails(keepData.id)"
      >See Pin Details...</button>
    </div>
  </div>
</template>


<script>
export default {
  name: "keepsComponent",
  props: ["keepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    keepDetails(id) {
      this.keepData.views++;
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