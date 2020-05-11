namespace Stho.Auth.WebExample.Models
{
    public class AppleCallbackRequest
    {
        public string Code { get; set; }
        public string State { get; set; }
    }
}