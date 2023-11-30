using System.Net.Http;
using System.Net.Http.Headers;

namespace ExpressDelivery
{
    internal class ConfigHttp
    {
        public const string BaseUrl = "http://localhost:8080";
        
        public static string Token { get; set; }
        
        public static HttpClient client = new HttpClient();

        public static void setHeader(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Token = token;
        }
    }
}