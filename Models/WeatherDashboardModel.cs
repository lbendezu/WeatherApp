using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class WeatherDashboardModel
  {
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
