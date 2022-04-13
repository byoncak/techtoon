using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace Capstone.Services
{
    public class ApiService
    {
        public readonly string ApiUrl;
        //dependency injection stuff
        public ApiService(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        //AddOrCreateComicLogic()
        //When adding comic if record already exitsts in db, only add line to join table to place in collection
        //Else if it doesn't exist, create it and then add to join table
        //

        //GetDetailsforFrontEndDisplay()
        //Goes gets relevenat details, put them somewhere through a controller to get at the front end



    }
}
