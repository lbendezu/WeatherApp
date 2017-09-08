using Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.App_Start;
using LightInject;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
  public class HomeController : Controller
  {
    private IWeatherProvider weatherProvider;

    

    public ActionResult Index()
    {
      weatherProvider = DependencyConfig.Container.GetInstance<IWeatherProvider>("DarkSky");

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    private ForecastModel SeedData() {
      var model = new ForecastModel();      
      model.Countries.Add(new City() { Name = "Buenos Aires/Argentina", Latitude = (decimal)-34.603684, Longtude = (decimal)-58.381559 });
      model.Countries.Add(new City() { Name = "Lima/Peru", Latitude = (decimal)-12.046373, Longtude = (decimal)-77.042754 });
      model.Countries.Add(new City() { Name = "New York/United States Of America", Latitude = (decimal)40.712784, Longtude = (decimal)-74.005941 });
      model.Countries.Add(new City() { Name = "Paris/France", Latitude = (decimal)48.856614, Longtude = (decimal)2.352222 });
      model.Countries.Add(new City() { Name = "Toronto/Canada", Latitude = (decimal)43.653226, Longtude = (decimal)-79.383184 });

      model.Providers.Add(new ForecastProvider() { Name = "DarkSky.net", Alias = "DarkSky" });
      model.Providers.Add(new ForecastProvider() { Name = "WeatherUnderground.com", Alias = "WUnderground" });

      return model;
    }
  }
}