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
            <div class="cover-img-container">
                <img class="cover-img" :src="comic.coverImage">
            </div>
            <div class="circle-btn-container">
                <select class="circle-btn" style="border-radius:100%;" v-model="selectedCollection" v-on:change="addComic(comic)">
                    <optgroup label="Add to Collections">
                    <option v-for="collection in collections" v-bind:key="collection.id" :value="collection.collectionId">{{collection.collectionName}}</option>
                    </optgroup>
                </select>
            </div>
            <div class="title-block">
                <p class="comic-title">{{comic.title}}</p>
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
        addComic(comic) {
            localService
            .addComicToCollection(comic, this.selectedCollection).then(response => {
                console.log(response.status)
                console.log(response.data)
                if(response.status===200 && response.data==true){
                    //'🗸';
                    alert("Comic was successfully added.");
                }
                else{
                    alert("Comic already added in current collection.")
                }
            })
            .catch(error => {
            if(error.response){
                if(error.response.status===404){
                    alert("Please select a collection to add.");
                }
                else if(error.response.status===500){
                    alert("Comic already exist in the selected collection")
                }
                else{
                    alert("Error submitting. Error code:"+error.response.status);
                }
            }
            else if(error.request) {
              alert("Error submitting. Server could not be reached.");
            }
            else {
              alert("Error submitting. Request could not be created.");
            }
            });
             },
      searchByTitle(){
          localService.searchComicByTitle({params:{titleSearch:this.searchTitle}}).then(response =>{
             if(response.status===200){
                 this.comics=response.data;
                 this.searchTitle='';
                 if(this.comics.length===0){
                     this.$router.push("/comics");
                     alert("Sorry...Nothing was found");
                 }
             }
             
      })
    },
}
}
</script>



<style>

.circle-btn-container{
    display:flex;
    margin-left: 6em;
    margin-bottom: 1em;
}


.circle-btn.active,
.circle-btn:hover {
        height: 1.8em;
        width: 1.8em;
        transition: height, width .2s ease-in-out;
        transition: background-color .2s ease-in;
        background-color: cornflowerblue;
}

.circle-btn {
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
    margin-top: 0em;
    position: absolute;
    transition: margin .2s ease-in-out;
    transition: height, width .2s ease-in-out;
}

.comic-list-page {
    background-color: white;
}


.comic-list-container{
    display: flex;
    margin-left:16vw;
    margin-right: 16vw;
    flex-wrap: wrap;
justify-content: space-evenly;}

.cover-img-container {
    display: flex;
    cursor: pointer;
    z-index: 3;
    margin-top:0em;
    height: 320px;
    margin-bottom: -3em;
    justify-content: space-evenly;
}

.cover-img {
    transition: margin .3s ease-in-out;
    border-radius: 4.8px;
    box-shadow: 2px 4px 12px 0px rgba(0, 0, 0, .4);
    
}

.cover-img.active,
.cover-img:hover {
    transition: margin .3s ease-in-out;
    margin-bottom: .3em;
    margin-top: -.3em;
}

.comic-card {
  align-content: flex-start;
  justify-content: space-evenly;
  font-size: 1.5rem;
  z-index: 1;
  margin-top: 2em;
  margin-right: 1em;
  margin-bottom: -3em
}

.title-block {
    z-index: 0;
    display: flex;
    margin-top: 2.4em;
}

.comic-title {
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

.search-bar {
    display:flex;
    justify-content: center;
    padding: 2em;
    
}

.search-form-control {
  display: inline-block;
  width: 50vw;
  max-width: 40em;
  padding: 12px 12px;
  border: 1px solid rgb(168, 168, 168);
  border-radius: 80px;
}

::placeholder{
    color:lightblue;
    padding-left: 1em;
}

.search-button {
    display: inline-block;
    margin-left: 2em;
    border-radius: 80px;
    width: 12em;
    height: 3.2em;
}

.selected-collection{
    display: flex;
    justify-content: center;
}

</style>