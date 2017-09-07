using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class WUndergroundModel
  {
    public CurrentObservation CurrentObservation { get; set; }
    public Forecast Forecast { get; set; }
  }

  public class CurrentObservation {
    public int ObservationEpoch { get; set; }
    public decimal TempF { get; set; } //Fahrenheit
    public decimal TempC { get; set; } //Celsius
    public string Weather { get; set; }
    public string Icon { get; set; }
    public string IconUrl { get; set; }
  }

  public class Forecast {
    public SimpleForecast SimpleForecast { get; set; }
  }

  public class SimpleForecast {
    public List<WUndergroundDay> ForecastDay { get; set; }
  }

  public class WUndergroundDay {
    public string Conditions { get; set; }
    public string Icon { get; set; }
    public string IconUrl { get; set; }
    public Low Low { get; set; }
    public High High { get; set; }
    public WUndergroundDate Date { get; set; }
  }

  public class WUndergroundDate {
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
