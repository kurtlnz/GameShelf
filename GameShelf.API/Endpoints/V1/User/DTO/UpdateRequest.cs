using System;

namespace GameShelf.API.Endpoints.V1.User
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}