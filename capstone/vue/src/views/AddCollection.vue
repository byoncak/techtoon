<template>
    <div class="form">
      <h1>Create New Collection</h1>
        <p>Complete the form below to create a new collection.</p>
        <collection-form />
  </div>
</template>

<script>
import CollectionForm from '../components/CollectionForm.vue'

export default {
  components: { CollectionForm },
  name:'add-collection'

}
</script>

<style>

h1 {
  display: flex;
  font-family: Arial, Helvetica, sans-serif;
  margin-bottom: -.2em;
  padding-top: 1.2em;
  justify-content: center;
}

p {
  display: flex;
  font-family: Arial, Helvetica, sans-serif;
  justify-content: center;
  margin-bottom: 4em;
}

.form{
  display: flex;
  flex-direction: column;
  align-items: center;

    background-color:white;
}

</style>