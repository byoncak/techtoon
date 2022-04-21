<template>
<div class="book">
 <div class="comic-list-container">
      <div class="comic-list" v-for="comic in books" v-bind:key="comic.id" > 
        <div class="comic-card">
            <div class="comic-card__face comic-card__front" >
            <div class="cover-img-container public" :id="comic.coverImage" v-bind:key="comic.id" v-on:click="flipComic(comic.coverImage)">
                <img class="cover-img" :src="comic.coverImage" :id="comic.coverImage">
            </div>
            <div class="comic-card__face comic-card__back" v-bind:key="comic.id" v-on:click="flipComic(comic.coverImage)">
            <div class="title-block">
                <h3 class="comic-title">{{comic.title.split('(').shift()}}</h3>
                <h3 class="comic-title">{{comic.title.split(')').pop()}}</h3> 
            </div>
            </div>
        </div>
        </div>
    </div>
      <div class="stat-container">
        <div class="stat-columns">
        <h4 class="stat-title">Collection Stats:</h4>
        <div class="stat-leaders-container">
        <div class="stat-leaders" v-for="character in characters" v-bind:key="character.id">
        <div class="stat-leader-stats">
            <p class="stat-leaders" id="stat-leader-name">{{character.name}}</p> <p class="stat-leaders"> {{character.issueCount}}</p>
           </div>
        </div>
        </div>
        <p class="stat-leaders">Total Number of book in this Collection: </p><p class="stat-leaders">{{totalComic.totalComicCount}}</p>
        </div>
    </div>
    </div>



    </div>
    
    <!-- <div class="leaderboard-container">
        <div class="columns">
        <h4 class="leaderboard-title">Statistics:</h4>
        <div class="leaders-container">
        <div class="leaders" v-for="character in characters" v-bind:key="character.id">
        <div class="leader-stats">
            <p class="leaders" id="leader-name">{{character.name}}</p> <p class="leaders"> {{character.issueCount}}</p>
           </div>
        </div>
        </div>
        <p>Total Number of book in this Collection: {{totalComic.totalComicCount}}</p>
        </div>
    </div> -->
</template>

<script>
import localService from '@/services/LocalService';
export default {
    name:"PublicCollection",
    props:['collectionId'],
    data(){
        return{
            books:[],
            characters:[],
            totalComic:''
        }
    },
    created(){
        localService.getCollectionById(this.collectionId).then(response =>{
                this.books=response.data;
            });
        localService.getComicStatCharacter(this.collectionId).then(response =>{
                this.characters=response.data;
            });
        localService.getComicTotalInCollection(this.collectionId).then(response =>{
                this.totalComic=response.data;
            });
    },
    methods:{
        flipComic(comicId){
            let thisComic = document.getElementById(comicId);
            thisComic.classList.toggle("isFlipped");
        },

        deleteComic(book) {
            localService.deleteComicFromCollection(this.collectionId,book.comicId).then(response=>{
                if(response.status==200){
                    localService.getCollectionById(this.collectionId).then(response =>{
                    this.books=response.data;
                    });
                    localService.getComicStatCharacter(this.collectionId).then(response =>{
                    this.characters=response.data;
                    });
                    localService.getComicTotalInCollection(this.collectionId).then(response =>{
                    this.totalComic=response.data;
                    });
                }
            })
            .catch(error => {
            if(error.response){
                    alert("Error submitting. Error code:"+error.response.status);
                }
            else if(error.request) {
              alert("Error submitting. Server could not be reached.");
            }
            else {
              alert("Error submitting. Request could not be created.");
            }
            });
        }
    }
}
</script>

<style>
.book{
    background-color:white;
}

.stats{
    display: flex;
    flex-direction: column;
    width: 300px;
}

.cover-image-container.public{
    padding-top: 2em;
}





</style>