using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.API.Services
{
    public interface IGameService
    {
        Task<IList<string>> GetAllGames();
    }
}