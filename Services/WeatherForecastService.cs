using System.Collections.Concurrent;

namespace memoryleak.Services
{
    public class WeatherForecastService
    {
        public ConcurrentBag<WeatherForecast> results = new ConcurrentBag<WeatherForecast>();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            var randomEnumerable = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();

            randomEnumerable.ForEach((x) =>
            {
                results.Add(x);
            });


            return randomEnumerable;
        }


    }
}