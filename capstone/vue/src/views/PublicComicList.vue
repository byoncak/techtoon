<template>
  <div class="pub">
    <router-link class="back-to" :to="{ name:'collections' }"> Back to Collection </router-link>
      <public-collection v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
      <div class="public-collection">
      </div>
  </div>
</template>

<script>
import PublicCollection from '../components/PublicCollection.vue'

export default {
  components: { PublicCollection},
    name:'public-comic-list',


}
</script>

<style>

.back-to{
  display: flex;
  justify-content: left;
  padding: 2em;
}

.pub{
  background-color: white;
}

.back-to-collection{
background-color: white;
}

</style>