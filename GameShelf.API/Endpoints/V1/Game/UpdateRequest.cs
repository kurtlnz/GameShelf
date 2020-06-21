namespace GameShelf.API.Endpoints.V1.Game
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}