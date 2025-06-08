namespace LocalMindApi.Models.LocalAIs
{
    public class LocalAIRequest
    {
        public string Model { get; set; }
        public string Prompt { get; set; }
        public bool Stream { get; set; }
    }
}
