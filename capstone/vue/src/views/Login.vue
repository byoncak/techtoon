<template>
  <div id="login" class="text-center">
    <login-hero/>
    <div class="bg">
    <div class="form-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Sign In to View Your Comics</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      <div class="form-input">
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      </div>
      <router-link class="link" :to="{ name: 'register' }">Need an account?</router-link>
      <button type="submit">Sign in</button>
    </form>
    </div>
    </div>
  </div>
</template>

<script>
import LoginHero from '../components/LoginHero.vue'
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {LoginHero},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>


<style>

.form-center{
  display: flex;
  justify-content: center;
}

.bg{

}

.link {
  color:black
}

input[type=text], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type=password], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

.h3 {
  margin-top: -3.2em;
  display: flex;
  justify-content: center;
  font-family: Arial, Helvetica, sans-serif;
  color: white;
}

.form-signin {

    background-color: blueviolet;
    padding: 5em;
    border-radius: 8px;
    display: flex;
    flex-direction: column;
    align-content: center;
    align-items: center;
    font-family: Arial, Helvetica, sans-serif;
    color: white;
    font-weight: 600;
    row-gap: 1em;
    width: 24vw;
    height: 12vh;
    margin-bottom: 4.4em;
}

.form-input {
  margin-top: 2em;
  display: flex;
  flex-direction: column;
  width: 24vw;
}

form {
  background: white;
  display: flex;
  justify-content: center;
}

</style>