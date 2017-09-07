using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  interface IWeatherProvider
  {
    string GetForecast(long latitude, long longitude);
  }
}
