import axios from 'axios';


export default {

// getCollection() {
//     return axios.get('/collections');
//   },

// getCollectionById(id) {
//     return axios.get(`/collections/${id}`);
//   },

newCollection(collection){
    return axios.post('/collection',collection);
  },  

updateComics(comic){
  return axios.put('/comic', comic);
}

}