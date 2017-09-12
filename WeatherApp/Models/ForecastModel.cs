using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
  public class ForecastModel
  {
    public decimal CurrentCelsius { get; set; }
    public decimal CurrentFahrenheit { get; set; }
    public string CurrentSummary { get; set; }
    public string Icon { get; set; }
    public string IconUrl { get; set; }
    public List<ForecastDayDashboard> Forecast { get; set; }
  }

  public class ForecastDayDashboard
  {
    public string Summary { get; set; }
    public decimal LowCelsius { get; set; }
    public decimal LowFahrenheit { get; set; }
    public decimal HighCelsius { get; set; }
    public decimal HighFahrenheit { get; set; }
    public string Icon { get; set; }
    public string IconUrl { get; set; }
    public DateTime Date { get; set; }
  }

  //public class ForecastModel
  //{
  //  public ForecastModel() {
  //    Cities = new List<City>();
  //    Providers = new List<ForecastProvider>();
  //  }

  //  public List<City> Cities { get; set; }
  //  public List<ForecastProvider> Providers { get; set; }
  //}

  //public class City {
  //  public string Name { get; set; }  
  //  public GeoData LocationInfo { get; set; }
  //}

  //public class GeoData {
  //  public decimal Latitude { get; set; }
  //  public decimal Longtude { get; set; }
  //}

  //public class ForecastProvider {
  //  public string Name { get; set; }
  //  public string Alias { get; set; }
  //}
}