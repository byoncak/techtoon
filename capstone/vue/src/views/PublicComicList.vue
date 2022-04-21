<template>
  <div>
      <public-collection v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
      <div class="public-collection">
      <router-link :to="{ name:'collections' }"> Back to Collection </router-link>
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
.back-to-collection{
background-color: white;
}

</style>