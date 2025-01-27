using System.Text.Json.Serialization;

namespace LifeManagementApp.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("current_weather")]
        public CurrentWeather? CurrentWeather { get; set; }

        [JsonPropertyName("daily")]
        public Daily? Daily { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        [JsonPropertyName("windspeed")]
        public double? WindSpeed { get; set; }

        [JsonPropertyName("humidity")]
        public double? Humidity { get; set; }
    }

    public class Daily
    {
        [JsonPropertyName("time")]
        public List<string>? Time { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double>? Temperature_2m_Min { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double>? Temperature_2m_Max { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public List<double>? Precipitation_Sum { get; set; }
    }
}
