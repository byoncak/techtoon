using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ICollectionDAO
    {
        public void AddComicToCollection(int comicId, int collectionId);

        public Collection GetCollection(int collectionId);
        public Collection CreateCollection(Collection collection);

        //public int GetCollectionStats(int collectionId);
        //public int AggregateAllStats();

        public List<Collection> GetCollectionByUserName(string username);

        public List<Collection> GetCollectionByUserId(int userid);

        //
        
    }
}
