using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALBUM
{
    internal class dao
    {
        String Connection = "datasource=localhost;port=3306;username=root;password=root;database=memories;";
        public List<Album> getAllAlbums()
        {
            List<Album> returnThese = new List<Album>();
            MySqlConnection connection = new MySqlConnection(Connection);
            connection.Open();

            //define the sql statement to fetch all albums

            MySqlCommand command = new MySqlCommand(" SELECT * FROM albums   ", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        memory_name = reader.GetString(1),
                        person = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        image = reader.GetString(4),
                        description = reader.GetString(5)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();

            return returnThese;
        }

        public List<Album> searchTitles(String searchTerm)
        {
            List<Album> returnThese = new List<Album>();
            MySqlConnection connection = new MySqlConnection(Connection);
            connection.Open();

            String searchPhrase = "%" + searchTerm + "%";
            //define the sql statement to fetch all albums

            MySqlCommand command = new MySqlCommand();
            command.CommandText = " SELECT * FROM albums WHERE memory_title LIKE @search";
            command.Parameters.AddWithValue("@search", searchPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        memory_name = reader.GetString(1),
                        person = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        image = reader.GetString(4),
                        description = reader.GetString(5)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();

            return returnThese;
        }

        internal int addOneAlbum(Album album)
        {
            List<Album> returnThese = new List<Album>();
            MySqlConnection connection = new MySqlConnection(Connection);
            connection.Open();

            //define the sql statement to fetch all albums

            MySqlCommand command = new MySqlCommand("INSERT INTO `albums`(`memory_title`, `person`, `date`, `image_des`, `description`) VALUES (@memoryName,@prsn,@year,@img,@des)", connection);
            command.Parameters.AddWithValue("@memoryName", album.memory_name);
            command.Parameters.AddWithValue("@prsn", album.person);
            command.Parameters.AddWithValue("@year", album.Year);
            command.Parameters.AddWithValue("@img", album.image);
            command.Parameters.AddWithValue("@des", album.description);

            int newRows = command.ExecuteNonQuery();

            connection.Close();

            return newRows;
        }
        public List<highlights> getHighlights(int ID)
        {
            List<highlights> returnThese = new List<highlights>();
            MySqlConnection connection = new MySqlConnection(Connection);
            connection.Open();

            //define the sql statement to fetch all albums

            MySqlCommand command = new MySqlCommand();
            command.CommandText = " SELECT * FROM highlights WHERE albums_ID = @IDH";
            command.Parameters.AddWithValue("@IDH", ID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    highlights h = new highlights
                    {
                        IDH = reader.GetInt32(0),
                        title = reader.GetString(1),
                        number = reader.GetInt32(2),
                        videoURL = reader.GetString(3),
                        desc = reader.GetString(4)
                    };
                    returnThese.Add(h);
                }
            }
            connection.Close();

            return returnThese;
        } } }


