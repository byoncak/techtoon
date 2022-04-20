<template>
<div class="leaderboard-container">
    <div class="columns">
    <div>
    <p class="tagline">Welcome To The</p>
    <h1 class="big-title">LEADERBOARDS</h1>
    </div>
<h4 class="leaderboard-title">Most Comics</h4>
    <div class="leaders-container" v-for="user in userStats" v-bind:key="user.id">
        <div class="leader-stats">
        <p class="leaders" id="leader-name"> {{user.userName}}</p><p class="leaders"> {{user.totalCount}} Comics </p>
    </div>
    </div>

    <h4 class="leaderboard-title">Popular Characters</h4>
    <div class="leaders-container" v-for="character in characterStats" v-bind:key="character.id">
        <div class="leader-stats">
        <p class="leaders" id="leader-name"> {{character.name}}</p><p class="leaders"> {{character.issueCount}} Collection Appearances</p>
    </div>
    </div>
    </div>
</div>
</template>

<script>
import localService from "@/services/LocalService.js"
export default {
    name:"leaderboard-comp",
    data(){
        return{
            userStats:[],
            characterStats:[],
        }
    },
    created() {
        localService.getTotalComicsStats().then(response => {
            this.userStats = response.data;
        });
        localService.getCharacterStats().then(response => {
            this.characterStats = response.data;
        });

    }

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

.leaderboard-container{
    font-family: Arial, Helvetica, sans-serif;
    display: flex;    
    justify-content: center;
    background-color: white;
}
.columns{
    flex-direction: column;
    display: flex;
    justify-content: center;
    width: 40vw;
}

.leaders-container{
    align-content: center;
    display: flex;
}

#leader-name{
    display: flex;
    font-weight: 800;
    background-color: cyan;
    color: darkblue;
}

.leaders{
    display: flex;
    justify-content: center;
    font-weight: 600;
    font-size: 24px;
    margin-top: -1em;
    margin-bottom: 2em;
    background-color: white;
    padding-left:1em;
    padding-right:1em;
    margin-right: .4em;
}

.leaderboard-title{
    color:blueviolet;
    font-size: 40px;
    font-weight: 600;
    display:flex;
    justify-content:left;
    margin-bottom: 1em;
}

.leader-stats{
    display: inline-flex;
}

</style>