using System;
using System.ComponentModel.DataAnnotations;

namespace GameShelf.Domain.Dtos
{
    public class UpdateGame
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}