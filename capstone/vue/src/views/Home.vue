<template>
  <div class="home">
    <home-hero/>
    <comic-list/>
  </div>
</template>

<script>
import HomeHero from '../components/HomeHero.vue';
import ComicList from '../components/ComicList.vue';

export default {
  components: { HomeHero, ComicList },
  name: "home"
};
</script>

<style>

</style>
