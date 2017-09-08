using LightInject;
using Models;
using Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.App_Start
{
  public class DependencyConfig
  {
    public static ServiceContainer Container { get; set; }

    public static void Configure()
    {
      Container = new ServiceContainer();
      Container.Register<IWeatherProvider, DarkSkyProvider>("DarkSky");
      Container.Register<IWeatherProvider, WUndergroundProvider>("WUnderground");
      Container.Register<IRequestHandler, RequestHandler>();
      Container.RegisterControllers();
    }
  }
}