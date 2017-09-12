using System;
using Moq;
using NUnit.Framework;
using Providers;
using Models;
using System.Collections.Generic;
using Models.Mappers;

namespace WeatherApp.Tests.Providers
{
  [TestFixture]
  public class DarkSkyProviderTest
  {
    private Mock<IRequestHandler> requestHandler;
    private Mock<IDarkSkyModelMapper> mapper;
    private DarkSkyModel darkSkyModel;

    private DarkSkyModel GetDarkSkyModel() {
      var model = new DarkSkyModel();
      model.Currently = new Currently();
      model.Currently.Icon = "Numb";
      model.Currently.Summary = "Cloudy";
      model.Currently.Temperature = 30;
      model.Currently.Time = 1111111;
      model.Daily = new Daily();
      model.Daily.Data = new List<DarkSkyDay>();
      model.Daily.Data.Add(new DarkSkyDay() { Icon = "Numb", Summary = "Cloudy", TemperatureLow = 20, TemperatureHigh = 50, Time = 1122323 });
      return model;
    }

    [SetUp]
    public void Initialize() {
      requestHandler = new Mock<IRequestHandler>();
      mapper = new Mock<IDarkSkyModelMapper>();
      darkSkyModel = GetDarkSkyModel();
    }

    [TestCase]
    public void GetForecast_ShouldCallRequiredMethods()
    {      
      //ARRANGE
      var provider = new DarkSkyProvider(requestHandler.Object, mapper.Object);

      //ACT
      var model = provider.GetForecast(1, 2);

      //ASSERT
      requestHandler.Verify(x => x.GetDeserializedObjectFromRequest<DarkSkyModel>(It.IsAny<string>()), Times.Once);
      mapper.Verify(x => x.Map(It.IsAny<DarkSkyModel>()), Times.Once);
    }
  }
}
