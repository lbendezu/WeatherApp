using System;
using Moq;
using Providers;
using Models;
using System.Collections.Generic;
using Models.Mappers;
using Models.Util;
using NUnit.Framework;

namespace WeatherApp.Tests.Providers
{
 
  [TestFixture]
  public class DarkSkyProviderTest
  {
    private Mock<IRequestHandler> requestHandler;
    private Mock<IDarkSkyModelMapper> mapper;
    private Mock<ISettingsManager> settingsManager;    

    [SetUp]
    public void Initialize() {
      requestHandler = new Mock<IRequestHandler>();
      mapper = new Mock<IDarkSkyModelMapper>();
      settingsManager = new Mock<ISettingsManager>();
    }

    [TestCase]
    public void GetForecast_ShouldCallRequiredMethods()
    {      
      //ARRANGE
      var provider = new DarkSkyProvider(requestHandler.Object, mapper.Object, settingsManager.Object);
      settingsManager.Setup(x => x.Get(It.IsAny<string>())).Returns(string.Empty);

      //ACT
      var model = provider.GetForecast(1, 2);

      //ASSERT
      settingsManager.Verify(x => x.Get(It.IsAny<string>()), Times.Exactly(2));
      requestHandler.Verify(x => x.GetDeserializedObjectFromRequest<DarkSkyModel>(It.IsAny<string>()), Times.Once);
      mapper.Verify(x => x.Map(It.IsAny<DarkSkyModel>()), Times.Once);
    }
  }
}
