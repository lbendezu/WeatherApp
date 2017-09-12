using Models;
using Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Mappers;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
  public class ForecastController : Controller
  {
    private IWeatherUndergroundProvider weatherUndergroundProvider;
    private IDarkSkyProvider darkSkyProvider;
    private IWeatherDashboardModelMapper mapper;   

    public ForecastController(IWeatherUndergroundProvider weatherUndergroundProvider, IDarkSkyProvider darkSkyProvider, IWeatherDashboardModelMapper mapper) {
      this.weatherUndergroundProvider = weatherUndergroundProvider;
      this.darkSkyProvider = darkSkyProvider;
      this.mapper = mapper;
    }

    // GET: Forecast
    [HttpGet]
    public JsonResult Get(string provider, decimal latitude, decimal longitude)
    {
      var weatherDashboardModel = new WeatherDashboardModel();

      if (provider == "DarkSky")
      {
        weatherDashboardModel = darkSkyProvider.GetForecast(latitude, longitude);
      }
      else if (provider == "WeatherUnderground")
      {
        weatherDashboardModel = weatherUndergroundProvider.GetForecast(latitude, longitude);
      }

      var model = mapper.Map(weatherDashboardModel);

      return Json(model, JsonRequestBehavior.AllowGet);
    }
    
  }
}