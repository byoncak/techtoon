<template>
  <div id="app">
    <div id="nav">
    <router-link class="nav-btn1" v-bind:to="{ name: 'home' }">Home</router-link>
    <router-link class="nav-btn2" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />
  </div>
</template>

<style>

/* TODO: THIS BREAKS AT SMALL SCREEN SIZE */
#app {
  background: url('https://images.hdqwalls.com/download/marvel-superhero-8k-digital-art-fd-7680x4320.jpg');
  box-shadow:inset 0 0 0 2000px rgba(60, 7, 129, 0.753);
  background-size: 100% auto;
  background-repeat: no-repeat;
}
#nav {
  display: flex;
  padding-top: 16px;
  padding-right: 16px;
  padding-bottom: 16px;
  font-size: .8em;
  justify-content: flex-end;
  font-family: Arial, Helvetica, sans-serif;
  font-weight: 600;
}

.nav-btn1 {
  display: box;
  background-color: #9a4ef1;
  color: white;
  padding:12px;
  padding-left:16px;
  padding-right:16px;
  margin: 8px;
  border-radius: 50px;
  text-decoration: none;
}

.nav-btn2 {
  display: box;
  background-color: #9a4ef1;
  color: white;
  padding:12px;
  padding-left:16px;
  padding-right:16px;
  margin: 8px;
  border-radius: 50px;
  text-decoration: none;
}

</style>
