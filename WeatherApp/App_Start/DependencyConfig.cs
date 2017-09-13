using LightInject;
using Models;
using Models.Mappers;
using Models.Util;
using Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Mappers;

namespace WeatherApp.App_Start
{
  public class DependencyConfig
  {
    public static ServiceContainer Container { get; set; }

    public static void Configure()
    {
      Container = new ServiceContainer();
      Container.Register<IDarkSkyModelMapper, DarkSkyModelMapper>();
      Container.Register<IWeatherUndergroundModelMapper, WeatherUndergroundModelMapper>();      
      Container.Register<IWeatherProvider, DarkSkyProvider>("DarkSky");
      Container.Register<IWeatherProvider, WeatherUndergroundProvider>("WeatherUnderground");
      Container.Register<IRequestHandler, RequestHandler>();
      Container.Register<IWeatherDashboardModelMapper, WeatherDashboardModelMapper>();
      Container.Register<ISettingsManager, SettingsManager>(); 
      Container.RegisterControllers();
      Container.EnableMvc();
    }
  }
}