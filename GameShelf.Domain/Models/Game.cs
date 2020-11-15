using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameShelf.Domain.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        [JsonIgnore]
        public ICollection<UserGame> UserGames { get; set; }
    }
}