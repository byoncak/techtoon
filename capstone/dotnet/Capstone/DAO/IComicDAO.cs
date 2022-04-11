using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    interface IComicDAO
    {
        Comic GetComic(int comicId);
        Comic GetComicByTitle(string title);
        Comic GetComicByIssueNumber(int issueNumber);

    }
}
