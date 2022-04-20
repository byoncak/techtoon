<template>
  <div>
      <div class="back-to-collection">
      <router-link :to="{ name:'collections' }"> Back to Collection </router-link>
      </div>
      <book-in-collection v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
  </div>
</template>

<script>
import BookInCollection from '../components/BookInCollection.vue'
export default {
  components: { BookInCollection },
    name:'books-in-collection',


}
</script>

<style>
.back-to-collection{
background-color: white;
}

</style>