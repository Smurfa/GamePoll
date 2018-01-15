using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GamePoll.Core.Repositories.Entities;

namespace GamePoll.Core.Services.GameData
{
    public interface IGameService
    {
        Task<IEnumerable<GameEntity>> GetGamesAsync();
        Task<GameEntity> GetGameAsync(int id);
        Task<int> AddGameAsync(GameEntity entity);
        Task<bool> UpdateGameAsync(GameEntity entity);
        Task<bool> DeleteGameAsync(int id);
    }
}
