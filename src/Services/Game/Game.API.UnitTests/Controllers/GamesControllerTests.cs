using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Game.API.Controllers;
using Game.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Game.API.UnitTests.Controllers
{
    public class GamesControllerTests
    {
        private readonly GamesController _controller;
        private readonly Mock<IGameService> _mockGameService;
        
        public GamesControllerTests()
        {
            _mockGameService = new Mock<IGameService>();
            _controller = new GamesController(_mockGameService.Object);
        }
        
        [Fact]
        public void Should_ReturnOk_When_GetAll()
        {
            // Arrange
            var gamesList = new List<string>()
            {
                "Terra Mystica",
                "Barrage",
                "Caylus 1303",
            };
            
            _mockGameService
                .Setup(g => g.GetAllGamesAsync())
                .ReturnsAsync(gamesList);
            
            // Act
            var actionResult = _controller.GetAll();

            // Assert
            actionResult.Should().NotBeNull();
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().BeEquivalentTo(gamesList);
        }
    }
}