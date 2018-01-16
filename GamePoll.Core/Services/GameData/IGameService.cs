using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GamePoll.Core.Models;
using GamePoll.Core.Repositories.Entities;

namespace GamePoll.Core.Services.GameData
{
    public interface IGameService
    {
        Task<IEnumerable<GameModel>> GetGamesAsync();
        Task<GameModel> GetGameAsync(int id);
        Task<int> AddGameAsync(GameModel model);
        Task<bool> UpdateGameAsync(GameModel model);
        Task<bool> DeleteGameAsync(int id);
    }
}
