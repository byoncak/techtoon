using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Capstone.Models;
using Capstone.DAO;

namespace Capstone.Services
{
    
    public class Url
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Series
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Variant
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Date
    {
        public string type { get; set; }
        public DateTime date { get; set; }
    }

    public class Price
    {
        public string type { get; set; }
        public double price { get; set; }
    }

    public class Thumbnail
    {
        public string path { get; set; }
        public string extension { get; set; }
    }

    public class Image
    {
        public string path { get; set; }
        public string extension { get; set; }
    }

    public class Item
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string type { get; set; }
    }

    public class Creators
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<Item> items { get; set; }
        public int returned { get; set; }
    }

    public class Characters
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<object> items { get; set; }
        public int returned { get; set; }
    }

    public class Stories
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<Item> items { get; set; }
        public int returned { get; set; }
    }

    public class Events
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<object> items { get; set; }
        public int returned { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public int digitalId { get; set; }
        public string title { get; set; }
        public int issueNumber { get; set; }
        public string variantDescription { get; set; }
        public object description { get; set; }
        public DateTime modified { get; set; }
        public string isbn { get; set; }
        public string upc { get; set; }
        public string diamondCode { get; set; }
        public string ean { get; set; }
        public string issn { get; set; }
        public string format { get; set; }
        public int pageCount { get; set; }
        public List<object> textObjects { get; set; }
        public string resourceURI { get; set; }
        public List<Url> urls { get; set; }
        public Series series { get; set; }
        public List<Variant> variants { get; set; }
        public List<object> collections { get; set; }
        public List<object> collectedIssues { get; set; }
        public List<Date> dates { get; set; }
        public List<Price> prices { get; set; }
        public Thumbnail thumbnail { get; set; }
        public List<Image> images { get; set; }
        public Creators creators { get; set; }
        public Characters characters { get; set; }
        public Stories stories { get; set; }
        public Events events { get; set; }
    }

    public class Data
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        public List<Result> results { get; set; }
    }

    public class Root
    {
        public int code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public string etag { get; set; }
        public Data data { get; set; }
    }
    public class ApiService: IApiService
    {
        const string apiKey = "ts=1&apikey=01a8382b3a6d62f64d7c8295260acc34&hash=57004eae8bee7e2612f4425de28963a7";
        private readonly IComicDAO comicDao;
        public static IRestClient client = new RestClient("https://gateway.marvel.com:443");

        //public ApiService() { }
        public ApiService (IComicDAO _comicDao)
        {
            comicDao = _comicDao;
            
        }



        public List<Comic> GetComicsFromMarvel()
        {
            RestRequest request = new RestRequest("v1/public/comics" + "?" + apiKey);
            IRestResponse<Root> response = client.Get<Root>(request);
            List<Comic> comics = new List<Comic>();
            for (int i = 0; i < response.Data.data.results.Count; i++)
            {
                Result result = response.Data.data.results[i];
                comics.Add(MapRootToComic(result));
            }
            return comics;
        }


        public Comic GetComicDetailsfromMarvel(int marvelId)
        {
           
            RestRequest request = new RestRequest("v1/public/comics/" + marvelId + "?" + apiKey);
            IRestResponse<Root> response = client.Get<Root>(request);
            Result result = response.Data.data.results[0];
            return MapRootToComic(result);


        }
        

        public Comic AddOrCreateComic(Comic comic)
        {
            Comic comicToAdd = comicDao.GetComicByMarvelId(comic.MarvelId);
            if (comicToAdd != null)
            {
                return comicToAdd;
            }
            else
            {
                return comicDao.CreateComic(comic);
               
            }

        }
        public Comic MapRootToComic(Result result)
        {
            Comic comic = new Comic();
            comic.MarvelId = result.id;
            comic.Title = result.title;
            comic.IssueNumber = result.issueNumber;
            comic.Description = (string)result.description;
            if (result.images.Count > 0)
            {
                comic.CoverImage = result.images[0].path + "." + result.images[0].extension;
            }
            else
            {
                comic.CoverImage = @"src\assets\marvelPlaceholder.png";
            }

            return comic;
        }
        //When adding comic if record already exitsts in db, only add line to join table to place in collection
        //Else if it doesn't exist, create it and then add to join table
        //

        //GetDetailsforFrontEndDisplay()
        //Goes gets relevenat details, put them somewhere through a controller to get at the front end

        //REST requests to marvel?


    }
}
