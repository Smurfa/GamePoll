using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GamePoll.Core.Infrastructure.Data;
using GamePoll.Core.Repositories.Entities;

namespace GamePoll.Core.Repositories
{
    internal class GameRepository : IRepository<GameEntity>
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public GameRepository(IDbConnectionFactory factory)
        {
            _connectionFactory = factory;
        }

        public async Task<IEnumerable<GameEntity>> GetAsync()
        {
            using (var connection = _connectionFactory.Create())
            {
                return await connection.QueryAsync<GameEntity>("SELECT * FROM GameData.Games");
            }
        }

        public async Task<GameEntity> GetAsync(int id)
        {
            using (var connection = _connectionFactory.Create())
            {
                return (await connection.QueryAsync<GameEntity>("SELECT * FROM GameData.Games WHERE Id = @Id",
                    new { Id = id })).SingleOrDefault();
            }
        }

        public async Task<int> AddAsync(GameEntity data)
        {
            using (var connection = _connectionFactory.Create())
            {
                const string query = @"INSERT INTO GameData.Games(Title, ImageUrl) VALUES (@Title, @ImageUrl)
SELECT CAST(SCOPE_IDENTITY() as int)";
                return (await connection.QueryAsync<int>(query, data)).SingleOrDefault();
            }
        }

        public async Task<bool> UpdateAsync(GameEntity data)
        {
            using (var connection = _connectionFactory.Create())
            {
                await connection.ExecuteAsync("UPDATE GameData.Games SET Title = @Title, ImageUrl = @ImageUrl WHERE Id = @Id",
                    data);
                return true;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.Create())
            {
                return await connection.ExecuteAsync("DELETE FROM GameData.Games WHERE Id = @Id", new { Id = id }) == 1;
            }
        }
    }
}
