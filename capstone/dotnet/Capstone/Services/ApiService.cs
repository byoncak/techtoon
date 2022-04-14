using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Capstone.Models;
using Capstone.DAO;

namespace Capstone.Services
{
    public class ApiService
    {
        private readonly IComicDAO comicDao;
        public RestClient client = new RestClient("https://gateway.marvel.com:443");
                                                        

        public ApiService (IComicDAO _comicDao)
        {
            comicDao = _comicDao;
            
        }
     

        public void GetComicsFromMarvel(string queryString)
        {
            RestRequest request = new RestRequest("v1/public/comics?apikey=" + queryString);
            
        }

        public void GetComicDetailsfromMarvel(Comic comic)
        {
            //direct call to Mavel API
        }

        public Comic AddOrCreateComic(Comic comic)
        {
            
        }
        
        //When adding comic if record already exitsts in db, only add line to join table to place in collection
        //Else if it doesn't exist, create it and then add to join table
        //

        //GetDetailsforFrontEndDisplay()
        //Goes gets relevenat details, put them somewhere through a controller to get at the front end
        
        //REST requests to marvel?


    }
}
