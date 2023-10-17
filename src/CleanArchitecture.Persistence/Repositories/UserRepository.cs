using Domain.IRepository;
using System.Data.SqlClient;
using Dapper;
using Persistence;

namespace Domain
{
    public class UserRepository : IUserRepository
    {
        private const string connectionString = Database.ConnectionString;
        private SqlConnection connection;
        private const string TABLE_NAME = "User";
        public UserRepository()
        {
            connection = new SqlConnection(connectionString);
        }

        public async Task<List<User>> GetAllUser()
        {
            var sqlCommand = $"select * from [{TABLE_NAME}]";

            var users = await connection.QueryAsync<User>(sqlCommand);


            return users.ToList();
        }

        public async Task<User> GetUserById(long id)
        {
            var sqlCommand = $"select * from [{TABLE_NAME}] where Id =@id";
            var parameters = new { id = id };
            var users = await connection.QueryAsync<User>(sqlCommand, parameters);

            return users.SingleOrDefault();
        }

        public async Task<User> GetUserByName(string name)
        {
            var sqlCommand = $"select * from [{TABLE_NAME}] where Name =@name";
            var parameters = new { name = name };
            var user = await connection.QueryAsync<User>(sqlCommand, parameters);

            return user.SingleOrDefault();
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            var sqlCommand = $"select * from [{TABLE_NAME}] where Phone =@phone";
            var parameters = new { phone = phone };
            var user = await connection.QueryAsync<User>(sqlCommand, parameters);

            return user.SingleOrDefault();
        }

        public async Task Add(User user)
        {
            var sqlCommand = $"INSERT INTO [dbo].[{TABLE_NAME}] ([Name], [Phone], [Password], [Status], [MaatLimitation]) VALUES (@name, @phone, @password, @status, @maatLimitation)";
            var parameters = new
            {
                name = user.Name,
                phone = user.Phone,
                password = user.Password,
                status = user.Status,
                maatLimitation = user.MaatLimitation,
            };

            await connection.ExecuteAsync(sqlCommand, parameters);
        }

        public async Task<int> DeleteById(long id)
        {
            var sqlCommand = $"Delete from [{TABLE_NAME}] where Id = @id";
            var parameters = new { id = id };

            var rowAffected = await connection.ExecuteAsync(sqlCommand, parameters);

            return rowAffected;
        }

        public async Task<int> Update(User user)
        {
            var sqlCommand = $"UPDATE [dbo].[{TABLE_NAME}]\r\n SET [Name] = @name\r\n ,[Status] = @status\r\n ,[MaatLimitation] = @maatLimitation\r\n WHERE Id = @id";
            var parameters = new
            {
                id = user.Id,
                name = user.Name,
                status = user.Status,
                maatLimitation = user.MaatLimitation,
            };

            var rowAffected = await connection.ExecuteAsync(sqlCommand, parameters);

            return rowAffected;
        }
    }
}
