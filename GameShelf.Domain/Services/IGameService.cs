using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Models;

namespace GameShelf.Domain.Services
{
    public interface IGameService
    {
        Task<Game> AddGame(Game game);
        Task<List<Game>> GetGames();
    }
}