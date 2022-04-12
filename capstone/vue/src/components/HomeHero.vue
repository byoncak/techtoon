<template>
  <div class="home-hero">
    <h1>MyComics.app</h1>
    <button class="btn searchComics" v-on:click="searchComics">Search for Comic</button>
    <button class="btn browseCollections" v-on:click="browseCollections">Browse Collections</button>
  </div>
</template>

<script>
export default {
  name: "home-hero"
};
</script>

<style>

</style>