import axios from 'axios';


export default {

getCollection() {
    return axios.get('/collections/my-collections');
  },

getCollectionById(id) {
    return axios.get(`/collections/${id}/comics`);
  },

getPublicCollection(){
    return axios.get('/collections/public-collection');
  },

newCollection(collection){
    return axios.post('/collections',collection);
  },  

updateComics(comic){
  return axios.post('/comics', comic);
},

addComicToCollection(comic, collectionId){
  return axios.post(`/collections/${collectionId}/comics`, comic);
},

deleteComicFromCollection(collectionId,comicId){
  return axios.put(`/collections/${collectionId}/comics/${comicId}`);
},

getComicsList(){
  return axios.get('/comics');
},

searchComicByTitle(title,character){
  return axios.get('/comics/searchTitle',title,character)
},

getComicStatCharacter(id){
  return axios.get(`/collections/${id}/stats/characters`)
},

getComicTotalInCollection(id){
  return axios.get(`/collections/${id}/stats`)
},

getTotalComicsStats(){
  return axios.get('/collections/stats/users')
},

getCharacterStats(){
  return axios.get('/collections/stats/characters')
},

getCoverImage(id){
  return axios.get(`/collections/${id}/comicsImages`)
},

}