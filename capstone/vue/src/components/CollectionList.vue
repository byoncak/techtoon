<template>
  <div class="collection-list">
      <h1 class="my-collection-title">My Collections</h1>
      <div class="my-collections">
    <div class="list" v-for="collection in collections" v-bind:key="collection.id"> 
        <div class="collections">
        <router-link class="link" :to="{ name:'books-in-collection', params:{collectionId: collection.collectionId} }">
            <p>{{collection.collectionName}} | {{collection.isPublic ? 'Private':'Public'}}</p>
        </router-link>
    </div>
    </div>
    </div>
    <h1>Other Public Collections</h1>
    <div v-for="otherCollection in otherCollections" v-bind:key="otherCollection.id"> 
    <router-link class="link" :to="{ name:'public-comic-list', params:{collectionId: otherCollection.collectionId} }">
            <p>{{otherCollection.collectionId}} | {{otherCollection.collectionName}} {{otherCollection.isPublic ? 'Private':'Public'}}</p>
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
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.collections{
    display: flex;
    justify-content: center;
    align-content: center;
    height:360px;
    width:240px;
    margin-right: 2em;
    background-color: blueviolet;
    margin-bottom: 1em;
    margin-top: 1em;
    cursor: pointer;
    border-radius: .8em;
}
.list{

}

.link{
    backgroud-color:white;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 800;
    font-size:20px;
    justify-content: center;
    align-items: center;
    margin-top:2.4em;
    display: flex;
}

.my-collections{
    display: flex;
    flex-direction: row;

}

.collection-list{
    background-color:white;
}

.my-collection-title{
    display: flex;
    margin-bottom: .4em;
}
</style>