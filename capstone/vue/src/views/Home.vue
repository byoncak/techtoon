<template>
  <div class="home">
    <home-hero/>
    <my-comics/>
  </div>
</template>

<script>
import HomeHero from '../components/HomeHero.vue';
// import ComicList from '../components/ComicList.vue';
import MyComics from '../components/MyComics.vue';

export default {
  components: { HomeHero, MyComics },
  name: "home"
};
</script>

<style>

</style>
