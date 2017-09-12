using Models.Util;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mappers
{
  [TestFixture]
  public class WeatherUndergroundModelMapperTest
  {
    Mock<ISettingsManager> settingsManager;
    private WeatherUndergroundModel model;

    [SetUp]
    public void Initialize()
    {
      settingsManager = new Mock<ISettingsManager>();
      model = GetWeatherUndergroundModel();
    }

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
      var weatherUndergroundDay = new WeatherUndergroundDay();
      weatherUndergroundDay.Conditions = "Sunny";
      weatherUndergroundDay.Date = new WeatherUndergroundDate();
      weatherUndergroundDay.Date.Epoch = 1111111;
      weatherUndergroundDay.High = new High();
      weatherUndergroundDay.High.Celsius = 21;
      weatherUndergroundDay.High.Fahrenheit = 74;
      weatherUndergroundDay.Low = new Low();
      weatherUndergroundDay.Low.Celsius = 14;
      weatherUndergroundDay.Low.Fahrenheit = 43;
      weatherUndergroundDay.Icon = "Numb";
      weatherUndergroundDay.IconUrl = "Numb";
      model.Forecast.SimpleForecast.ForecastDay.Add(weatherUndergroundDay);
      return model;
    }

    [TestCase]
    public void Map_ShouldHaveAllCorrectData()
    {
      //ARRANGE
      var mapper = new WeatherUndergroundModelMapper(settingsManager.Object);
      settingsManager.Setup(x => x.Get(It.IsAny<string>())).Returns("1");

      //ACT
      var result = mapper.Map(model);

      //ASSERT
      settingsManager.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
      Assert.AreEqual(result.CurrentSummary, model.Current_Observation.Weather);
      Assert.AreEqual(result.Icon, model.Current_Observation.Icon);
      Assert.AreEqual(result.CurrentCelsius, model.Current_Observation.Temp_C);
      Assert.AreEqual(result.Forecast[0].Icon, model.Forecast.SimpleForecast.ForecastDay[0].Icon);
      Assert.AreEqual(result.Forecast[0].Summary, model.Forecast.SimpleForecast.ForecastDay[0].Conditions);
      Assert.AreEqual(result.Forecast[0].LowCelsius, model.Forecast.SimpleForecast.ForecastDay[0].Low.Celsius);
      Assert.AreEqual(result.Forecast[0].HighCelsius, model.Forecast.SimpleForecast.ForecastDay[0].High.Celsius);
      Assert.AreEqual(result.Forecast[0].Date, new DateTime(1970, 1, 1).AddSeconds(model.Forecast.SimpleForecast.ForecastDay[0].Date.Epoch));
    }
  }
}
