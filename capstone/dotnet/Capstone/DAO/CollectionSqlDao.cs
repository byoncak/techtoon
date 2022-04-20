using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Capstone.DAO
{
    public class CollectionSqlDao : ICollectionDAO
    {
        private readonly string connectionString;

        

        public CollectionSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Collection CreateCollection(Collection collection)
        {
            int newCollectionId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO collections(user_id, collection_name, is_public) " +
                    "OUTPUT INSERTED.collection_id " +
                    "VALUES(@user_id, @collection_name, @is_public);", conn);

                cmd.Parameters.AddWithValue("@user_id", collection.UserId);
                cmd.Parameters.AddWithValue("@collection_name", collection.CollectionName);
                cmd.Parameters.AddWithValue("@is_public", collection.IsPublic);

                newCollectionId = Convert.ToInt32(cmd.ExecuteScalar());


            }
            return GetCollection(newCollectionId);
        }

        public List<Collection> GetAllCollections()
        {
            List<Collection> collections = new List<Collection>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM collections c;", conn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Collection collection = GetCollectionFromReader(reader);
                    collections.Add(collection);

                }

            }
            return collections;
        }

        public Collection GetCollection(int collectionId)
        {
            Collection collection = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM collections WHERE collection_id = @collection_id", conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    collection = GetCollectionFromReader(reader);

                }

                return collection;
            }
        }
        public List<Collection> GetOtherPublicCollection(int userId)
        {
            List<Collection> collections = new List<Collection>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM collections WHERE user_id !=@user_Id AND is_public= 0", conn);
                cmd.Parameters.AddWithValue("@user_Id ", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Collection collection = GetCollectionFromReader(reader);
                    collections.Add(collection);
                }

            }
            return collections;
        }

        public List<Comic> GetComicsInCollection(int collectionId) 
        {
            List<Comic> comicList = new List<Comic>();
            Comic comic = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand ("SELECT * FROM comics JOIN comics_collections cc ON comics.comic_id = cc.comic_id" +
                    " Join collections c ON c.collection_id = cc.collection_id WHERE c.collection_id = @collection_id", conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comic = GetComicFromReader(reader);
                    comicList.Add(comic);
                }

            }
            return comicList;  
        }

        public int CheckComicInCollection(int comicId, int collectionId)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT (*) FROM comics_collections WHERE comic_id=@comic_id AND collection_id=@collection_id;", conn);
                cmd.Parameters.AddWithValue("@comic_id", comicId);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);

                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return count;
        }

        public bool AddComicToCollection(int comicId, int collectionId)
        {
            bool inCollection = false;
            int checkBeforeAdd = CheckComicInCollection(comicId, collectionId);
            if (checkBeforeAdd == 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //Error handle for duplicate add
                    conn.Open();


                    SqlCommand cmd = new SqlCommand("INSERT INTO comics_collections (comic_id, collection_id) " +
                                                    "VALUES (@comic_id, @collection_id); ", conn);
                    cmd.Parameters.AddWithValue("@comic_id", comicId);
                    cmd.Parameters.AddWithValue("@collection_id", collectionId);

                    cmd.ExecuteNonQuery();

                }
                inCollection = true;
            }
            return inCollection;

        }

        public void DeleteComicFromCollection(int comicId, int collectionId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("DELETE FROM comics_collections WHERE comic_id=@comic_id AND collection_id=@collection_id; ", conn);
                cmd.Parameters.AddWithValue("@comic_id", comicId);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Collection> GetCollectionByUserName(string username)
        {
            List<Collection> collections = new List<Collection>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT c.collection_name FROM collections c " +
                                                "JOIN users u ON c.user_id = u.user_id " +
                                                "WHERE u.username=@username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Collection collection = GetCollectionFromReader(reader);
                    collections.Add(collection);

                }

            }
            return collections;
        }

        public List<Collection> GetCollectionByUserId(int userId)
        {
            List<Collection> collections = new List<Collection>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM collections c " +
                                                "JOIN users u ON c.user_id = u.user_id " +
                                                "WHERE u.user_id=@user_id", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Collection collection = GetCollectionFromReader(reader);
                    collections.Add(collection);
                    
                }

            }
            return collections;
        }

        public List<Comic.Image> GetCollectionImage(int collectionId, int userId)
        {
            List<Comic.Image> collectionsImage = new List<Comic.Image>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP(5) c.cover_img FROM collections co " +
                    "JOIN comics_collections cc ON co.collection_id=cc.collection_id " +
                    "JOIN comics c ON c.comic_id=cc.comic_id WHERE user_id =@user_id AND co.collection_id=@collection_id; ", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@collection_Id", collectionId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comic.Image comic = GetCollectionImageFromReader(reader);
                    collectionsImage.Add(comic);

                }
            }
            return collectionsImage;
        }

        //THIS IS A BASIC STATS QUERY WE CAN TEST OUR FRONT END WITH
        public Statistics TotalComicsInCollection(int collectionId)
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Statistics stats = new Statistics();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT (*) as totalComics FROM comics_collections WHERE collection_id = @collection_id", conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);
               
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    stats.TotalComicCount = Convert.ToInt32(reader["totalComics"]);
                }
                return stats;
            }
        }

        public List<Statistics.UserStats> TotalComicsInCollectionsByUserName()
        {
            List<Statistics.UserStats> stats = new List<Statistics.UserStats>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT u.username, COUNT(*) as total FROM comics_collections cc JOIN collections c  ON cc.collection_id = c.collection_id " +
                    "JOIN users u ON c.user_id = u.user_id GROUP BY u.username ORDER BY (total) DESC", conn);

                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    stats.Add(GetUserStatsFromReader(reader));

                }
                return stats;

            }
        }
        public List<Statistics.CharacterStats> TotalComicsInCollectionByCharacter(int collectionId)
        {
            List<Statistics.CharacterStats> stats = new List<Statistics.CharacterStats>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT co.main_character, COUNT (*) as total from comics_collections cc JOIN collections c on c.collection_id = cc.collection_id " +
                                                "JOIN comics co on co.comic_id = cc.comic_id " +
                                                "where c.collection_id = @collection_id GROUP BY main_character", conn);
                
                cmd.Parameters.AddWithValue("@collection_id", collectionId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    stats.Add(GetCharStatsFromReader(reader));

                }
                return stats;

            }
        }

        public List<Statistics.CharacterStats> GetCharacterForLeaderBoard()
        {
            List<Statistics.CharacterStats> stats = new List<Statistics.CharacterStats>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT c.main_character, COUNT (main_character) as total FROM comics c " +
                    "JOIN comics_collections cc ON c.comic_id = cc.comic_id " +
                    "WHERE c.main_character != 'Unknown' " +
                    "GROUP BY c.main_character ORDER BY(total) DESC", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    stats.Add(GetCharStatsFromReader(reader));

                }
                return stats;

            }
        }

        public Statistics TotalComicsInAllCollections()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Statistics stats = new Statistics();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT (*) as totalComics FROM comics_collections;", conn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    stats.TotalComicCount = Convert.ToInt32(reader["totalComics"]);
                }
                return stats;
            }
        }

        private Collection GetCollectionFromReader(SqlDataReader reader)
        {
                Collection c = new Collection()
                {
                    CollectionId = Convert.ToInt32(reader["collection_id"]),
                    UserId = Convert.ToInt32(reader["user_id"]),
                    CollectionName = Convert.ToString(reader["collection_name"]),
                    IsPublic = Convert.ToBoolean(reader["is_public"]),

                };

                return c;
        }

        private Comic GetComicFromReader(SqlDataReader reader)
        {
            Comic comic = new Comic()
            {
                ComicId = Convert.ToInt32(reader["comic_id"]),
                Title = Convert.ToString(reader["title"]),
                IssueNumber = Convert.ToInt32(reader["issue_number"]),
                Description = Convert.ToString(reader["description"]),
                MarvelId = Convert.ToInt32(reader["marvel_id"]),
                CoverImage = Convert.ToString(reader["cover_img"]),
                MainCharacter = Convert.ToString(reader["main_character"])

            };

            return comic;
        }

        private Comic.Image GetCollectionImageFromReader(SqlDataReader reader)
        {
            Comic.Image comic = new Comic.Image()
            {
                CoverImage = Convert.ToString(reader["cover_img"]),
            };
            return comic;
        }

        private Statistics.CharacterStats GetCharStatsFromReader(SqlDataReader reader)
        {
            Statistics.CharacterStats stats = new Statistics.CharacterStats()
            {
                Name = Convert.ToString(reader["main_character"]),
                IssueCount = Convert.ToInt32(reader["total"])
            };

            return stats;
        
        }

        private Statistics.UserStats GetUserStatsFromReader(SqlDataReader reader)
        {
            Statistics.UserStats stats = new Statistics.UserStats()
            {
                UserName = Convert.ToString(reader["username"]),
                TotalCount = Convert.ToInt32(reader["total"])
            };

            return stats;

        }




    }
}

