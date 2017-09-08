using Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.App_Start;
using LightInject;

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
  }
}