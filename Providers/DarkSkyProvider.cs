using Models;
using Models.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  public class DarkSkyProvider : IDarkSkyProvider
  {
    IRequestHandler requestHandler;
    IDarkSkyModelMapper mapper;

    public DarkSkyProvider(IRequestHandler requestHandler, IDarkSkyModelMapper mapper)
    {
      this.requestHandler = requestHandler ?? throw new ArgumentNullException("RequestHandler is null");
      this.mapper = mapper ?? throw new ArgumentNullException("DarkSkyModelMapper is null");
    }

    public WeatherDashboardModel GetForecast(decimal latitude, decimal longitude)
    {
      string darkSkyApiUrl = ConfigurationManager.AppSettings[Constants.DARK_SKY_API_URL];
      string darkSkyApiKey = ConfigurationManager.AppSettings[Constants.DARK_SKY_API_KEY];

      var url = string.Format(darkSkyApiUrl, darkSkyApiKey, latitude, longitude);

      var response = requestHandler.GetDeserializedObjectFromRequest<DarkSkyModel>(url);

      return mapper.Map(response);
    }
  }
}
