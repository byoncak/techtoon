<template>
  <div class="home">
    <home-hero/>
    <h2> New Releases </h2>
    <comic-list/>
  </div>
</template>

<script>
import ComicList from '../components/ComicList.vue';
import HomeHero from '../components/HomeHero.vue';
// import ComicList from '../components/ComicList.vue';
// import MyComics from '../components/MyComics.vue';

export default {
  components: { HomeHero, ComicList },
  name: "home"
};
</script>

<style>

</style>
