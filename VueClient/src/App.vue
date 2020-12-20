<template>
  <div class="alert alert-info mt-5" v-if="isLoading">Yükleniyor</div>
  <div v-else>
    <table class="table table-striped table-hover">
      <thead>
        <tr>
          <th>Ürün Kodu</th>
          <th>Adı</th>
          <th>Fiyatı</th>
          <th>Stok</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="p in products" :key="p.id">
          <td>{{ p.id }}</td>
          <td>{{ p.name }}</td>
          <td>{{ p.price }}</td>
          <td>{{ p.stock }}</td>
        </tr>
      </tbody>
    </table>
    <div class="float-right">
      <button
        class="btn btn-secondary mr-2"
        v-on:click="previous"
        :disabled="isPreviousDisabled"
      >
        &lt;&lt;
      </button>
      <button
        class="btn btn-secondary"
        v-on:click="next"
        :disabled="isNextDisabled"
      >
        &gt;&gt;
      </button>
    </div>
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";
import axios from "axios";

export default {
  name: "App",
  components: {
    HelloWorld,
  },
  data: () => ({
    products: [],
    showNext: true,
    isLoading: false,
    pageNumber: 1,
    count: 10,
    listUrl: "https://localhost:5001/api/product/list",
  }),
  computed: {
    isPreviousDisabled: function () {
      return this.pageNumber == 1;
    },
    isNextDisabled: function () {
      return this.products.length < 10;
    },
  },
  methods: {
    previous() {
      this.pageNumber--;
      this.load();
    },
    next() {
      this.pageNumber++;
      this.load();
    },
    load() {
      var self = this;
      self.isLoading = true;
      setTimeout(function () {
        axios
          .get(
            self.listUrl + "?page=" + self.pageNumber + "&count=" + self.count
          )
          .then(function (response) {
            self.products = response.data;
            self.isLoading = false;
          });
      }, 1000);
    },
  },
  mounted: function () {
    this.load();
  },
};
</script>
