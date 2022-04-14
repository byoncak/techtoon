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
    [Authorize]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionDAO collectionDao;

        public CollectionController(ICollectionDAO _collectionDao)
        {
            collectionDao = _collectionDao;
        }

        [HttpGet("/collections/my-collections")]
        public List<Collection> GetMyCollections()
        {
            string userId = User.FindFirst("sub")?.Value;
            //int.TryParse(userId, out int userNumber);
            int userNumber = Convert.ToInt32(userId);
            return collectionDao.GetCollectionByUserId(userNumber);
        }

        [HttpGet("{userName}")]
        public List<Collection> GetCollectionsByName(string userName)
        {
            return collectionDao.GetCollectionByUserName(userName);
        }

        [HttpPost("/collections")]
        public ActionResult<Collection> CreateCollection(Collection collection)
        {
            string userId = User.FindFirst("sub").Value;
            int userNumber = Convert.ToInt32(userId);
            collection.UserId = userNumber;
            Collection added = collectionDao.CreateCollection(collection);
            return Created($"/collection/{added.CollectionId}", added); //Double Check this endpoint.
        }
        //[HttpPost()] //endpoint TBD
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
