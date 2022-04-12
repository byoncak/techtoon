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


        public Collection GetCollection(int collectionId)
        {
            Collection collection = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM collection WHERE collection_id = @collection_id", conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    collection = GetCollectionFromReader(reader);

                }

            }
            return collection;
        }
        public void AddToCollection(int comicId, int collectionId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO comics_collections (comic_id, collection_id) " +
                                                "VALUES (@comic_id, @collection_id); ", conn);
                cmd.Parameters.AddWithValue("@comic_id", comicId);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);

                cmd.ExecuteNonQuery();

            }
        }

        public Collection GetCollectionByUser(string username)
        {
            Collection collection = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT c.collection_name FROM collections c " +
                                                "JOIN users u ON c.user_id = u.user_id " +
                                                "WHERE u.username=@username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    collection = GetCollectionFromReader(reader);

                }

            }
            return collection;
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

    }
}

