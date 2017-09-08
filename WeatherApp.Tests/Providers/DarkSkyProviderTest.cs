using System;
using Moq;
using NUnit.Framework;
using Providers;
using Models;
using System.Collections.Generic;

namespace WeatherApp.Tests.Providers
{
  [TestFixture]
  public class DarkSkyProviderTest
  {
    private Mock<IRequestHandler> requestHandler;
    private DarkSkyModel darkSkyModel;

    private DarkSkyModel GetDarkSkyModel() {
      var model = new DarkSkyModel();
      model.Currently = new Currently();
      model.Currently.Icon = "Numb";
      model.Currently.Summary = "Cloudy";
      model.Currently.Temperature = 30;
      model.Currently.Time = 1111111;
      model.Daily = new Daily();
      model.Daily.data = new List<DarkSkyDay>();
      model.Daily.data.Add(new DarkSkyDay() { Icon = "Numb", Summary = "Cloudy", TemperatureLow = 20, TemperatureHigh = 50, Time = 1122323 });
      return model;
    }

    [SetUp]
    public void Initialize() {
      requestHandler = new Mock<IRequestHandler>();
      darkSkyModel = GetDarkSkyModel();
    }

    [TestCase]
    public void DarkSkyProvider_Should_Return_Data()
    {      
      requestHandler.Setup(x => x.GetDeserializedObjectFromRequest<DarkSkyModel>(It.IsAny<string>())).Returns(darkSkyModel);      

      var provider = new DarkSkyProvider(requestHandler.Object);

      var model = provider.GetForecast(1, 2);

      Assert.AreEqual("Cloudy", model.CurrentSummary);
    }
  }
}
