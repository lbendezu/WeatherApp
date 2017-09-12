using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using WeatherApp.Models;

namespace WeatherApp.Mappers
{
  public class WeatherDashboardModelMapper : IWeatherDashboardModelMapper
  {
    public ForecastModel Map(WeatherDashboardModel model)
    {
      var forecastModel = new ForecastModel();

      forecastModel.CurrentCelsius = model.CurrentCelsius;
      forecastModel.CurrentFahrenheit = model.CurrentFahrenheit;
      forecastModel.CurrentSummary = model.CurrentSummary;
      forecastModel.Icon = model.Icon;
      forecastModel.IconUrl = model.IconUrl;
      forecastModel.Forecast = new List<ForecastDayDashboard>();

      foreach (var modelDay in model.Forecast)
      {
        var forecastDay = new ForecastDayDashboard();
        forecastDay.Summary = modelDay.Summary;
        forecastDay.LowCelsius = modelDay.LowCelsius;
        forecastDay.LowFahrenheit = modelDay.LowFahrenheit;
        forecastDay.HighCelsius = modelDay.HighCelsius;
        forecastDay.HighFahrenheit = modelDay.HighFahrenheit;
        forecastDay.Icon = modelDay.Icon;
        forecastDay.IconUrl = modelDay.IconUrl;
        forecastDay.Date = modelDay.Date;
        forecastModel.Forecast.Add(forecastDay);
      }

      return forecastModel;
    }
  }
}