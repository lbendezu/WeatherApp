using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  public interface IDarkSkyProvider
  {
    WeatherDashboardModel GetForecast(decimal latitude, decimal longitude);
  }
}
