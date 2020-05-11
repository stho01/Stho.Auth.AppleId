namespace Stho.Auth.WebExample.Models
{
    public class AppleTokenViewModel
    {
        public string Token { get; set; }
        public string Header { get; set; }
        public string Payload { get; set; }
        public bool Valid { get; set; }
    }
}