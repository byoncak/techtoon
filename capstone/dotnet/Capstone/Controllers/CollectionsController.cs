﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using Capstone.Services;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionDAO collectionDao;
        private readonly IApiService apiService;

        public CollectionsController(ICollectionDAO _collectionDao, IApiService _apiService)
        {
            collectionDao = _collectionDao;
            apiService = _apiService;
        }
        [HttpGet()]
        public List<Collection> GetAllCollections()
        {
            return collectionDao.GetAllCollections();
        }

        [HttpGet("my-collections")]
        public List<Collection> GetMyCollections()
        {
            string userId = User.FindFirst("sub")?.Value;
            //int.TryParse(userId, out int userNumber);
            int userNumber = Convert.ToInt32(userId);
            return collectionDao.GetCollectionByUserId(userNumber);
        }
        [HttpGet("{id}")]
        public Collection GetCollectionByCollectionID(int id)
        {
            return collectionDao.GetCollection(id);
        }

        [HttpGet("users/{userId}/collections/")]
        public List<Collection> GetCollectionsByUserID(int userId)
        {
            return collectionDao.GetCollectionByUserId(userId);
        }

        //[HttpGet("users/{userName}/collections")]
        //public List<Collection> GetCollectionsByName(string userName)
        //{
        //    return collectionDao.GetCollectionByUserName(userName);
        //}

        [HttpPost()]
        public ActionResult<Collection> CreateCollection(Collection collection)
        {
            string userId = User.FindFirst("sub").Value;
            int userNumber = Convert.ToInt32(userId);
            collection.UserId = userNumber;
            Collection added = collectionDao.CreateCollection(collection);
            return Created($"/collection/{added.CollectionId}", added);
        }

        [HttpGet("{id}/comics")]
        public List<Comic> GetComicsInCollection(int id)
        {
            return collectionDao.GetComicsInCollection(id);
        }

        [HttpGet("public-collection")]
        public List<Collection> GetOtherPublicCollection()
        {
            string id = User.FindFirst("sub").Value;
            int userNumber = Convert.ToInt32(id);
            return collectionDao.GetOtherPublicCollection(userNumber);
        }

        [HttpPost("{id}/comics")] //endpoint TBD
        public bool AddComicToCollection(Comic comic, int id) //return type ok?
        {
                        
           Comic comicToAdd = apiService.AddOrCreateComic(comic);

           return collectionDao.AddComicToCollection(comicToAdd.ComicId, id);
        }

        [HttpGet("{id}/stats/characters")]
        public List<Statistics.CharacterStats> CharacterStatsForCollection(int id)
        {
            return collectionDao.TotalComicsInCollectionByCharacter(id);
        }

        [HttpGet("{id}/stats")]
        public Statistics TotalComicsInCollection(int id)
        {
            return collectionDao.TotalComicsInCollection(id);
        }
   
    }
}
