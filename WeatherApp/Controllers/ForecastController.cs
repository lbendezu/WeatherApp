using Models;
using Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.App_Start;
using WeatherApp.Mappers;
using WeatherApp.Models;
using LightInject;

namespace WeatherApp.Controllers
{
  public class ForecastController : Controller
  {
    private IWeatherProvider weatherProvider;
    private IWeatherDashboardModelMapper mapper;   

    public ForecastController(IWeatherDashboardModelMapper mapper) {      
      this.mapper = mapper;
    }

    // GET: Forecast
    [HttpGet]
    public JsonResult Get(string provider, decimal latitude, decimal longitude)
    {
      var weatherDashboardModel = new WeatherDashboardModel();

      weatherProvider = DependencyConfig.Container.GetInstance<IWeatherProvider>(provider);
      weatherDashboardModel = weatherProvider.GetForecast(latitude, longitude);
      
      var model = mapper.Map(weatherDashboardModel);

      return Json(model, JsonRequestBehavior.AllowGet);
    }
    
  }
}