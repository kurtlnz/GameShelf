using System;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace GameShelf.Tests.Infrastructure
{
    public class GameShelfInitializer
    {
        public static void Initialize(GameShelfContext context)
        {
            if (context.Games.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(GameShelfContext context)
        {
            var games = new[]
            {
                new Game { Id = Guid.Parse("9601c5a5-27df-47fe-bd64-984dbebfe69a"), Title = "Carcassonne" },
                new Game { Id = Guid.Parse("b10021ba-749d-44d0-96b6-1a04c4f6b042"), Title = "Splendor" },
                new Game { Id = Guid.Parse("09a13a9b-42a0-4b4c-a8c1-0327a8475a40"), Title = "Settlers of Catan" },
            };

            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }
}