using System;

namespace GameShelf.Domain.Models
{
    public class UserGame
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}