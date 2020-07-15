using System;

namespace GameShelf.Domain.Services.User.DTO
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}