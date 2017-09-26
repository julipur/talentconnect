using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TalentConnect.Domain.Queries
{
    public class GetJobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string JobType { get; set; }
        public int? YearsOfExperience { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int? Hours { get; set; }
        public string Rate { get; set; }
        public bool Filled { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GetJobById : BaseQuery
    {
        private string _sqlCommand = @"SELECT 
                                    Id
                                    ,Title
                                    ,ShortDescription
                                    ,Description
                                    ,City
                                    ,Province
                                    ,JobType
                                    ,YearsOfExperience
                                    ,ClosingDate
                                    ,Hours
                                    ,Rate
                                    ,Filled
                                    ,Active
                                    ,CreatedDate FROM Jobs
                                    WHERE Id = @Id";


        public GetJobDto ExecuteQuery(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_sqlCommand))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = id });
                    connection.Open();
                    cmd.Connection = connection;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            reader.Read();

                            return new GetJobDto()
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                ShortDescription = reader.GetString(2),
                                Description = reader.GetString(3),
                                City = reader.GetString(4),
                                Province = reader.GetString(5),
                                JobType = reader.GetString(6),
                                YearsOfExperience = reader.GetInt32(7),
                                ClosingDate = reader.GetDateTime(8),
                                Hours = reader.GetInt32(9),
                                Rate = reader.GetString(10),
                                Filled = reader.GetBoolean(11),
                                Active = reader.GetBoolean(12),
                                CreatedDate = reader.GetDateTime(13)
                            };

                        }
                    }
                } 
            }
            return null;
        }
    }
}