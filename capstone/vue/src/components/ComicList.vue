<template>
<div class="comic-list-page">
    <leader-board />
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
                <select name="" class="circle-btn" style="border-radius:100%;" id="selected-collection" v-model="selectedCollection" v-on:change="addComic(comic)" >
                    <optgroup label = "Add To Collection:">
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
import LeaderBoard from './LeaderBoard.vue';

export default {
  components: { LeaderBoard },
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
    },
}
}
</script>



<style>


.circle-btn-container{
    display:flex;
    margin-left: 6em;
    margin-bottom: 1em;
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
}

.comic-list-page {
    background-color: white;
}


.comic-list-container{
    display: flex;
    margin-left:12vw;
    margin-right: 12vw;
    flex-wrap: wrap;
    justify-content: center;


}

.circle-btn-content {
    padding-left: 80px;
    z-index: 5;
    background-color: blueviolet;
}

.comic-list {
    margin-right: -1em;
    display: flex;
    justify-content: flex-start;
}
.cover-img-container {
    display: flex;
    cursor: pointer;
    z-index: 3;
    margin-top:0em;
    max-width: 260px;
    height: 320px;
    width: 260px;
    margin-bottom: -3em;
    justify-content: flex-start;
}

.cover-img {
    transition: margin .3s ease-in-out;
    border-radius: 4.8px;
    box-shadow: 2px 4px 12px 0px rgba(0, 0, 0, .4);
    
}

.cover-img.active,
.cover-img:hover {
    transition: margin .3s ease-in-out;
    margin-bottom: .4em;
    margin-top: -.4em;
}

.comic-card {
  align-content: flex-start;
  justify-content: flex-start;
  font-size: 1.5rem;
  z-index: 1;
  margin-top: 2em;
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
    margin-left: 2em;
    border-radius: 80px;
    width: 12em;
    height: 3.2em;
    background-color:blueviolet;
    color: white;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 600;
    font-size: 16px;
    padding-top: -4px;
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