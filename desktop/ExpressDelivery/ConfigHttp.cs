using System.Net.Http;
using System.Net.Http.Headers;

namespace ExpressDelivery
{
    internal class ConfigHttp
    {
        public const string BaseUrl = "http://ec2-18-222-179-122.us-east-2.compute.amazonaws.com:8080";
        // public const string BaseUrl = "http://localhost:8080";
        
        public static string Token { get; set; }
        
        public static HttpClient client = new HttpClient();

        public static void setHeader(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Token = token;
        }
    }
}