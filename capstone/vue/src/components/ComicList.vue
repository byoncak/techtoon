<template>
<div class="comic-list-page">
  <div class="comic-list">
      <div v-on:mouseover="hoverIn" class="comic animate" v-for="comic in comics" v-bind:key="comic.id"> 
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
import marvelService from '@/services/MarvelService'

export default {
    name:"comic-list",
    data(){
        return{
            comics:[],
        }
    },
    created(){
        marvelService.getComics().then(response => {
            response.data.data.results.forEach(item=>{
                this.comics.push(item);
                });
            });
    }
}
</script>



<style>

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
  background-color: #15263F;
  color: #8BACD9;
  border-radius: 8px;
  width: 216px;
  height: 324px;
  font-size: 1.5rem;
  margin: 16px;
  margin-top: 56px;
  box-shadow: 0 6px 12px 0 rgba(0, 0, 0, 0.4);
}

.cover {
    transition: margin 0.2s ease-in-out;
}


.comic-title {
    color: black;
      font-size: 1rem;
      font-weight: bold;
      cursor: pointer;
}


.cover-img {
    width: 216px;
    height: 324px;
    cursor: pointer;
    position: relative;
    border-radius: 4px;
    cursor: pointer;
    position: relative;
}

</style>