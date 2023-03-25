namespace hackathon.Application
{
    public class ExApiTokenRequest
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string Checksum { get; set; }
    }
}