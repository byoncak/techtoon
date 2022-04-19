﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Statistics
    {   
        public int TotalComicCount { get; set; }

        public class CharacterStats
        {
            public string Name { get; set; }
            public int IssueCount { get; set; }
        }

        public class UserStats
        {
            public string UserName { get; set; }
            public int TottalCount { get; set; }

        }

    }
}
