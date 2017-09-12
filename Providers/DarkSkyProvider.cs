using Models;
using Models.Mappers;
using Models.Util;
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
    ISettingsManager settingsManager;

    public DarkSkyProvider(IRequestHandler requestHandler, IDarkSkyModelMapper mapper, ISettingsManager settingsManager)
    {
      this.requestHandler = requestHandler ?? throw new ArgumentNullException("RequestHandler is null");
      this.mapper = mapper ?? throw new ArgumentNullException("DarkSkyModelMapper is null");
      this.settingsManager = settingsManager ?? throw new ArgumentNullException("SettingsManager is null"); 
    }

    public WeatherDashboardModel GetForecast(decimal latitude, decimal longitude)
    {
      string darkSkyApiUrl = settingsManager.Get(Constants.DARK_SKY_API_URL);
      string darkSkyApiKey = settingsManager.Get(Constants.DARK_SKY_API_KEY);

      var url = string.Format(darkSkyApiUrl, darkSkyApiKey, latitude, longitude);

      var response = requestHandler.GetDeserializedObjectFromRequest<DarkSkyModel>(url);

      return mapper.Map(response);
    }
  }
}
