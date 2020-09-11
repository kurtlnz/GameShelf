using System;

namespace GameShelf.Domain.Dtos
{
    public class UpdateGame
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}