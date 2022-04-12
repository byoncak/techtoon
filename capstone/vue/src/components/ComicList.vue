<template>
  <div class="comic-list">
      <p>Comic list page</p>
      <div class="comic" v-for="comic in comics" v-bind:key="comic.id"> 
          <img :src="comic.thumbnail.path + '.' + comic.thumbnail.extension">
          <h2>{{comic.title}}</h2>
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
        }
        )

    }


}
</script>



<style>

.comic {
    
    padding: 10px

}

</style>