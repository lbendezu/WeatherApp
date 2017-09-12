using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models;

namespace WeatherApp.Mappers
{
  public interface IWeatherDashboardModelMapper
  {
    ForecastModel Map(WeatherDashboardModel model);
  }
}