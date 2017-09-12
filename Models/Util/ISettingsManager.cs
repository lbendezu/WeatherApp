using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
  public interface ISettingsManager
  {
    string Get(string key);
  }
}
