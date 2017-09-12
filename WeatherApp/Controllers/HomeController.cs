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
    public ActionResult Index()
    {
      return RedirectToAction("Index", "Aurelia");
    }
  }
}