<template>
  <div class="collection-list">
      <!-- <h1 class="my-collection-title">My Collections</h1>
      <div class="my-collections">
    <div class="list" v-for="collection in collections" v-bind:key="collection.id"> 
        <div class="collections">
        <router-link class="link" :to="{ name:'books-in-collection', params:{collectionId: collection.collectionId} }">
            <p>{{collection.collectionName}}</p> 
            <p>{{collection.isPublic ? 'Private':'Public'}}</p>
        </router-link>
    </div>
    </div>
    </div>
    <h1>Other Public Collections</h1>
    <div v-for="otherCollection in otherCollections" v-bind:key="otherCollection.id"> 
    <router-link class="link" :to="{ name:'public-comic-list', params:{collectionId: otherCollection.collectionId} }">
            <p>{{otherCollection.collectionId}} | {{otherCollection.collectionName}} {{otherCollection.isPublic ? 'Private':'Public'}}</p>
    </router-link>
    </div> -->
    <div class="comic-list-page-1">
        <h1 class="my-collection-title">My Collections</h1>
        <div class="comic-list-container-1">
      <div class="comic-list-1" v-for="collection in collections" v-bind:key="collection.id"> 
          <router-link :to="{ name:'books-in-collection', params:{collectionId: collection.collectionId} }">
        <div class="comic-card-1">
            <div class="cover-img-container-1">
                <img class="cover-img-1"  :src="randomImage()"/>
            </div>
            <div class="title-block-1">
                <h5 class="comic-title-1">{{collection.collectionName}} | {{collection.isPublic ? 'Private':'Public'}}</h5>
            </div>
        </div>
        </router-link>
        </div>
    </div>
    <h1 class="my-collection-title">Other Public Collections</h1>
        <div class="comic-list-container-1">
      <div class="comic-list-1" v-for="otherCollection in otherCollections" v-bind:key="otherCollection.id"> 
          <router-link :to="{ name:'public-comic-list', params:{collectionId: otherCollection.collectionId} }">
        <div class="comic-card-1">
            <div class="cover-img-container-1">
                <img class="cover-img-1" :src="randomImage()"/>
            </div>
            <div class="title-block-1">
                <p class="comic-title-1">{{otherCollection.collectionName}} | {{otherCollection.isPublic ? 'Private':'Public'}}</p>
            </div>
        </div>
        </router-link>
        </div>
    </div>

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
            images:[
                require('@/assets/CoverImage/1.jpg'),
                require('@/assets/CoverImage/2.png'),
                require('@/assets/CoverImage/3.jpg'),
                require('@/assets/CoverImage/4.jpg'),
                require('@/assets/CoverImage/5.jpg'),
                require('@/assets/CoverImage/6.jpg'),
                require('@/assets/CoverImage/7.jpg'),
                require('@/assets/CoverImage/8.jpg'),
                require('@/assets/CoverImage/9.jpg'),
            ],
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
    methods: {
         randomImage() {
            return this.images[Math.floor(Math.random() * this.images.length)];
        },
    },
        


}
</script>

<style>
.comic-list-page-1 {
    background-color: white;
}


.comic-list-container-1{
    display: flex;
    margin-left:12vw;
    margin-right: 12vw;
    flex-wrap: wrap;
    justify-content: center;
}

.comic-list-1 {
    display: flex;
    justify-content: flex-start;
}
.cover-img-container-1{
    position: relative;
    display: flex;
    cursor: pointer;
    z-index: 1;
    margin-top:0em;
    max-width: 260px;
    height: 320px;
    width: 290px;
    margin-bottom: -3em;
    justify-content: flex-start;
    transition: all 1s;
    transform-style: preserve-3d;
    perspective: 1000px;
}

.cover-img-1{
    transition: margin .3s ease-in-out;
    border-radius: 4.8px;
    box-shadow: 2px 4px 12px 0px rgba(0, 0, 0, .4);
    backface-visibility: hidden;
}

.cover-img-1.active,
.cover-img:hover {
    transition: margin .3s ease-in-out;
    margin-bottom: .4em;
    margin-top: -.4em;
}

.comic-card-1 {
  align-content: flex-start;
  justify-content: flex-start;
  font-size: 1.5rem;
  margin-right: -.4em;
  z-index: 1;
  margin-top: 2em;
  margin-bottom: -3em;
  perspective: 800px;
  transition: all 0.4s ease 0s;
  position:relative;
  width: 100%;
  height: 100%;
}

.title-block-1 {
    z-index: 0;
    display: flex;
    margin-top: 2.4em;
}



.comic-title-1 {
    margin-top: 2.4em;
    align-content: flex-start;
    flex-wrap: wrap;
    color: black;
    font-family: Arial, Helvetica, sans-serif;
    font-size: .80rem;
    font-weight: 800;
    cursor: pointer;
    max-width: 220px;
    z-index: 0;
}

/*------------*/

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

.link .p{
    color:black;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 800;
    font-size:19px;
    justify-content: center;
    align-items: end;
    margin-top:26em;
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