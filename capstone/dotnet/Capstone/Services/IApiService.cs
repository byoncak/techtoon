using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.Services
{
    public interface IApiService
    {
        public List<Comic> GetComicsFromMarvel(string queryString);
        public Comic GetComicDetailsfromMarvel(int marvelId);
        public Comic AddOrCreateComic(Comic comic);

    }
}
