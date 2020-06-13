using System;
using System.Collections.Generic;

namespace GameShelf.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Game> Games { get; set; }
    }
}