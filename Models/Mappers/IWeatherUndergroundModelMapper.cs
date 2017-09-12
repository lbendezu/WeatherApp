using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mappers
{
  public interface IWeatherUndergroundModelMapper
  {
    WeatherDashboardModel Map(WeatherUndergroundModel model);
  }
}
