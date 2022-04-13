<template>
  <div class="home-hero">
    <div class="home-title">
        <img class="logo" :src="image"/>
        <p>My Comics</p>
    </div>
    <div class="button-group">
    <div>
        <router-link class="home-buttons" v-bind:to="{ name: 'comics-list' }">Browse Comics</router-link>    
    </div>
    <div>
        <router-link class="home-buttons" v-bind:to="{ name: 'add-collection' }">Create Collection</router-link>
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
    color:white;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 800;
    font-size: 3.2em;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 100%;
    max-width: 30vw;
    margin: auto;
}
.home-buttons {
    display: inline-block;
    width: 240px;
    margin: 16px;
    padding: 16px;
    padding-left:32px;
    padding-right:32px;
    border-radius: 50px;
    text-decoration:none;
    font-family: Arial, Helvetica, sans-serif;
    font-weight:600;
    color:white;
    background-color: cornflowerblue;
    text-align:center;
    box-shadow: 0 8px 32px 0 rgba(0, 0, 0, 0.4);
}

.button-group {
    display: flex;
    justify-content: center;
}

.logo {
    margin-bottom: -1.6em;
    width: 32vw;
}
</style>