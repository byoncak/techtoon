import axios from 'axios';

export const public_key= '7c00280a6a472ebdddadfe35049008d8';
// const secret_key= '038dd395fb69dc235919cf4eae06be17c6d39273';

const http = axios.create({
  baseURL: "https://gateway.marvel.com",
});

export default {

getComics(){
    return http.get(`/v1/public/comics?format=comic&formatType=comic&orderBy=-focDate&apikey=${public_key}`);
}

}
