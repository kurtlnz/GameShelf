using System;
using System.Threading.Tasks;
using Castle.Core.Logging;
using GameShelf.Domain;
using GameShelf.Domain.Services.Game;
using Moq;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using Xunit;

namespace GameShelf.Tests.Services
{
    public class GameServiceTests
    {
        private readonly GameService _serviceUnderTest;
        private readonly Mock<DataContext> _dataContextMock;
        
        public GameServiceTests()
        {
            _dataContextMock = new Mock<DataContext>();
            _serviceUnderTest = new GameService(_dataContextMock.Object);
        }
        
        [Fact]
        public async Task GetGameAsync_ShouldReturnGame_WhereGameExists()
        {
            // Arrange
            var gameId = Guid.NewGuid();
            
            // Act
            var game = await _serviceUnderTest.GetGameAsync(gameId);

            // Assert
            Assert.Equal(gameId, game.Id);
        }
    }
}