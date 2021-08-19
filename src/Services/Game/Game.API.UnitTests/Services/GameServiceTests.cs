using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Game.API.Services;
using Xunit;

namespace Game.API.UnitTests.Services
{
    public class GameServiceTests
    {
        private readonly GameService _service;
        
        public GameServiceTests()
        {
            _service = new GameService();
        }

        [Fact]
        public async Task Should_ReturnAllGames_WhenSuccess()
        {
            // Arrange
            var games = new List<string>()
            {
                "Terra Mystica",
                "Barrage",
                "Caylus 1303",
            };
            
            // Act
            var result = await _service.GetAllGamesAsync();

            // Assert
            result.Should().BeEquivalentTo(games);
        }
    }
}