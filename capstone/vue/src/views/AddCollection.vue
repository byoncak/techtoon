<template>
    <div class="form">
        <h1>Collection Form </h1>
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
.form{
    background-color:white;
}

</style>