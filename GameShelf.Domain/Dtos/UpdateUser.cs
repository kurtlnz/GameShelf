using System;
using System.ComponentModel.DataAnnotations;

namespace GameShelf.Domain.Dtos
{
    public class UpdateUser
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}