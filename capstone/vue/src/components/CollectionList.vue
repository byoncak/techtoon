<template>
  <div class="collection-list">
      <h1>My Collections</h1>
    <div class v-for="collection in collections" v-bind:key="collection.id"> 
        <router-link :to="{name:'books-in-collection', params:{collectionId: collection.collectionId}}">
            <p>{{collection.collectionId}} {{collection.collectionName}} {{collection.isPublic ? 'Private':'Public'}}</p>
            <p>{{getImage(collection.collectionId)}}</p>
        </router-link>
        
    </div>
    <!-- <div class v-for="image in images" v-bind:key="image.id">  -->
        <!-- <div class v-for="item in image" v-bind:key="item.key">
            <div class="cover-img-container">
                <img class="cover-img" :src="item.coverImage">
            </div>
        </div> -->
    <!-- </div>    -->
    <h1>Other Public Collections</h1>
    <div v-for="otherCollection in otherCollections" v-bind:key="otherCollection.id"> 
    <router-link :to="{ name:'public-comic-list', params:{collectionId: otherCollection.collectionId} }">
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
            otherCollections:[],
            images:[],
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
    methods:{
        getImage(id){
            localService.getCoverImage(id).then(response => {
                console.log(response.data)
                this.images=response.data;
                });
        },
    },
}

 
</script>

<style>
.collection-list{
    background-color:white;
}

</style>