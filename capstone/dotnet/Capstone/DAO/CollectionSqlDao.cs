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
        public void AddComicToCollection(int comicId, int collectionId)
        {
            try {
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
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
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
        
        //THIS IS A BASIC STATS QUERY WE CAN TEST OUR FRONT END WITH
        public int TotalComicsInCollection(int collectionId)
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT (*) FROM comics_collections WHERE collection_id = @collection_id", conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);
                return Convert.ToInt32(cmd.ExecuteScalar());


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
                MarvelId = Convert.ToInt32(reader["marvel_id"])

            };

            return comic;
        }


    }
}

