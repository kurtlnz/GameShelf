using System;

namespace GameShelf.Domain.Dtos
{
    public class UpdateUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}