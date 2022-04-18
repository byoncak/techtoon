<template>
  <div class="login-hero">
      <div class="login-title-block">
    <div class="login-title">
        Welcome to
    </div>
    </div>
    <div class="logo-container">
        <img class="login-logo" :src="image"/>
    </div>
    <div class="sign-in-title-block">
    <div class="sign-in-title">
    Sign In to View Your Comics
    </div>
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

.sign-in-title-block {
    color:white;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 800;
    display: flex;
    justify-content: center;
    align-content: center;
    margin-bottom: 2em;
    margin-top: -3vw;
}

.sign-in-title{
    font-size: min(2.8vw, 32px) ;
    display: flex;
    justify-content: center;
    align-content: center;
    min-width: 40%;
    max-width: 50%;
}

.login-hero {
    display: flex;
    flex-direction: column;
    background-color: blueviolet;
}

.login-title-block {
    display: flex;
    justify-content: center;
    align-items: center;
    margin-bottom: -4vw;
}

.login-title {
    color:white;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 800;
    font-size: max(2.4vw, 16px);
    align-content: center;
    max-width: 40vw;
    margin-top:1em;
}

.logo-container {
    display: flex;
    justify-content: center;
}
.login-logo{
    width: 44%;
}
</style>