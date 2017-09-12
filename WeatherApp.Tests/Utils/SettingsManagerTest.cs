using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
  [TestFixture]
  public class SettingsManagerTest
  {
    [TestCase]
    public void Get_ShouldGetAppConfigString() {
      var settingsManager = new SettingsManager();

      var value = settingsManager.Get(Constants.FORECAST_DEFAULT_SIZE);

      Assert.AreEqual("7", value);
    }
  }
}
