<template>
  <div id="login" class="text-center">
    <login-hero/>
    <div class="bg">
    <div class="form-center">
    <form class="signin-form" @submit.prevent="login">
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
      <router-link class="need-an-account" :to="{ name: 'register' }">Need an account?</router-link>
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


.text-center{
  background-color: blueviolet;
}

.need-an-account {
  color:black
}

.form-control {
  width: 50vw;
  max-width: 40em;
  padding: 12px 12px;
  margin: 8px 0; 
  border: 1px solid rgb(168, 168, 168);
  border-radius: 4px;
}

.form-center {
  flex-direction: column;
  display:flex;
  align-content: center;
  justify-content: center;
  align-items: center;
  margin-bottom: 4em;
}

.signin-form {

    background-color: blueviolet;
    display: flex;
    flex-direction: column;
    align-content: center;
    align-items: center;
    justify-content: center;
    font-family: Arial, Helvetica, sans-serif;
    color: white;
    font-weight: 600;
    row-gap: 1em;
    }

#login {
  display: flex;
  flex-direction: column;
}

</style>