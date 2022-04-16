<template>
    <div class="book">
        <div v-for="book in books" v-bind:key="book.id">
            <p>{{book}}</p> 
        </div>
    </div>
</template>

<script>
import localService from '@/services/LocalService';
export default {
    name:"bookInCollection",
    props:['collectionId'],
    data(){
        return{
            books:[],
        }
    },
    created(){
        localService.getCollectionById(this.collectionId).then(response =>{
                this.books=response.data;
            });

    }

}
</script>

<style>
.book{
    background-color:white;
}

</style>