using System;
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
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet("public-collection")]
        public List<Collection> GetOtherPublicCollection()
        {
            string id = User.FindFirst("sub")?.Value;
            if (id != null)
            {
                int userNumber = Convert.ToInt32(id);
                return collectionDao.GetOtherPublicCollection(userNumber);
            }
            else
            {
                return collectionDao.GetOtherPublicCollection(0);
            }
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
        [AllowAnonymous]
        [HttpGet("stats/users")]
        public List<Statistics.UserStats> TotalComicsForCollectionByUsername()
        {
            return collectionDao.TotalComicsInCollectionsByUserName();
        }
        [AllowAnonymous]
        [HttpGet("stats/characters")]
        public List<Statistics.CharacterStats> GetCharacterForLeaderBoard()
        {
            return collectionDao.GetCharacterForLeaderBoard();
        }
        
        [HttpGet("{id}/stats")]
        public Statistics TotalComicsInCollection(int id)
        {
            return collectionDao.TotalComicsInCollection(id);
        }

        [HttpPut("{collectionId}/comics/{comicId}")]
        public void DeleteComicFromCollection(int comicId, int collectionId)
        {
            collectionDao.DeleteComicFromCollection(comicId, collectionId);
        }

        [HttpGet("{id}/comicsImages")]
        public List<Comic.Image> GetCollectionImage(int id)
        {
            string user = User.FindFirst("sub").Value;
            int userNumber = Convert.ToInt32(user);
            return collectionDao.GetCollectionImage(id, userNumber);
        }


    }
}
