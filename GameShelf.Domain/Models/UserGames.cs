namespace GameShelf.Domain.Models
{
    public class UserGame
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}