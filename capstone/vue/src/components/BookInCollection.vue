<template>
<div class='book'>
    <div class="comic-list-container">  
        <div class="comic-list" v-for="book in books" v-bind:key="book.id">
            <div class="comic-card">
                <div class="cover-img-container">
                        <img class="cover-img" :src="book.coverImage">
                </div>
                <div class="circle-btn-container" >
                        <button v-on:click='deleteComic(book)' class="circle-btn-delete" style="border-radius:100%;">
                        <img src="../assets/close_white_36dp.svg" class="circle-btn-content"/>
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
    width: 300px;
}

.stats .character{
    display: flex;
    flex-wrap: wrap;
    margin:10px;
    height: 50px;
}

.circle-btn-content {
    display: flex;
    justify-content: center;
    align-content: center;
    margin:auto;
    
}

.circle-btn-delete.active,
.circle-btn-delete:hover {
        height: 2.6em;
        width: 2.6em;
        transition: height, width .2s ease-in-out;
        transition: background-color .2s ease-in;
        background-color: cornflowerblue;
}

.circle-btn-delete {
    transition: background-color .2s ease-in;
    font-family: Arial, Helvetica, sans-serif;
    font-size: x-large;
    justify-content: center;
    align-items: center;
    z-index: 3;
    height: 2.4em;
    width: 2.4em; 
    color:white;
    background-color: blueviolet;
    box-shadow: 0 4px 12px 4px rgba(0, 0, 0, 1);
    border-color: lightskyblue;
    cursor:pointer;
    margin-top: 0em;
    position: absolute;
}

.x {
    margin-top: ;
}


</style>