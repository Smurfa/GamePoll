using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamePoll.Core.Models;
using GamePoll.Core.Repositories;
using GamePoll.Core.Repositories.Entities;

namespace GamePoll.Core.Services.GameData
{
    public class GameService : IGameService
    {
        private readonly IRepository<GameEntity> _repository;
        private readonly IMapper _mapper;

        public GameService(IRepository<GameEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameModel>> GetGamesAsync()
        {
            var entities = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<GameModel>>(entities);
        }

        public async Task<GameModel> GetGameAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            return _mapper.Map<GameModel>(entity);
        }

        public async Task<int> AddGameAsync(GameModel model)
        {
            var entity = _mapper.Map<GameEntity>(model);
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateGameAsync(GameModel model)
        {
            var entity = _mapper.Map<GameEntity>(model);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
