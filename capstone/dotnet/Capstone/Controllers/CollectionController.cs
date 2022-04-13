﻿using System;
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
            string userId = User.FindFirst("sub").Value;
            //int.TryParse(userId, out int userNumber);
            int userNumber = Convert.ToInt32(userId);
            return collectionDao.GetCollectionByUserId(userNumber);
        }

        [HttpGet("{userName}")]
        public List<Collection> GetCollectionsByName(string userName)
        {
            return collectionDao.GetCollectionByUser(userName);
        }

        [HttpPost("/collection")]
        public ActionResult<Collection> CreateCollection(Collection collection)
        {
            Collection added = collectionDao.CreateCollection(collection);
            return Created($"/collection/{added.CollectionId}", added); //Double Check this endpoint.
        }


        

        
        

    }
}