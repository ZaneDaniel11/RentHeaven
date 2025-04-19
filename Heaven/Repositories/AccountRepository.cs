using Dapper;
using System.Data.SQLite;
using Heaven.Models;

namespace Heaven.Repositories
{
    public class AccountRepository
    {
        private readonly string _connectionString = "Data Source=Rent.db";

        public void Insert(User user)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO Users 
                    (FullName, Email, PasswordHash, PhoneNumber, Bio, CreatedAt, IsHost)
                    VALUES 
                    (@FullName, @Email, @PasswordHash, @PhoneNumber, @Bio, @CreatedAt, @IsHost)";

                connection.Execute(query, user);
                connection.Close();
            }
        }
    }
}
