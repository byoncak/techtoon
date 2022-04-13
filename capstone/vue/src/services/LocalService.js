import axios from 'axios';


export default {

// getCollection() {
//     return axios.get('/collections');
//   },

// getCollectionById(id) {
//     return axios.get(`/collections/${id}`);
//   },

newCollection(collection){
    return axios.post('/collections',collection);
  }, 

}