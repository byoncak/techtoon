<template>
    <div class="LeaderBoard">
    <table>
        <caption>Leader Board</caption>
        <thead>
        <tr>
            <th>Rank </th>
            <th>Username </th>
            <th>Number of Comics</th>
        </tr>
        </thead>
        <tbody>
            <tr v-for="(user,i) in userStats" v-bind:key="user.id">
                <td>{{i+1}}</td>
                <td>{{user.userName}}</td> 
                <td>{{user.totalCount}}</td>
        </tr>
        </tbody>
    </table>
    <div class="character">
    <table>
        <caption>Most Popular Character</caption>
        <thead>
        <tr>
            <th>Rank </th>
            <th>Character </th>
            <th>Count</th>
        </tr>
        </thead>
        <tbody>
            <tr v-for="(character,i) in characterStats" v-bind:key="character.id">
                <td>{{i+1}}</td>
                <td>{{character.name}}</td> 
                <td>{{character.issueCount}}</td>
        </tr>
        </tbody>
    </table>
    </div>

    </div>
</template>

<script>
import localService from '@/services/LocalService';

export default {
    name:"Leader-board",
    data(){
        return{
            userStats: [],
            characterStats:[],
            count:0,
        }
    },
    created(){
        localService.getTotalComicsStats().then(response => {
                this.userStats = response.data;
                });
        localService.getCharacterStats().then(response => {
                this.characterStats = response.data;
                });
    },
    methods:{
        increment(){
            return this.count+=1;
        }
    }
}
</script>

<style>
th, td{
  margin: 0;
  padding: 12px 15px;
  text-align: center;
}

</style>