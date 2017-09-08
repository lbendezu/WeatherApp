using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
  public class ForecastModel
  {
    public ForecastModel() {
      Countries = new List<City>();
      Providers = new List<ForecastProvider>();
    }

    public List<City> Countries { get; set; }
    public List<ForecastProvider> Providers { get; set; }
  }

  public class City {
    public string Name { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longtude { get; set; }
  }

  public class ForecastProvider {
    public string Name { get; set; }
    public string Alias { get; set; }
  }
}