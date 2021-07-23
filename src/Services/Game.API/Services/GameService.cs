using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.API.Services
{
    public class GameService : IGameService
    {
        public async Task<IList<string>> GetAllGames()
        {
            await Task.CompletedTask;
            
            return new List<string>()
            {
                "Terra Mystica",
                "Barrage",
                "Caylus 1303",
            };
        }
    }
}