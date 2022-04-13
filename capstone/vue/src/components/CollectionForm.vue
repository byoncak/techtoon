<template>
  <form v-on:submit.prevent="submitForm" class="collectionForm">
  <div class= "form-group">
      <label for="collection-name">Collection Name</label>
      <input id="collection-name" type="text" class="form-control" v-model="collection.name" autocomplete="off" />
  </div>
  <div class= "formGroup">
      <label for="is-public">Make This Collection Private</label>
      <input id="is-public" type="checkbox" class="form-control" v-model="collection.isPublic" />
  </div>
  <div class="action">
      <button type="submit" v-on:click="saveCollection">Save</button>
  </div>
  </form>
</template>

<script>
import localService from '@/services/LocalService';

export default {
    name: "collection-form",
    data(){
        return{
            collection:{
                name:'',
                isPublic:false,
            }
        }
    },
    methods:{
        saveCollection(){
            localService.newCollection(this.collection).then(response => {
                if(response.status ==201){
                    this.$router.push("/");
                }
            })
            .catch(error => {
        if(error.response){
              this.errorMsg = "Error submitting. Response received was '" + error.response.statusText + "'.";
            }
            else if(error.request) {
              this.errorMsg = "Error submitting. Server could not be reached.";
            }
            else {
              this.errorMsg = "Error submitting. Request could not be created.";
            }
      });
        }

    }

}
</script>

<style>

</style>
