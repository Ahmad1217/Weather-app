using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.open-meteo.com")
            };
        }

        public async Task<WeatherResponse> GetWeatherDataAsync(double latitude, double longitude)
        {
            try
            {
                string url = $"/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true&daily=temperature_2m_min,temperature_2m_max,precipitation_sum&current_humidity=true";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<WeatherResponse>(jsonResponse);
                return result ?? throw new Exception("Failed to parse weather data.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                throw;
            }
        }
    }
}
