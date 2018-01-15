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

        public async Task<IEnumerable<GameEntity>> Get()
        {
            using (var connection = _connectionFactory.Create())
            {
                return await connection.QueryAsync<GameEntity>("SELECT * FROM GameData.Games");
            }
        }

        public async Task<GameEntity> Get(int id)
        {
            using (var connection = _connectionFactory.Create())
            {
                return (await connection.QueryAsync<GameEntity>("SELECT * FROM GameData.Games WHERE Id = @Id", new { Id = id })).SingleOrDefault();
            }
        }

        public async Task Add(GameEntity data)
        {
            using (var connection = _connectionFactory.Create())
            {
                var id = await connection.ExecuteAsync("INSERT INTO GameData.Games(Title, ImageUrl) VALUES (@Title, @ImageUrl)",
                    data);
                var temp = 0;
            }
        }

        public async Task Update(GameEntity data)
        {
            using (var connection = _connectionFactory.Create())
            {
                await connection.ExecuteAsync("UPDATE GameData.Games SET Title = @Title, ImageUrl = @ImageUrl WHERE Id = @Id",
                    data);
            }
        }
    }
}
