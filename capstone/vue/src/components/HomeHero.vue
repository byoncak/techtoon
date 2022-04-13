<template>
  <div class="home-hero">
    <div class="home-title">
        <p class="welcome">WELCOME!</p>
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
  name: "home-hero"
};
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
    font-size: 4em;
    display: flex;
    justify-content: center;
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
</style>