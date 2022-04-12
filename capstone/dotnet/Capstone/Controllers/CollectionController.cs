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

        [HttpGet()]
        //List of collections is public

        //public int GetCurrentUser()
        //{
        //    string userId = User.FindFirst("sub").Value;
        //    int.TryParse(userId, out int userNumber);
        //    return userNumber;
        //}

        [HttpGet()]
        //list of "my" collection 

        [HttpGet()]
        //other user collection 

        [HttpPost]
        //create the collection 

        [HttpDelete]


    }
}
