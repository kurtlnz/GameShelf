using System;

namespace GameShelf.Domain.Services.User.DTO
{
    public class UpdateUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}