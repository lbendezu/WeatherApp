using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mappers
{
  public class DarkSkyModelMapper : IDarkSkyModelMapper
  {
    public WeatherDashboardModel Map(DarkSkyModel model)
    {
      var dashboardModel = new WeatherDashboardModel();

      dashboardModel.CurrentCelsius = model.Currently.Temperature;
      dashboardModel.CurrentFahrenheit = model.Currently.Temperature * (decimal)1.8 + 32; //using conversion formula
      dashboardModel.CurrentSummary = model.Currently.Summary;
      dashboardModel.Icon = model.Currently.Icon;
      dashboardModel.IconUrl = null;
      dashboardModel.Forecast = new List<DayDashboard>();
      foreach (var day in model.Daily.Data)
      {
        var dayDashboard = new DayDashboard();
        dayDashboard.Summary = day.Summary;
        dayDashboard.LowCelsius = day.TemperatureLow;
        dayDashboard.LowFahrenheit = day.TemperatureLow * (decimal)1.8 + 32;
        dayDashboard.HighCelsius = day.TemperatureHigh;
        dayDashboard.HighFahrenheit = day.TemperatureHigh * (decimal)1.8 + 32;
        dayDashboard.Icon = day.Icon;
        dayDashboard.IconUrl = null;
        dayDashboard.Date = new DateTime(1970, 1, 1).AddSeconds(day.Time);
        dashboardModel.Forecast.Add(dayDashboard);
      }

      return dashboardModel;
    }
  }
}
