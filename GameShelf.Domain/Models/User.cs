using System;
using System.Collections.Generic;

namespace GameShelf.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<UserGame> UserGames { get; set; }
    }
}