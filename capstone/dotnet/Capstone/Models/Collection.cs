using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Collection
    {
        public int CollectionId { get; set; }
        public int UserId { get; set; }
        public string CollectionName { get; set; }
        public List<Comic> ComicList { get; set; }
        public bool IsPublic { get; set; }


    }
}
