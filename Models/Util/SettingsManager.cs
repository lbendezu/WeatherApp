using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
  public class SettingsManager : ISettingsManager
  {
    public string Get(string key)
    {
      return ConfigurationManager.AppSettings[key];
    }
  }
}
