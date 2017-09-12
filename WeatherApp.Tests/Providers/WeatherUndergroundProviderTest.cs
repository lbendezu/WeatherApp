using System;
using NUnit.Framework;
using Moq;
using Models;
using Providers;
using System.Collections.Generic;
using Models.Mappers;

namespace WeatherApp.Tests.Providers
{
  [TestFixture]
  public class WeatherUndergroundProviderTest
  {
    private Mock<IRequestHandler> requestHandler;
    private Mock<IWeatherUndergroundModelMapper> mapper;
    private WeatherUndergroundModel weatherUndergroundModel;

    private WeatherUndergroundModel GetWeatherUndergroundModel()
    {
      var model = new WeatherUndergroundModel();
      model.Current_Observation = new CurrentObservation();
      model.Current_Observation.Icon = "Numb";
      model.Current_Observation.Icon_Url = "Numb";
      model.Current_Observation.Observation_Epoch = 1111111;
      model.Current_Observation.Temp_C = 17;
      model.Current_Observation.Temp_F = 63;
      model.Current_Observation.Weather = "Sunny";
      model.Forecast = new Forecast();
      model.Forecast.SimpleForecast = new SimpleForecast();
      model.Forecast.SimpleForecast.ForecastDay = new List<WeatherUndergroundDay>();
      var wUndergroundDay = new WeatherUndergroundDay();
      wUndergroundDay.Conditions = "Sunny";
      wUndergroundDay.Date = new WeatherUndergroundDate();
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
      mapper = new Mock<IWeatherUndergroundModelMapper>();
      weatherUndergroundModel = GetWeatherUndergroundModel();
    }

    [TestCase]
    public void GetForecast_ShouldCallRequiredMethods()
    {
      //ARRANGE
      var provider = new WeatherUndergroundProvider(requestHandler.Object, mapper.Object);

      //ACT
      var model = provider.GetForecast(1, 2);

      //ASSERT
      requestHandler.Verify(x => x.GetDeserializedObjectFromRequest<WeatherUndergroundModel>(It.IsAny<string>()), Times.Once);
      mapper.Verify(x => x.Map(It.IsAny<WeatherUndergroundModel>()), Times.Once);
    }
  }
}
