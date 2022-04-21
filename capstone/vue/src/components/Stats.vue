<template>
  <div class="stat-container">
        <div class="stat-columns">
        <h4 class="stat-title">Collection Stats:</h4>
        <div class="stat-leaders-container">
        <div class="stat-leaders" v-for="character in characters" v-bind:key="character.id">
        <div class="stat-leader-stats">
            <p class="stat-leaders" id="stat-leader-name">{{character.name}}</p> <p class="stat-leaders"> {{character.issueCount}}</p>
           </div>
        </div>
        </div>
        <p class="stat-leaders">Total Number of book in this Collection: </p><p class="stat-leaders">{{totalComic.totalComicCount}}</p>
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

.tagline{
    color:blueviolet;
    font-size: 24px;
    font-weight: 600;
    display: flex;
    margin-top:2em;
    margin-bottom: -4em;
}

.big-title {
    display: flex;
    justify-content: center;
    text-decoration: underline;
    color:blueviolet;
    font-size: 56px;
    margin-bottom: 1em;
    font-weight:900;

}

.stat-container{
    font-family: Arial, Helvetica, sans-serif;
    display: flex;    
    justify-content: center;
    background-color: white;

}
.stat-columns{
    border-radius: 4em;
    outline: 2px solid blueviolet;
    flex-direction: column;
    display: flex;
    justify-content: center;
    width: 50%;
    margin-top:2em;
}

.stat-leaders-container{
    margin-top: 2em;
    justify-content: center;
    align-content: center;
    display: flex;
    flex-wrap: wrap;
}

#stat-leader-name{
    display: flex;
    font-weight: 800;
    background-color: cyan;
    color: darkblue;
}

.stat-leaders{
    display: flex;
    align-items: center;
    justify-content: center;
    font-weight: 600;
    font-size: 24px;
    margin-top: -1em;
    margin-bottom: 1.6em;
    background-color: white;
    margin-right: .4em;
}

.stat-title{
    color:blueviolet;
    font-size: 40px;
    font-weight: 800;
    display:flex;
    justify-content:center;
    margin-bottom: 1em;
}

.stat-leader-stats{
    align-content: center;
    justify-items: center;
    display: flex;
}

</style>