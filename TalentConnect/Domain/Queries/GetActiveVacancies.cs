using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TalentConnect.Domain.Queries
{
    public class GetActiveVacancyDto
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
    }

    public class GetActiveVacancies : BaseQuery
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
                                    ,CreatedDate FROM Jobs where Active = 1";

        public IEnumerable<GetActiveVacancyDto> ExecuteQuery()
        {
            var list = new List<GetActiveVacancyDto>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(_sqlCommand))
                {
                    connection.Open();
                    command.Connection = connection;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(new GetActiveVacancyDto()
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
                                    Rate = reader.GetString(10)
                                });
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}