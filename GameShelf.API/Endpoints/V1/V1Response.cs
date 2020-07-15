namespace GameShelf.API.Endpoints.V1
{
    public class V1Response
    {
        public V1Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        private bool Success { get; set; }
        private string Message { get; set; }
    }
}