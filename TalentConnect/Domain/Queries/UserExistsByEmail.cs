using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace TalentConnect.Domain.Queries
{
    public class UserExistsByEmail : BaseQuery
    {
        private string _sqlCommand = @"SELECT 
                                    Id
                                    FROM USERS
                                    WHERE Email = @Email";

        public async Task<bool> ExecuteQuery(string email)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(_sqlCommand))
                {
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar) { Value = email });
                    connection.Open();
                    command.Connection = connection;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        exists = reader != null && reader.HasRows;
                    }
                }
            }
            return exists;
        }
    }
}