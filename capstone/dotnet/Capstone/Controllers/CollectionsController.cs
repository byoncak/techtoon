using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionDAO collectionDao;

        public CollectionsController(ICollectionDAO _collectionDao)
        {
            collectionDao = _collectionDao;
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

        [HttpGet("{userName}")]
        public List<Collection> GetCollectionsByName(string userName)
        {
            return collectionDao.GetCollectionByUserName(userName);
        }

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

        //[HttpPost("add-comic")] //endpoint TBD
        //public void AddComicToCollection(Comic comic, Collection collection) //return type ok?
        //{

        //    collectionDao.AddComicToCollection(comic.ComicId, collection.CollectionId);


        //    //if comic doesn't exist in database
        //    //comicdao.CreateComic THEN
        //    //collectiondao.AddComicToCollection

        //    //    //if comic does exist in database
        //    //    //ONLY DO collectiondao.AddComicToCollection

        //    //    //STILL TO CONFIRM: proper method for acquiring marvel_ID at this stage from Marvel API

        //    //}

        //    //public ActionResult<>






        //}


    }
}
