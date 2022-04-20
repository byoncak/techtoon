<template>
  <div class="leaderboard-container">
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
    </div>

</template>

<script>
import localService from '@/services/LocalService';

export default {
    name:"stats-board",
    props:['collectionId'],
    data(){
        return{
            characters:[],
            totalComic:''
        }
    },
    created(){
        localService.getComicStatCharacter(this.collectionId).then(response =>{
                this.characters=response.data;
            });
        localService.getComicTotalInCollection(this.collectionId).then(response =>{
                this.totalComic=response.data;
            });
    },
    


}
</script>

<style>

</style>