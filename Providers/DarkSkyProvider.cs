using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  public class DarkSkyProvider : IWeatherProvider
  {
    public WeatherDashboardModel GetForecast(long latitude, long longitude)
    {
      string darkSkyApiUrl = ConfigurationManager.AppSettings[Constants.DARK_SKY_API_URL];
      string darkSkyApiKey = ConfigurationManager.AppSettings[Constants.DARK_SKY_API_KEY];

      var url = string.Format(darkSkyApiUrl, darkSkyApiKey, latitude, longitude);

      var response = RequestHandler.GetDeserializedObjectFromRequest<DarkSkyModel>(url);

      var model = new WeatherDashboardModel(response);

      return model;
    }
  }
}
