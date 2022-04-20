<template>
  <div>
      <public-collection v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
      <div class="public-collection">
        <stats v-bind:collectionId="parseInt(this.$route.params.collectionId)"/>
      <router-link :to="{ name:'collections' }"> Back to Collection </router-link>
      </div>
  </div>
</template>

<script>
import PublicCollection from '../components/PublicCollection.vue'
import Stats from '../components/Stats.vue'

export default {
  components: { PublicCollection, Stats },
    name:'public-comic-list',


}
</script>

<style>
.back-to-collection{
background-color: white;
}

</style>