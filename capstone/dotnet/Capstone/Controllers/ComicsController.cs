using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Capstone.Services;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ComicsController : ControllerBase
    {
        private readonly IComicDAO comicDao;
        private readonly IApiService apiService;

        public ComicsController(IComicDAO _comicDao, IApiService _apiService)
        {
            comicDao = _comicDao;
            apiService = _apiService;

        }

        [HttpPost()]
        public Comic CreateComic(Comic comic)
        {
            return comicDao.CreateComic(comic);
        }
        [HttpGet()]
        public List<Comic> GetListOfComics()
        {
            return apiService.GetComicsFromMarvel();
            //List<Comic> testList = new List<Comic>();
            //Comic a = new Comic(111, "spider-test", "https://cdn.vectorstock.com/i/1000x1000/35/52/placeholder-rgb-color-icon-vector-32173552.webp");
            //testList.Add(a);
            //Comic b = new Comic(222, "Hulk test", "https://cdn.vectorstock.com/i/1000x1000/35/52/placeholder-rgb-color-icon-vector-32173552.webp");
            //testList.Add(b);
            //return testList;

        }
        [HttpGet("{id}")]
        public Comic GetComicDetails(int id)
        {
            return apiService.GetComicDetailsfromMarvel(id);
            //Comic c = new Comic(id, "Iron test", "https://cdn.vectorstock.com/i/1000x1000/35/52/placeholder-rgb-color-icon-vector-32173552.webp");
            //return c;
        }

        [HttpGet("searchTitle")]
        public List<Comic> GetComicsFromMarvelByTitle(string titleSearch)
        {
            return apiService.GetComicsFromMarvelByTitle(titleSearch);
        }
    }
}
