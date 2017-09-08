using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class WeatherDashboardModel
  {
    public WeatherDashboardModel(DarkSkyModel model) {
      CurrentCelsius = model.Currently.Temperature;
      CurrentFahrenheit = model.Currently.Temperature * (decimal)1.8 + 32; //using conversion formula
      CurrentSummary = model.Currently.Summary;
      Icon = model.Currently.Icon;
      IconUrl = null;
      Forecast = new List<DayDashboard>();
      foreach (var day in model.Daily.data)
      {
        var dayDashboard = new DayDashboard();
        dayDashboard.Summary = day.Summary;
        dayDashboard.LowCelsius = day.TemperatureLow;
        dayDashboard.LowFahrenheit = day.TemperatureLow * (decimal)1.8 + 32;
        dayDashboard.HighCelsius = day.TemperatureHigh;
        dayDashboard.HighFahrenheit = day.TemperatureHigh * (decimal)1.8 + 32;
        dayDashboard.Icon = day.Icon;
        dayDashboard.IconUrl = null;
        Forecast.Add(dayDashboard);
      }
    }

    public WeatherDashboardModel(WUndergroundModel model)
    {
      CurrentCelsius = model.CurrentObservation.TempC;
      CurrentFahrenheit = model.CurrentObservation.TempF;
      CurrentSummary = model.CurrentObservation.Weather;
      Icon = model.CurrentObservation.Icon;
      IconUrl = model.CurrentObservation.IconUrl;
      Forecast = new List<DayDashboard>();
      foreach (var day in model.Forecast.SimpleForecast.ForecastDay)
      {
        var dayDashboard = new DayDashboard();
        dayDashboard.Summary = day.Conditions;
        dayDashboard.LowCelsius = day.Low.Celsius;
        dayDashboard.LowFahrenheit = day.Low.Fahrenheit;
        dayDashboard.HighCelsius = day.High.Celsius;
        dayDashboard.HighFahrenheit = day.High.Fahrenheit;
        dayDashboard.Icon = day.Icon;
        dayDashboard.IconUrl = day.IconUrl;
        Forecast.Add(dayDashboard);
      }
    }

    public decimal CurrentCelsius { get; set; }
    public decimal CurrentFahrenheit { get; set; }
    public string CurrentSummary { get; set; }
    public string Icon { get; set; }
    public string IconUrl { get; set; }
    public List<DayDashboard> Forecast { get; set; }
  }

  public class DayDashboard {
    public string Summary { get; set; }
    public decimal LowCelsius { get; set; }
    public decimal LowFahrenheit { get; set; }
    public decimal HighCelsius { get; set; }
    public decimal HighFahrenheit { get; set; }
    public string Icon { get; set; }
    public string IconUrl { get; set; }
    public DateTime Date { get; set; }
  }
}
