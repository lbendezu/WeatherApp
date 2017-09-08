using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  public class WUndergroundProvider : IWeatherProvider
  {
    public WeatherDashboardModel GetForecast(long latitude, long longitude)
    {
      string wUndergroundApiUrl = ConfigurationManager.AppSettings[Constants.WUNDERGROUND_API_URL];
      string wUndergroundApiKey = ConfigurationManager.AppSettings[Constants.WUNDERGROUND_API_KEY];

      var url = string.Format(wUndergroundApiUrl, wUndergroundApiKey, latitude, longitude);

      var response = RequestHandler.GetDeserializedObjectFromRequest<WUndergroundModel>(url);

      var model = new WeatherDashboardModel(response);

      return model;
    }
  }
}
