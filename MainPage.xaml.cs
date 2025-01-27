using System;
using LifeManagementApp.Services;
using Microsoft.Maui.Controls;

namespace LifeManagementApp
{
    public partial class MainPage : ContentPage
    {
        private readonly WeatherService _weatherService;

        public MainPage(WeatherService weatherService)
        {
            InitializeComponent();
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService), "Weather Service is required");
        }

       private async void OnWeatherUpdateClicked(object sender, EventArgs e)
{
    double latitude = 63.096;
    double longitude = 21.6158;

    if (_weatherService != null)
    {
        try
        {
            var weatherData = await _weatherService.GetWeatherDataAsync(latitude, longitude);

            if (weatherData != null && weatherData.CurrentWeather != null && weatherData.Daily != null)
            {
                // Обновление UI с полученными данными
                TemperatureLabel.Text = $"{weatherData.CurrentWeather.Temperature}°C";
                WindspeedLabel.Text = $"{weatherData.CurrentWeather.WindSpeed} m/s";
                MinTemperatureLabel.Text = $"{weatherData.Daily.Temperature_2m_Min[0]}°C";
                MaxTemperatureLabel.Text = $"{weatherData.Daily.Temperature_2m_Max[0]}°C";
                PrecipitationLabel.Text = $"{weatherData.Daily.Precipitation_Sum[0]} mm";

                // Проверка на скорость ветра более 4 м/с
                if (weatherData.CurrentWeather.WindSpeed.HasValue && weatherData.CurrentWeather.WindSpeed.Value > 4)
                {
                    await DisplayAlert("Warning", "Wind speed is expected to reach more than 4 m/s today.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Unable to retrieve weather data. Please check your internet connection or API settings.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to retrieve weather data: {ex.Message}", "OK");
        }
    }
    else
    {
        await DisplayAlert("Error", "Weather service is not initialized.", "OK");
    }
}


    }
}







