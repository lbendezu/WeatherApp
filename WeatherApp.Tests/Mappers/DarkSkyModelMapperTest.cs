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
  public class DarkSkyModelMapperTest
  {
    Mock<ISettingsManager> settingsManager;
    private DarkSkyModel model;

    [SetUp]
    public void Initialize()
    {
      settingsManager = new Mock<ISettingsManager>();
      model = GetDarkSkyModel();
    }

    private DarkSkyModel GetDarkSkyModel()
    {
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

    [TestCase]
    public void Map_ShouldHaveAllCorrectData()
    {
      //ARRANGE
      var mapper = new DarkSkyModelMapper(settingsManager.Object);
      settingsManager.Setup(x => x.Get(It.IsAny<string>())).Returns("1");

      //ACT
      var result = mapper.Map(model);

      //ASSERT
      settingsManager.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
      Assert.AreEqual(result.CurrentSummary, model.Currently.Summary);
      Assert.AreEqual(result.Icon, model.Currently.Icon);
      Assert.AreEqual(result.CurrentCelsius, model.Currently.Temperature);
      Assert.AreEqual(result.Forecast[0].Icon, model.Daily.Data[0].Icon);
      Assert.AreEqual(result.Forecast[0].Summary, model.Daily.Data[0].Summary);
      Assert.AreEqual(result.Forecast[0].LowCelsius, model.Daily.Data[0].TemperatureLow);
      Assert.AreEqual(result.Forecast[0].HighCelsius, model.Daily.Data[0].TemperatureHigh);
      Assert.AreEqual(result.Forecast[0].Date, new DateTime(1970, 1, 1).AddSeconds(model.Daily.Data[0].Time));
    }

  }
}
