using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  public interface IRequestHandler
  {
    T GetDeserializedObjectFromRequest<T>(string url) where T : class;
  }
}
