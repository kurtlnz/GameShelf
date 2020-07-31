using System;

namespace GameShelf.API.Endpoints.V1.User
{
    public class CreateRequest
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}