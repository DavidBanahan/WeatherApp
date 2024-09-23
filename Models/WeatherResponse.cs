namespace WeatherData.Models
{
    public class WeatherResponse
    {
        public Main? Main { get; set; }
        public Weather[]? Weather { get; set; }
        public Wind? Wind { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
    }

    public class Weather
    {
        public string? Description { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
    }
}
