using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TalentConnect.Domain.Queries
{
    public class Login : BaseQuery
    {
        private string _sqlCommand = @"SELECT 
                                    Id
                                    FROM USERS
                                    WHERE Email = @Email and HashedPassword = @HashedPassword";

        public async Task<bool> ExecuteQuery(string email, string hashedPassword)
        {
            bool authenticated = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(_sqlCommand))
                {
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar) { Value = email });
                    command.Parameters.Add(new SqlParameter("@HashedPassword", System.Data.SqlDbType.VarChar) { Value = hashedPassword });
                    connection.Open();
                    command.Connection = connection;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        authenticated = reader != null && reader.HasRows;
                    }
                }
            }
            return authenticated;
        }
    }
}