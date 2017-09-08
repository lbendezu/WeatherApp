using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
  public class RequestHandler : IRequestHandler
  {
    public T GetDeserializedObjectFromRequest<T>(string url) where T : class
    {
      T deserializedObject = null;

      using (var httpWebResponse = (HttpWebResponse)WebRequest.Create(url).GetResponse())
      {
        using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
        {
          string jsonRes = streamReader.ReadToEnd();
          deserializedObject = JsonConvert.DeserializeObject<T>(jsonRes);
        }        
      }

      return deserializedObject;
    }
  }
}
