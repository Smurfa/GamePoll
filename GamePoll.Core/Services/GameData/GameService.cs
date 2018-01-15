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
            return await _repository.Get();
        }
    }
}
