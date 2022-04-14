<template>
  <div class="collection-list">
    <div v-for="collection in collections" v-bind:key="collection.id"> 
            <p>{{collection.collectionId}} {{collection.collectionName}} {{collection.isPublic ? 'Private':'Public'}}</p>
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
        }
    },
    created(){
        localService.getCollection().then(response => {
                this.collections=response.data
                });
    },
}
</script>

<style>
.collection-list{
    background-color:white;
}

</style>