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
    public class ComicsController: ControllerBase
    {
        private readonly IComicDAO comicDao;

        public ComicsController(IComicDAO _comicDao)
        {
            comicDao = _comicDao;
        }

        [HttpPost()]
        public Comic CreateComic(Comic comic)
        {
            return comicDao.CreateComic(comic);
        }
        [HttpGet()]
        public List<Comic> GetListOfComics()
        {
            List<Comic> testList = new List<Comic>();

        }
        [HttpGet("{id}")]
        public Comic GetComicDetails(int id)
        {
            
        }
    }
}
