using System;
using System.Threading.Tasks;
using Castle.Core.Logging;
using GameShelf.Domain;
using GameShelf.Domain.Exceptions;
using GameShelf.Domain.Services.Game;
using GameShelf.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using Xunit;

namespace GameShelf.Tests.Services
{
    public class GameServiceTests : GameShelfTestBase
    {
        [Fact]
        public async Task GetGamesAsync_ShouldReturnListOfGames_WhereGamesExist()
        {
            // Arrange
            var service = new GameService(_context);
            
            // Act
            var games = await service.GetGamesAsync();

            // Assert
            Assert.Equal(3 , games.Count);
        }
        
        [Fact]
        public async Task GetGameAsync_ShouldReturnGame_WhereGameExists()
        {
            // Arrange
            var service = new GameService(_context);
            var id = Guid.Parse("9601c5a5-27df-47fe-bd64-984dbebfe69a");
            
            // Act
            var game = await service.GetGameAsync(id);

            // Assert
            Assert.Equal(id, game.Id);
        }
        
        [Fact]
        public async Task GetGameAsync_ShouldThrowError_WhereGameDoesNotExist()
        {
            var service = new GameService(_context);
            
            Assert.ThrowsAsync<ObjectNotFoundException>(() => service.GetGameAsync(Guid.NewGuid()));
        }
    }
}