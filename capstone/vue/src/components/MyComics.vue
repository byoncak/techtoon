<template>
<div class="comic-list-page">
    <div class="home-title">
        <h2>My Comics</h2>
    </div>
  <div class="comic-list">
      <div v-on:mouseover="hoverIn" class="comic animate" v-for="comic in comics" v-bind:key="comic.id"> 
        <div class="add-comic-btn">
        <button class="circle-btn" style="border-radius:100%;">
        <span class="inner-circle-btn">+</span>
        </button>
        </div>
          <div class="cover">
          <img class="cover-img" :src="comic.thumbnail.path + '.' + comic.thumbnail.extension">
          </div>
          <div>
          <p class="comic-title">{{comic.title}}</p>
          </div>
        </div>
        </div>
  </div>
</template>

<script>
import marvelService from '@/services/MarvelService';
// import localService from '@/services/LocalService';

export default {
    name:"comic-list",
    data(){
        return{
            comics: [],
        }
    },
    created(){
        marvelService.getComics().then(response => {
            response.data.data.results.forEach(item=>{
                this.comics.push(item);
                console.log(item)
                });
            });
    },
    // methods:{
    //     addComic(){
    //         localService.addComic(comic).then(response => {
    //             if(response.status ==201){
    //                 console.log(this.collection)
    //                 this.$router.push("/");
    //             }
    //         })
    //         .catch(error => {
    //     if(error.response){
    //           this.errorMsg = "Error submitting. Response received was '" + error.response.statusText + "'.";
    //         }
    //         else if(error.request) {
    //           this.errorMsg = "Error submitting. Server could not be reached.";
    //         }
    //         else {
    //           this.errorMsg = "Error submitting. Request could not be created.";
    //         }
    //   }); }
    // }
}
</script>



<style>

.home-title {
    color:black;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 800;
    font-size: 1.2em;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 100%;
    max-width: 30vw;
    margin-bottom: -4em;
    margin-top: 5em;
}

.add-comic-btn{
    display: flex;
    margin-right: .4em;
    justify-content: flex-end; 
    margin-bottom: -5em;
}

.circle-btn {
    display: flex;
    height: 1.8em;
    width: 1.8em;
    font-family: Arial, Helvetica, sans-serif;
    font-size:xx-large;
    justify-content: center;
    align-items: center;
    z-index: 2;  
    color:white;
    background-color: blueviolet;
    box-shadow: 0 4px 12px 4px rgba(0, 0, 0, 1);
    border-radius: 1px;
    border-color: lightskyblue;
    cursor:crosshair;
}


.comic-list-page {
    background-color: white;
}
.comic-list {
    display: flex;
    margin-left:16vw;
    margin-right: 16vw;
    justify-content: space-around;
    flex-wrap: wrap;
}

.comic {
  align-items: flex-start;
  border-radius: 8px;
  width: 216px;
  height: 10.8em;
  font-size: 1.5rem;
  margin-top: 6em;
  box-shadow: 0 6px 8px 2px rgba(0, 0, 0, 0.4);
  z-index: 0;
}

.cover {
    cursor: pointer;
    transition: margin 0.2s ease-in-out;
    z-index: -2;
}


.comic-title {
    color: black;
    font-family: Arial, Helvetica, sans-serif;
      font-size: 1rem;
      font-weight: 00;
      cursor: pointer;
}


.cover-img {
    border-radius: 8px;
    width: 216px;
    height: 324px;
    cursor: pointer;
    position: relative;
    z-index: -1;
}

</style>