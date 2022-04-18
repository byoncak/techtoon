<template>
  <div class="home">
    <home-hero/>
  <div class="new-releases">
  New Releases 
  </div>
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


.new-releases {
  font-size:2vw;
  font-weight: 600;
  margin-top: 2em;
  padding-top:1em;
  background-color: white;
  display:flex;
  justify-content: center;
  font-family: Arial, Helvetica, sans-serif;

}
</style>
