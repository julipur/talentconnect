using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TalentConnect.Domain.Commands
{
    public class UpdateJobCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string JobType { get; set; }
        public string ClosingDate { get; set; }
        public int? YearOfExperince { get; set; }
        public int? Hours { get; set; }
        public string Rate { get; set; }
        public bool Filled { get; set; }
        public bool Active { get; set; }
    }

    public class UpdateJobCommandHandler : BaseCommandHandler
    {
        private string _sqlCommand = @"update Jobs set
                                Title = @Title, 
                                ShortDescription = @ShortDescription, 
                                Description = @Description, 
                                City = @City, 
                                Province = @Province, 
                                JobType = @JobType, 
                                YearsOfExperience = @YearsOfExperience, 
                                ClosingDate = @ClosingDate, 
                                Hours = @Hours, 
                                Rate = @Rate, 
                                Active = @Active, 
                                Filled = @Filled 
                                WHERE Id = @Id";

        public async Task HandleAsync(UpdateJobCommand command)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_sqlCommand))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = command.Id });
                    cmd.Parameters.Add(new SqlParameter("@Title", System.Data.SqlDbType.NVarChar) { Value = command.Title });
                    cmd.Parameters.Add(new SqlParameter("@ShortDescription", System.Data.SqlDbType.NVarChar) { Value = command.ShortDescription });
                    cmd.Parameters.Add(new SqlParameter("@Description", System.Data.SqlDbType.NVarChar) { Value = command.Description });
                    cmd.Parameters.Add(new SqlParameter("@City", System.Data.SqlDbType.NVarChar) { Value = command.City });
                    cmd.Parameters.Add(new SqlParameter("@Province", System.Data.SqlDbType.NVarChar) { Value = command.Province });
                    cmd.Parameters.Add(new SqlParameter("@JobType", System.Data.SqlDbType.NVarChar) { Value = command.JobType });
                    cmd.Parameters.Add(new SqlParameter("@YearsOfExperience", System.Data.SqlDbType.Int) { Value = command.YearOfExperince });
                    cmd.Parameters.Add(new SqlParameter("@ClosingDate", System.Data.SqlDbType.DateTime) { Value = command.ClosingDate });
                    cmd.Parameters.Add(new SqlParameter("@Hours", System.Data.SqlDbType.Int) { Value = command.Hours });
                    cmd.Parameters.Add(new SqlParameter("@Rate", System.Data.SqlDbType.NVarChar) { Value = command.Rate });
                    cmd.Parameters.Add(new SqlParameter("@Active", System.Data.SqlDbType.Bit) { Value = command.Active });
                    cmd.Parameters.Add(new SqlParameter("@Filled", System.Data.SqlDbType.Bit) { Value = command.Filled });
                    cmd.Parameters.Add(new SqlParameter("@CreatedDate", System.Data.SqlDbType.Date) { Value = DateTime.Now });

                    connection.Open();
                    cmd.Connection = connection;
                    await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
        }
    }
}