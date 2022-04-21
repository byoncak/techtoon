<template>
  <div>
      <div class="back-to-collection">
      <router-link :to="{ name:'collections' }"> Back to Collection </router-link>
      </div>
      <book-in-collection class="book-in-collection" v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
      
  </div>
</template>

<script>
import BookInCollection from '../components/BookInCollection.vue'
export default {
  components: { BookInCollection},
    name:'books-in-collection',


}
</script>

<style>
.back-to-collection{
background-color: white;
display: flex;
justify-content: center;
padding-top:2em;
padding-bottom: 1em;
}

.book-in-collection{
  background-color: white;
  padding-bottom: 2em;
  
}

</style>