using System;

namespace GameShelf.Domain.Exceptions
{
    public class GameNotFoundException: Exception
    {
        public GameNotFoundException()
        {
        }

        public GameNotFoundException(Guid id)
            : base($"Could not find game with id '{id}'")
        {
        }

        public GameNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
        
    }
}