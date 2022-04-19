<template>
  <div class="collection-list">
      <h1>My Collections</h1>
    <div class v-for="collection in collections" v-bind:key="collection.id"> 
        <router-link :to="{ name:'books-in-collection', params:{collectionId: collection.collectionId} }">
            <p>{{collection.collectionId}} {{collection.collectionName}} {{collection.isPublic ? 'Private':'Public'}}</p>
        </router-link>
    </div>
    <h1>Other Public Collections</h1>
    <div v-for="otherCollection in otherCollections" v-bind:key="otherCollection.id"> 
    <router-link :to="{ name:'books-in-collection', params:{collectionId: otherCollection.collectionId} }">
            <p>{{otherCollection.collectionId}} {{otherCollection.collectionName}} {{otherCollection.isPublic ? 'Private':'Public'}}</p>
    </router-link>
    </div>
    </div>
</template>

<script>
import localService from '@/services/LocalService';

export default {
    name:'collection-list',
    data(){
        return{
            collections: [],
            otherCollections:[]
        }
    },
    created(){
        localService.getCollection().then(response => {
                this.collections=response.data
                });
        localService.getPublicCollection().then(response => {
                this.otherCollections=response.data
                });
    },
        


}
</script>

<style>
.collection-list{
    background-color:white;
}

</style>