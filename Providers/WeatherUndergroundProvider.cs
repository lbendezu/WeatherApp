using Models;
using Models.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  public class WeatherUndergroundProvider : IWeatherUndergroundProvider
  {
    IRequestHandler requestHandler;
    IWeatherUndergroundModelMapper mapper;

    public WeatherUndergroundProvider(IRequestHandler requestHandler, IWeatherUndergroundModelMapper mapper)
    {
      this.requestHandler = requestHandler ?? throw new ArgumentNullException("RequestHandler is null");
      this.mapper = mapper ?? throw new ArgumentNullException("WeatherUndergroundModelMapper is null");
    }

    public WeatherDashboardModel GetForecast(decimal latitude, decimal longitude)
    {
      string weatherUndergroundApiUrl = ConfigurationManager.AppSettings[Constants.WEATHER_UNDERGROUND_API_URL];
      string weatherUndergroundApiKey = ConfigurationManager.AppSettings[Constants.WEATHER_UNDERGROUND_API_KEY];

      var url = string.Format(weatherUndergroundApiUrl, weatherUndergroundApiKey, latitude, longitude);

      var response = requestHandler.GetDeserializedObjectFromRequest<WeatherUndergroundModel>(url);

      return mapper.Map(response); ;
    }
  }
}
