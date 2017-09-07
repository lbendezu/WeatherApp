using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class DarkSkyModel
  {
    public Currently Currently { get; set; }
    public Daily Daily { get; set; }
  }

  #region Currently
  public class Currently
  {
    public int Time { get; set; }
    public decimal Temperature { get; set; } //Celsius
    public string Summary { get; set; }
    public string Icon { get; set; }
  }
  #endregion

  #region Daily
  public class Daily
  {
    public List<DarkSkyDay> data { get; set; }
  }

  public class DarkSkyDay
  {
    public int Time { get; set; }
    public decimal TemperatureLow { get; set; } //Celsius
    public decimal TemperatureHigh { get; set; } //Celsius
    public string Summary { get; set; }
    public string Icon { get; set; }
  }
  #endregion



}
