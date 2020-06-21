namespace GameShelf.API.Endpoints.V1
{
    public class V1Response
    {
        public V1Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}