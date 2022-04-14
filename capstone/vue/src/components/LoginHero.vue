<template>
  <div class="login-hero">
    <div class="login-title">
        Welcome to
        <img class="logo" :src="image"/>
    </div>
    </div>
</template>

<script>

export default {
  name: "login-hero",
  data(){ return {
      image: require('../assets/TEchtoon.png')
  }
  
  }
}
</script>

<style>

.login-hero {
    margin-bottom: 80px;
}

.login-title {
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
    margin-top:1em;
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
    margin-top: -2em;
    display: flex;
    justify-content: center;
}

.logo {
    margin-bottom: -.4em;
    margin-top: -.5em;
    width: 32vw;
}
</style>