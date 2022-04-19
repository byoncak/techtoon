<template>
  <div id="app">
    <div class="bg-image">
    <div id="nav">
    <router-link class="nav-btn1" v-bind:to="{ name: 'home' }">Home</router-link>
    <router-link class="nav-btn2" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    <router-link class="nav-btn2" v-bind:to="{ name: 'login' }" v-else>Login</router-link>
    </div>
    <router-view />
  </div>
  </div>
</template>

<style>

/* TODO: THIS BREAKS AT SMALL SCREEN SIZE */
#app {

}

.bg-image{
  background-image: url('https://images.hdqwalls.com/download/marvel-superhero-8k-digital-art-fd-7680x4320.jpg');
  box-shadow:inset 0 0 0 2000px rgba(60, 7, 129, 0.6);
  background-size: 100%;
  background-repeat: no-repeat;
  transition: background-size, .5s ease-in-out;

}

#nav {
  font-weight: 400;
  display: flex;
  justify-content: flex-end;
  padding-top: 16px;
  padding-right: 16px;
  font-size: 1em;
  font-family: Arial, Helvetica, sans-serif;
  font-weight: 600;
}

.nav-btn1 {
  display: flex;
  justify-content: center;
  color: white;
  padding:12px;
  min-width: 80px;
  padding-right:16px;
  margin: 8px;
  border-radius: 50px;
  text-decoration: none;
}

.nav-btn2 {
  display: flex;
  color: white;
  padding:12px;
  padding-left:16px;
  padding-right:16px;
  margin: 8px;
  min-width: 80px;
  border-radius: 50px;
  text-decoration: none;
  justify-content: center;
}

.nav-btn3 {
  justify-content: center;
  display: flex;
  color: white;
  padding:12px;
  padding-left:16px;
  padding-right:16px;
  margin: 8px;
  border-radius: 50px;
  text-decoration: none;
}


@media(max-width: 780px) {
  .bg-image {
    background-color: white;
    box-shadow:inset 0 0 0 2000px rgba(60, 7, 129, .6);
    /* height: 210px; */
    transition: background-size, .4s ease-in-out;
    background-size: 170%;
    overflow: hidden;
    
  }
}

</style>
