using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TalentConnect.Domain.Queries;

namespace TalentConnect.Domain.Commands
{
    public class AddUserCommand
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public int Role { get; set; }
    }

    public class AddUserCommandHandler : BaseCommandHandler
    {
        private string _sqlCommand = @"INSERT INTO Users
                                (Email, FirstName, LastName, HashedPassword, PasswordSalt, Role)
                                 VALUES(@Email, @FirstName, @LastName, @HashedPassword, @PasswordSalt, @Role)";

        public async Task HandleAsync(AddUserCommand command)
        {
            if (await new UserExistsByEmail().ExecuteQuery(command.Email))
                return;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_sqlCommand))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar) { Value = command.Email });
                    cmd.Parameters.Add(new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar) { Value = command.FirstName });
                    cmd.Parameters.Add(new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar) { Value = command.LastName });
                    cmd.Parameters.Add(new SqlParameter("@HashedPassword", System.Data.SqlDbType.NVarChar) { Value = command.HashedPassword });
                    cmd.Parameters.Add(new SqlParameter("@PasswordSalt", System.Data.SqlDbType.NVarChar) { Value = command.PasswordSalt });
                    cmd.Parameters.Add(new SqlParameter("@Role", System.Data.SqlDbType.Int) { Value = command.Role });
                    
                    connection.Open();
                    cmd.Connection = connection;
                    await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
        }

    }
}