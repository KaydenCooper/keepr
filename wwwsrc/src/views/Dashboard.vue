<template>
  <div class="dashboard row justify-content-center container-fluid mt-4">
    <div class="col-12">
      <button
        class="btn btn-primary btn-block mb-2 shadow-lg"
        type="button"
        data-toggle="collapse"
        data-target=".multi-collapse"
        aria-expanded="false"
        aria-controls="multiCollapseExample1 multiCollapseExample2"
      >Create New Post/Board</button>
    </div>
    <div class="col-6 text-center">
      <div id="multiCollapseExample1" class="collapse multi-collapse">
        <div class="card bg-primary shadow-lg">
          <form class="p-4" @submit.prevent="newPost">
            <div class="form-group">
              <input
                v-model="createPost.name"
                type="text"
                class="form-control"
                placeholder="Enter Name..."
              />
            </div>
            <div class="form-group">
              <input
                v-model="createPost.description"
                type="text"
                class="form-control"
                placeholder="Enter Description..."
              />
            </div>
            <div class="form-group">
              <input
                v-model="createPost.img"
                type="text"
                class="form-control"
                placeholder="Enter Img..."
              />
            </div>
            <div class="form-group form-check">
              <label
                class="form-check-label text-light"
                for="exampleCheck1"
              >Want To Make It Private?</label>
              <br />
              <input v-model="createPost.isPrivate" type="checkbox" class="form-check-input" />
            </div>
            <button class="btn btn-primary btn-block border border-secondary shadow-lg mt-4">
              <h5 class="text-light mb-0">Create A Post</h5>
            </button>
          </form>
        </div>
      </div>
      <h1 class="mt-4">
        <u class="text-shadow">My Posts</u>
      </h1>

      <myKeepsComponent v-for="user in user" :myKeepData="user" :key="user.id" />
    </div>
    <div class="col-6 text-center">
      <div id="multiCollapseExample2" class="collapse multi-collapse">
        <div class="card bg-primary shadow-lg">
          <form class="p-4" @submit.prevent="newBoard">
            <div class="form-group">
              <input
                v-model="createBoard.name"
                type="text"
                class="form-control"
                placeholder="Enter Name..."
              />
            </div>
            <div class="form-group">
              <input
                v-model="createBoard.description"
                type="text"
                class="form-control"
                placeholder="Enter Description..."
              />
            </div>
            <div class="form-group mb-5">
              <input
                v-model="createBoard.img"
                type="text"
                class="form-control"
                placeholder="Enter Img..."
              />
            </div>
            <button class="btn btn-primary btn-block border border-secondary shadow-lg mt-4">
              <h5 class="text-light mb-0">Create A Board</h5>
            </button>
          </form>
        </div>
      </div>
      <h1 class="mt-4">
        <u class="text-shadow">My Boards</u>
      </h1>

      <vaultsComponent v-for="vault in vaults" :vaultData="vault" :key="vault.id" />
    </div>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
import MyKeepsComponent from "../components/MyKeepsComponent";
import VaultsComponent from "../components/VaultsComponent";
export default {
  data() {
    return {
      createBoard: {},
      createPost: {},
    };
  },
  mounted() {
    // debugger;
    this.$store.dispatch("getUser", this.user.id);
    this.$store.dispatch("getVaults", this.user.id);
    // this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    newBoard() {
      this.$store.dispatch("newBoard", this.createBoard);
      this.createBoard = {};
    },
    newPost() {
      this.$store.dispatch("newPost", this.createPost);
      this.createPost = {};
    },
  },
  components: {
    MyKeepsComponent,
    VaultsComponent,
  },
};
</script>

<style scoped>
.shadow-lg {
  box-shadow: 0 1rem 1rem rgba(0, 0, 0, 0.616) !important;
}
.text-shadow {
  text-shadow: 0 0.5rem 0.5rem rgba(0, 0, 0, 0.616) !important;
}
</style>
