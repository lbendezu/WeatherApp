using Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mappers
{
  public class WeatherUndergroundModelMapper : IWeatherUndergroundModelMapper
  {
    ISettingsManager settingsManager;

    public WeatherUndergroundModelMapper(ISettingsManager settingsManager)
    {
      this.settingsManager = settingsManager;
    }

    public WeatherDashboardModel Map(WeatherUndergroundModel model)
    {
      var dashboardModel = new WeatherDashboardModel();      

      dashboardModel.CurrentCelsius = model.Current_Observation.Temp_C;
      dashboardModel.CurrentFahrenheit = model.Current_Observation.Temp_F;
      dashboardModel.CurrentSummary = model.Current_Observation.Weather;
      dashboardModel.Icon = model.Current_Observation.Icon;
      dashboardModel.IconUrl = model.Current_Observation.Icon_Url;
      dashboardModel.Forecast = new List<DayDashboard>();
      foreach (var day in model.Forecast.SimpleForecast.ForecastDay.Take(int.Parse(settingsManager.Get(Constants.FORECAST_DEFAULT_SIZE))))
      {
        var dayDashboard = new DayDashboard();
        dayDashboard.Summary = day.Conditions;
        dayDashboard.LowCelsius = day.Low.Celsius;
        dayDashboard.LowFahrenheit = day.Low.Fahrenheit;
        dayDashboard.HighCelsius = day.High.Celsius;
        dayDashboard.HighFahrenheit = day.High.Fahrenheit;
        dayDashboard.Icon = day.Icon;
        dayDashboard.IconUrl = day.Icon_Url;
        dayDashboard.Date = new DateTime(1970, 1, 1).AddSeconds(day.Date.Epoch);
        dashboardModel.Forecast.Add(dayDashboard);
      }

      return dashboardModel;
    }
  }
}
