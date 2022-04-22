<template>
<div class="comic-list-page">
    <div class="search-bar">
        <form v-on:submit.prevent>
        <input class="search-form-control" name="searchTitle" type="text" v-model="searchTitle" placeholder="Search for Comic" v-on:keyup.enter="searchByTitle"/>
      </form>
      <button class="search-button" type="submit" v-on:click="searchByTitle">Search</button>
    </div>
    <!-- <div class="selected-collection">
        <h4>Add to Collection:</h4>
        <select v-model="selectedCollection">
            <option v-for="collection in collections" v-bind:key="collection.id" :value="collection.collectionId">{{collection.collectionName}}</option>
        </select>
    </div> -->
  <div class="comic-list-container">
      <div class="comic-list" v-for="comic in comics" v-bind:key="comic.id"> 
        <div class="comic-card">
            <div class="comic-card__face comic-card__front" >
            <div class="cover-img-container" :id="comic.coverImage" v-bind:key="comic.id" v-on:click="flipComic(comic.coverImage)">
                <img class="cover-img" :src="comic.coverImage" :id="comic.coverImage">
            </div>
            <div class="circle-btn-container">
                <select class="circle-btn" style="border-radius:100%;" id="selected-collection" v-model="selectedCollection" v-on:click.prevent="flipComic()" v-on:change="addComic(comic)" >
                    <optgroup label = "Add To Collection:">
                    <option v-for="collection in collections" v-bind:key="collection.id" :value="collection.collectionId">{{collection.collectionName}}</option>
                    </optgroup>
                </select>
            </div>
            </div>
            <div class="comic-card__face comic-card__back"  v-bind:class="{ 'isFlipped': flipped }" :id="comic.coverImage" v-bind:key="comic.id" v-on:click="flipComic(comic.coverImage)">
            <div class="title-block">
                <h3 class="comic-title">{{comic.title.split('(').shift()}}</h3>
                
                <h3 class="comic-title">Issue #{{comic.issueNumber}}</h3>
                <h3 class="comic-title">{{comic.mainCharacter}}</h3> 
            </div>
            </div>
        </div>
        </div>
    </div>
</div>
</template>

<script>
import localService from '@/services/LocalService';

export default {
    name:"comic-list",
    data(){
        return{
            comics: [],
            collections:[],
            selectedCollection:'',
            searchTitle:'',
            flipped: false,
        }
    },
    created(){
        localService.getComicsList().then(response => {
                this.comics = response.data;
                });
        localService.getCollection().then(response => {
                this.collections = response.data;
                });
    },
    methods:{
        flipComic(comicId){
            let thisComic = document.getElementById(comicId);
            thisComic.classList.toggle("isFlipped");
            if(this.flipped === false){
            this.flipped === true;
            }
            else{this.flipped === false}
        },

        resetSelect(select){
            select.selectIndex = 0;
        },
        addComic(comic) {
            localService
            .addComicToCollection(comic, this.selectedCollection).then(response => {
                if(response.status===200 && response.data==true){
                    //'🗸';
                    this.selectedCollection='';
                    alert("Comic was successfully added.");
                }
                else{
                    this.selectedCollection='';
                    alert("Comic already added in current collection.")
                }
            })
            .catch(error => {
            if(error.response){
                if(error.response.status===404){
                                        this.selectedCollection='';
                    alert("Please select a collection to add.");
                }
                else if(error.response.status===500){
                                        this.selectedCollection='';
                    alert("Comic already exist in the selected collection")
                }
                else{
                                        this.selectedCollection='';
                    alert("Error submitting. Error code:"+error.response.status);
                }
            }
            else if(error.request) {
                                    this.selectedCollection='';
              alert("Error submitting. Server could not be reached.");
            }
            else {
                                    this.selectedCollection='';
              alert("Error submitting. Request could not be created.");
            }
            });
             },
      searchByTitle(){
          if(this.searchTitle!=''){
            localService.searchComicByTitle({params:{titleSearch:this.searchTitle}}).then(response =>{
             if(response.status===200){
                 this.comics=response.data;
                 this.searchTitle='';
                 if(this.comics.length===0){
                    localService.getComicsList().then(response => {
                    this.comics = response.data;
                    });
                    localService.getCollection().then(response => {
                    this.collections = response.data;
                    });
                    alert("Sorry...Nothing was found");
                    }
                    }
             
                })
            }
          
        },
    }
}
</script>



<style>

.hidden{
    opacity: 0;
}

.isFlipped{
    transform:  translateX(-10%) rotateY(-180deg);
    transition: transform 1s;
    transform-style: preserve-3d;
    position: relative;
}


.circle-btn-container{
    display:flex;
    position: absolute;
    z-index: 5;
    margin-left: 34%;
    margin-top: 100%;
    transition: height, width .2s ease-in;
}


.circle-btn.active,
.circle-btn:hover {
        height: 1.8em;
        width: 1.8em;
        transition: height, width .2s ease-in;
        transition: background-color .2s ease-in;
        background-color: cornflowerblue;
}

.circle-btn {
    display: flex;
    transition: background-color .2s ease-in;
    font-family: Arial, Helvetica, sans-serif;
    font-size:xx-large;
    justify-content: center;
    align-items: center;
    z-index: 3; 
    height: 1.6em;
    width: 1.6em; 
    color:white;
    background-color: blueviolet;
    box-shadow: 0 4px 12px 4px rgba(0, 0, 0, 1);
    border-color: lightskyblue;
    cursor:pointer;
    margin-left: 2em;
    margin-top: 1em;
    position: absolute;
}

.comic-list-page {
    background-color: white;
}


.comic-list-container{
    display: flex;
    margin-left: 12em;
    margin-right: 12em;
    justify-content: center;
    flex-wrap: wrap;
}

.circle-btn-content {
    display: flex;
    padding-left: 80px;
    z-index: 5;
    background-color: blueviolet;
}

.comic-list {

    flex-wrap: wrap;
    display: flex;
    justify-content: flex-start;
}
.cover-img-container {
    display: flex;
    cursor: pointer;
    z-index: 1;
    margin-top:0em;
    max-width: 210px;
    height: 320px;
    width: 210px;
    margin-bottom: -3em;
    justify-content: flex-start;
    transition: all 1s;
    transform-style: preserve-3d;
    perspective: 1000px;
 

}

.cover-img {
    transition: margin .3s ease-in-out;
    border-radius: 4.8px;
    box-shadow: 2px 4px 12px 0px rgba(0, 0, 0, .4);
    backface-visibility: hidden;
    width: 260px;
    max-width: 210px;
    overflow:hidden; 
    box-shadow: 2px 4px 12px 0px rgba(0, 0, 0, .4);  
}

.cover-img.active,
.cover-img:hover {
    transition: margin .3s ease-in-out;
    margin-bottom: .4em;
    margin-top: -.4em;
}

.comic-card__front {
  display: flex;
  align-content: flex-start;
  justify-content: flex-start;
  font-size: 1.5rem;
  z-index: 1;
  margin-top: 2em;
  margin-bottom: 0em;
  perspective: 800px;
  transition: all 0.4s ease 0s;
  max-width: 240px;
  max-height: 360px;
}

.comic-card {
    display: flex;
      transform-origin: center right;
      transition: transform 1s;
      position: relative;
      margin-bottom: 22em;
      margin-right: 16em;
      max-height: 320px;
      max-width: 240px;
      
}

.comic-card__face{
    display: flex;
    position: absolute;
    backface-visibility: hidden;
}

.comic-card__back {
  border-radius: .4em;;
  display: flex;
  align-items: center;
  justify-items: center;
  font-size: 1.5rem;
  margin-left:0;
  z-index: 0;
  margin-top: 2em;
  margin-bottom: 0em;
  perspective: 800px;
  transition: transform 1s ease 0s;
  max-width: 232px;
  background-color: blueviolet;
  height: 320px;
}

.title-block {
    display: flex;
    cursor: pointer;
    flex-direction: column;
    z-index: 0;
    margin-top:0em;
    max-width: 212px;
    height: 310px;
    width: 212px;
    justify-content: center;
    align-content: center;
    transition: all 1s;
    transform-style: preserve-3d;
    perspective: 1000px;
}

.comic-title {
    display: flex;
    justify-items: center;
    transition: all 1s;
    color: white;
    font-family: Arial, Helvetica, sans-serif;
    font-size: .80rem;
    font-weight: 600;
    cursor: pointer;
    margin-left: 2em;
    max-width: 160px;
    z-index: 0;
    perspective: 1000px;
}

.search-bar {
    display:flex;
    justify-content: center;
    padding: 2em;
    margin-bottom: -2em;
    
}

optgroup{
    color: white;
 font-size: 24px;
}

option selected{
    color: blueviolet;
}



.search-form-control {
  font-size: 16px;
  display: inline-block;
  width: 50vw;
  max-width: 40em;
  padding: 16px 12px;
  border: 1px solid blueviolet;
  border-radius: 80px;
}

::placeholder{
    color:rgb(120, 167, 228);
    padding-left: 1em;
}

.search-button {
    display: inline-block;
    margin-left: 1em;
    border-radius: 80px;
    width: 12em;
    height: 3.2em;
    background-color:blueviolet;
    color: white;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 600;
    font-size: 16px;
    padding-top: -4px;
    cursor: pointer;
}

#selected-collection{
  appearance: none;
  overflow: hidden;
  background: url("../assets/add_white_36dp.svg") no-repeat center blueviolet;
  background-color: blueviolet;
  color:white;
  z-index: 5;
}

select :default {
    color:blueviolet
}

</style>