﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class ComicSqlDao:IComicDAO
    {
        private readonly string connectionString;

        public ComicSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Comic CreateComic(Comic comic)
        {
            int newComicId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO comics (title, issue_number, description) " +
                    "OUTPUT INSERTED.comic_id " +
                    "VALUES (@title, @issue_number, @description);", conn);

                cmd.Parameters.AddWithValue("@title", comic.Title);
                cmd.Parameters.AddWithValue("@issue_number", comic.IssueNumber);
                cmd.Parameters.AddWithValue("@description", comic.Description);
                cmd.Parameters.AddWithValue("@marvel_id", comic.MarvelId);

                newComicId = Convert.ToInt32(cmd.ExecuteScalar());


            }
            return GetComic(newComicId);
        }
        public Comic GetComic(int comicId)
        {
            Comic comic = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM comics WHERE comic_id = @comic_id", conn);
                cmd.Parameters.AddWithValue("@comic_id", comicId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comic = GetComicFromReader(reader);
                }
            }
            return comic;
        }
        public Comic GetComicByTitle(string title)
        {
            Comic comic = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM comics WHERE title = @title", conn);
                cmd.Parameters.AddWithValue("@title", title);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comic = GetComicFromReader(reader);
                }
            }
            return comic;
        }
        public Comic GetComicByIssueNumber(int issueNumber)
        {
            Comic comic = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM comics WHERE issue_number = @issue_number", conn);
                cmd.Parameters.AddWithValue("@issue_number", issueNumber);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comic = GetComicFromReader(reader);
                }
            }
            return comic;

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
