using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameShelf.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        [JsonIgnore]
        public ICollection<UserGame> UserGames { get; set; }
    }
}