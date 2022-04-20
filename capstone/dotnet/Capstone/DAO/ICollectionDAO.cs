using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ICollectionDAO
    {
        public bool AddComicToCollection(int comicId, int collectionId);

        public Collection GetCollection(int collectionId);
        public Collection CreateCollection(Collection collection);

        //public int GetCollectionStats(int collectionId);
        //public int AggregateAllStats();

        public List<Collection> GetCollectionByUserName(string username);

        public List<Collection> GetCollectionByUserId(int userid);

        public List<Collection> GetAllCollections();

        public List<Comic> GetComicsInCollection(int collectionId);
       

        public List<Collection> GetOtherPublicCollection(int userId);
        public List<Statistics.CharacterStats> TotalComicsInCollectionByCharacter(int collectionId);
        public Statistics TotalComicsInCollection(int collectionId);

        public void DeleteComicFromCollection(int comicId, int collectionId);
        public List<Statistics.UserStats> TotalComicsInCollectionsByUserName();

        public List<Statistics.CharacterStats> GetCharacterForLeaderBoard();

        public List<Comic.Image> GetCollectionImage(int userId, int collectionId);

    }
}
