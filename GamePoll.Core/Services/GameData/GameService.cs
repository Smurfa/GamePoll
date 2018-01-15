using System.Collections.Generic;
using System.Threading.Tasks;
using GamePoll.Core.Repositories;
using GamePoll.Core.Repositories.Entities;

namespace GamePoll.Core.Services.GameData
{
    public class GameService : IGameService
    {
        private readonly IRepository<GameEntity> _repository;

        public GameService(IRepository<GameEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GameEntity>> GetGamesAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<GameEntity> GetGameAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<int> AddGameAsync(GameEntity entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateGameAsync(GameEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
