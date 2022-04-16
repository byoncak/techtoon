<template>
  <div>
      <book-in-collection v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
      <div class=link>
      <router-link :to="{ name:'collections' }"> Back to Collection </router-link>
      </div>
  </div>
</template>

<script>
import BookInCollection from '../components/BookInCollection.vue'
export default {
  components: { BookInCollection },
    name:'book-in-collection',


}
</script>

<style>
.link{
    background-color:white;
}

</style>