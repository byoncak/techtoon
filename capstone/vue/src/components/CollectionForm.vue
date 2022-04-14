<template>
  <form v-on:submit.prevent="submitForm" class="collectionForm">
  <div class= "form-group">
      <label for="collection-name">Collection Name:</label>
      <input id="collection-name" type="text" class="form-control" v-model="collection.collectionName" autocomplete="off" />
  </div>
  <div class= "formGroup">
      <label for="is-public">Make Private:</label>
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
                collectionName:'',
                isPublic:false,
            }
        }
    },
    methods:{
        saveCollection(){
            localService.newCollection(this.collection).then(response => {
                if(response.status ==201){
                    console.log(this.collection)
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


input[type=text], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

.collectionForm {
    background-color: blueviolet;
    padding: 5em;
    border-radius: 8px;
    display: flex;
    flex-direction: column;
    align-content: center;
    font-family: Arial, Helvetica, sans-serif;
    color: white;
    font-weight: 600;
    
}

input, label > #collection-name{
    display: block;
    
}

#is-public{
    margin-top: 1.2em;
    display: inline-block;
    margin-bottom: 2em;
}
</style>
