﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Comic
    {
        public int ComicId { get; set; }
        public string Title { get; set; }
        public int IssueNumber { get; set; }
        public string Discription { get; set; }
        public string CoverImage { get; set; }

    }
}
