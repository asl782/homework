using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NasaAPI
{
     //Napisz program, który pobierze z NASA dane na temat położenia satelity ISS
     //API: https://api.nasa.gov/; korzystamy z TLE API

    class Program
    {
        const string issUrl = @"https://tle.ivanstanojevic.me/api/tle/25544";
        static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            string result = await GetData(issUrl);
            if (result != String.Empty)
            {
                var iss = JsonConvert.DeserializeObject<ISS>(result);

                var line1 = iss.Line1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var line2 = iss.Line2.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine($"First time derivative of mean motion = {line1[4]}");
                Console.WriteLine($"Inclination = {line2[2]}");
            }
            else 
            {
                Console.WriteLine("Failed retrieving ISS info");
            }
        }

        static async Task<string> GetData(string url)   
        {
            string response;

            using (httpClient)
            {
                try
                {
                    response = await httpClient.GetStringAsync(url);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    response = String.Empty;
                }
            }

            return response;
        }
    }
}
