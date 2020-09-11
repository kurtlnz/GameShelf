using System;
using System.Collections.Generic;

namespace GameShelf.Domain.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public ICollection<UserGame> UserGames { get; set; }
    }
}