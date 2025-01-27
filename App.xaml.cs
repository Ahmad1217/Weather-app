using LifeManagementApp.Services;

namespace LifeManagementApp
{
    public partial class App : Application
    {
        public App(WeatherService weatherService)
        {
            InitializeComponent();

            // Передаем WeatherService в MainPage
            MainPage = new MainPage(weatherService);
        }
    }
}

