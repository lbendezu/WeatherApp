using System;
using NUnit.Framework;
using Moq;
using Models;
using Providers;
using System.Collections.Generic;

namespace WeatherApp.Tests.Providers
{
  [TestFixture]
  public class WUndergroundProviderTest
  {
    private Mock<IRequestHandler> requestHandler;
    private WUndergroundModel wUndergroundModel;

    private WUndergroundModel GetWUndergroundModel()
    {
      var model = new WUndergroundModel();
      model.CurrentObservation = new CurrentObservation();
      model.CurrentObservation.Icon = "Numb";
      model.CurrentObservation.IconUrl = "Numb";
      model.CurrentObservation.ObservationEpoch = 1111111;
      model.CurrentObservation.TempC = 17;
      model.CurrentObservation.TempF = 63;
      model.CurrentObservation.Weather = "Sunny";
      model.Forecast = new Forecast();
      model.Forecast.SimpleForecast = new SimpleForecast();
      model.Forecast.SimpleForecast.ForecastDay = new List<WUndergroundDay>();
      var wUndergroundDay = new WUndergroundDay();
      wUndergroundDay.Conditions = "Sunny";
      wUndergroundDay.Date = new WUndergroundDate();
      wUndergroundDay.Date.Epoch = 1111111;
      wUndergroundDay.High = new High();
      wUndergroundDay.High.Celsius = 21;
      wUndergroundDay.High.Fahrenheit = 74;
      wUndergroundDay.Low = new Low();
      wUndergroundDay.Low.Celsius = 14;
      wUndergroundDay.Low.Fahrenheit = 43;
      wUndergroundDay.Icon = "Numb";
      wUndergroundDay.IconUrl = "Numb";
      model.Forecast.SimpleForecast.ForecastDay.Add(wUndergroundDay);
      return model;
    }

    [SetUp]
    public void Initialize()
    {
      requestHandler = new Mock<IRequestHandler>();
      wUndergroundModel = GetWUndergroundModel();
    }

    [TestCase]
    public void WUndergroundProvider_Should_Return_Data()
    {
      requestHandler.Setup(x => x.GetDeserializedObjectFromRequest<WUndergroundModel>(It.IsAny<string>())).Returns(wUndergroundModel);

      var provider = new WUndergroundProvider(requestHandler.Object);

      var model = provider.GetForecast(1, 2);

      Assert.AreEqual("Sunny", model.CurrentSummary);
    }
  }
}
