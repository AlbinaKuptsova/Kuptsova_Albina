using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApp.DAL
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public string FileName { get; set; }
        public string Owner { get; set; }
        public int Likes { get; set; }

        public Photo()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }

    public class DataAccessLayer
    {
        private string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        public int AddNewPhoto(Photo photo)
        {
            string queryString = @"insert into dbo.Photos(Name, Description, UploadDate, FileName, Owner) OUTPUT Inserted.ID values (@Name, @Description, @UploadDate, @FileName, @Owner);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", photo.Name));
                    command.Parameters.Add(new SqlParameter("@Description", photo.Description));
                    command.Parameters.Add(new SqlParameter("@UploadDate", photo.UploadDate));
                    command.Parameters.Add(new SqlParameter("@FileName", photo.FileName));
                    command.Parameters.Add(new SqlParameter("@Owner", photo.Owner));

                    photo.Id = (int)command.ExecuteScalar();
                }
            }
            return photo.Id;
        }

        public void DeletePhoto(string filename, string username)
        {
            string queryString = @"delete from dbo.Photos where FileName = @FileName AND Owner = @Owner;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@FileName", filename));
                    command.Parameters.Add(new SqlParameter("@Owner", username));
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Photo> GetAllPhotos(string username = "")
        {
            var result = new List<Photo>();
            string queryString = "select * from dbo.vw_Photos"; // TODO: order by UploadDate
            if (!string.IsNullOrEmpty(username))
            {
                queryString += "\n";
                queryString += "where Owner=@Owner";
            }

            queryString += "\n";
            queryString += "order by UploadDate desc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    if (!string.IsNullOrEmpty(username))
                    {
                        command.Parameters.Add(new SqlParameter("@Owner", username));
                    }
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            var photo = new Photo();
                            photo.Id = Convert.ToInt32(reader["ID"]);
                            photo.Name = Convert.ToString(reader["Name"]);
                            photo.Description = Convert.ToString(reader["Description"]);
                            photo.UploadDate = Convert.ToDateTime(reader["UploadDate"]);
                            photo.FileName = Convert.ToString(reader["FileName"]);
                            photo.Owner = Convert.ToString(reader["Owner"]);
                            photo.Likes = Convert.ToInt32(reader["Likes"]);
                            result.Add(photo);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }

            return result;
        }

        public Photo GetPhoto(int photoId)
        {
            var result = new List<Photo>();
            string queryString = "select TOP 1 * from dbo.vw_Photos";
            queryString += "\n";
            queryString += "where ID=@PhotoId";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PhotoId", photoId));
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            var photo = new Photo();
                            photo.Id = Convert.ToInt32(reader["ID"]);
                            photo.Name = Convert.ToString(reader["Name"]);
                            photo.Description = Convert.ToString(reader["Description"]);
                            photo.UploadDate = Convert.ToDateTime(reader["UploadDate"]);
                            photo.FileName = Convert.ToString(reader["FileName"]);
                            photo.Owner = Convert.ToString(reader["Owner"]);
                            photo.Likes = Convert.ToInt32(reader["Likes"]);
                            result.Add(photo);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }

            return result.Count == 1 ? result[0] : null;
        }

        public Result AddLike(int photoId, string username)
        {
            string queryString = "insert into dbo.Likes (PhotoID, Username)\n" +
                                 "select @PhotoID, @Username\n" +
                                 "where not exists (select PhotoID, Username from dbo.Likes where PhotoID=@PhotoID and Username=@Username);";

            var rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PhotoID", photoId));
                    command.Parameters.Add(new SqlParameter("@Username", username));
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            var result = new Result();
            result.added = rowsAffected > 0;

            var photo = GetPhoto(photoId);
            if (photo != null)
                result.likes = photo.Likes;


            return result;
        }

        public class Result
        {
            public bool added { get; set; }
            public int likes { get; set; }
        }
    }
}