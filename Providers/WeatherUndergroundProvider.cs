using Models;
using Models.Mappers;
using Models.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  public class WeatherUndergroundProvider : IWeatherProvider
  {
    IRequestHandler requestHandler;
    IWeatherUndergroundModelMapper mapper;
    ISettingsManager settingsManager;

    public WeatherUndergroundProvider(IRequestHandler requestHandler, IWeatherUndergroundModelMapper mapper, ISettingsManager settingsManager)
    {
      this.requestHandler = requestHandler ?? throw new ArgumentNullException("RequestHandler is null");
      this.mapper = mapper ?? throw new ArgumentNullException("WeatherUndergroundModelMapper is null");
      this.settingsManager = settingsManager ?? throw new ArgumentNullException("SettingsManager is null");
    }

    public WeatherDashboardModel GetForecast(decimal latitude, decimal longitude)
    {
      string weatherUndergroundApiUrl = settingsManager.Get(Constants.WEATHER_UNDERGROUND_API_URL);
      string weatherUndergroundApiKey = settingsManager.Get(Constants.WEATHER_UNDERGROUND_API_KEY);

      var url = string.Format(weatherUndergroundApiUrl, weatherUndergroundApiKey, latitude, longitude);

      var response = requestHandler.GetDeserializedObjectFromRequest<WeatherUndergroundModel>(url);

      return mapper.Map(response);
    }
  }
}
