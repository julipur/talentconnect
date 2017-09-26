using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using TalentConnect.Domain.Model;

namespace TalentConnect.Domain.Queries
{
    public class GetCredentialsByEmailDto
    {
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public Role Role { get; set; }
    }

    public class GetCredentialsByEmail : BaseQuery
    {
        private string _sqlCommand = @"SELECT 
                                    HashedPassword, PasswordSalt, Role
                                    FROM USERS
                                    WHERE Email = @Email";

        public async Task<GetCredentialsByEmailDto> ExecuteQuery(string email)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(_sqlCommand))
                {
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar) { Value = email });
                    connection.Open();
                    command.Connection = connection;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader != null && reader.HasRows)
                        {
                            reader.Read();
                            return new GetCredentialsByEmailDto()
                            {
                                HashedPassword = reader.GetString(0),
                                PasswordSalt = reader.GetString(1),
                                Role = (Role)reader.GetInt32(2)
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}