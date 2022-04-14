<template>
<div class="comic-list-page">
    
  <div class="comic-list">
      <div class="comic" v-for="comic in comics" v-bind:key="comic.id"> 
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

.add-comic-btn{
    align-content: flex-end;
    justify-content: flex-end;
}

.circle-btn.active,
.circle-btn:hover {
    transition: background-color .2s ease-in;
    background-color: cornflowerblue;
    transition: height, width .2s ease-in-out;
    height: 2em;
    width: 2em;

}

.circle-btn {
    transition: background-color .2s ease-in;
    transition: height, width .2s ease-in-out;
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
    cursor:pointer;
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

.comic:hover {
    transition: margin .4s ease-in-out;
    margin-top: 5em;
}

.comic {
  transition: margin .4s ease-in-out;
  align-items: flex-start;
  font-size: 1.5rem;
  z-index: 0;
  margin-top: 6em;
}


.comic-title {
    color: black;
    font-family: Arial, Helvetica, sans-serif;
      font-size: .95rem;
      font-weight: 600;
      cursor: pointer;
}


.cover-img {
    border-radius: 8px;
    cursor: pointer;
    position: relative;
    z-index: -1;
}

</style>