<template>
  <div>
      <div class="back-to-collection">
      <router-link :to="{ name:'collections' }"> Back to Collection </router-link>
      </div>
      <book-in-collection v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
      <stats v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
  </div>
</template>

<script>
import BookInCollection from '../components/BookInCollection.vue'
import Stats from '../components/Stats.vue'
export default {
  components: { BookInCollection, Stats },
    name:'books-in-collection',


}
</script>

<style>
.back-to-collection{
background-color: white;
}

</style>