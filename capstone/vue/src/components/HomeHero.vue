<template>
  <div class="home-hero">
    <div class="home-title">
        <img class="home-logo" :src="image"/>
    </div>
    <div class="button-group">
    <div>
        <router-link class="home-buttons" v-bind:to="{ name: 'collections' }">View My Collections</router-link>    
    </div>
    <div>
        <router-link class="home-buttons" v-bind:to="{ name: 'add-collection' }">Create New Collection</router-link>
    </div>
    </div>
  </div>
</template>

<script>

export default {
  name: "home-hero",
  data(){ return {
      image: require('../assets/TEchtoon.png')
  }
  
  }
}
</script>

<style>

.home-hero {
    margin-bottom: 80px;
}

.welcome {
    text-shadow: 0px 8px 24px rgba(0,0,0,0.8);
}


.home-title {
    display: flex;
    justify-content: center;
}

.home-buttons {
    display: flex;
    justify-content: center;
    width: 16em;
    margin:1em;
    padding: 16px;
    padding-left:32px;
    padding-right:32px;
    border-radius: 50px;
    text-decoration:none;
    font-family: Arial, Helvetica, sans-serif;
    font-weight:600;
    font-size: max(1.2vw, 16px);
    color:white;
    background-color: blueviolet;
    text-align:center;
    box-shadow: 0 8px 32px 0 rgba(0, 0, 0, 0.4);
}

.button-group {
    flex-wrap: wrap;
    display: flex;
    justify-items: space-evenly;
    justify-content: center;
}

.home-logo {
    display:flex;
    justify-content: center;
    margin-top: .4em;
    width: 40vw;
}



</style>