using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TalentConnect.Domain.Queries
{
    public class GetJobsDto
    {
        public IEnumerable<GetJobDto> Jobs { get; set; }
    }

    public class GetJobs :  BaseQuery
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
                                    ,CreatedDate FROM Jobs";


        
        public async Task<IEnumerable<GetJobDto>> ExecuteQuery()
        {
            var list = new List<GetJobDto>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(_sqlCommand))
                {
                    connection.Open();
                    command.Connection = connection;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader != null && reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(new GetJobDto()
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