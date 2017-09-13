using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class WeatherUndergroundModel
  {
    public CurrentObservation Current_Observation { get; set; }
    public Forecast Forecast { get; set; }
  }

  public class CurrentObservation {
    public int Observation_Epoch { get; set; }
    public decimal Temp_F { get; set; } //Fahrenheit
    public decimal Temp_C { get; set; } //Celsius
    public string Weather { get; set; }
    public string Icon { get; set; }
    public string Icon_Url { get; set; }
  }

  public class Forecast {
    public SimpleForecast SimpleForecast { get; set; }
  }

  public class SimpleForecast {
    public List<WeatherUndergroundDay> ForecastDay { get; set; }
  }

  public class WeatherUndergroundDay {
    public string Conditions { get; set; }
    public string Icon { get; set; }
    public string Icon_Url { get; set; }
    public Low Low { get; set; }
    public High High { get; set; }
    public WeatherUndergroundDate Date { get; set; }
  }

  public class WeatherUndergroundDate {
    public int Epoch { get; set; } //Epoch time
  }

  public class Low {
    public decimal Fahrenheit { get; set; }
    public decimal Celsius { get; set; }
  }

  public class High
  {
    public decimal Fahrenheit { get; set; }
    public decimal Celsius { get; set; }
  }

}
