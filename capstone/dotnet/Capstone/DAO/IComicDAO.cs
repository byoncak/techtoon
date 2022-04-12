using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IComicDAO
    {
        public Comic GetComic(int comicId);
        public Comic GetComicByTitle(string title);
        public Comic GetComicByIssueNumber(int issueNumber);
        public Comic CreateComic(Comic comic);

    }
}
