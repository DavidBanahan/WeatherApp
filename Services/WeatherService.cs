using System.Net.Http.Json;
using WeatherData.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient; // HttpClient for making API requests
        private const string API_KEY = "c01a14a0abebffac418113ef879a33bf";

        // Constructor that initialises the HttpClient
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse?> GetWeather(double lat, double lon)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API_KEY}&units=metric";

            try
            {
                // Make the HTTP GET request and deserialize the JSON response into WeatherResponse object
                var response = await _httpClient.GetFromJsonAsync<WeatherResponse>(url);
                return response;  // Return the response, may be null if API fails
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return null;  // Return null if the request fails
            }
            catch (Exception ex) // General exception handling for unforeseen errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;  // Return null for any other exceptions
            }
        }
    }
}
