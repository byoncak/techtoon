<template>
<div class='book'>
    <div class="comic-list-container">  
        <div class="comic-list" v-for="book in books" v-bind:key="book.id">
            <div class="comic-card">
                <div class="cover-img-container">
                        <img class="cover-img" :src="book.coverImage">
                </div>
                <div class="circle-btn-container" >
                        <button v-on:click='deleteComic(book)' class="circle-btn" style="border-radius:100%;">
                        <span class="circle-btn-content">-</span>
                        </button>
                </div>
                <div class="title-block">
                    <p class="comic-title">{{book.title}}</p>
                </div>
            </div>
        </div>
    </div>
    <div class="stats">
        <h4>Statistics:</h4>
        <div class="character" v-for="character in characters" v-bind:key="character.id">
        <p>{{character.name}}: {{character.issueCount}}</p>
        </div>
        <p>Total Number of book in this Collection: {{totalComic.totalComicCount}}</p>
    </div>

</div>
</template>

<script>
import localService from '@/services/LocalService';
export default {
    name:"bookInCollection",
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
}

.stats .character{
    width: 300px;
    height: 50px;
    border: 1px solid blue;
}


</style>