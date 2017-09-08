using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
  public class WeatherService : IWeatherService
  {
    private IWeatherService weatherService;

    public WeatherService(IWeatherService weatherService)
    {
      this.weatherService = weatherService;
    }

    public WeatherDashboardModel GetForecast(long latitude, long longitude)
    {
      throw new NotImplementedException();
    }
  }
}
