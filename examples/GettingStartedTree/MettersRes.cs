using ServiceStack.OrmLite;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedTree
{


  public class SimpleMeter
  {

    public string meter_type { get; set; }
    public string meter_factory { get; set; }

    public static List<SimpleMeter> ResolveMeters(string meters)
    {
      try
      {
        if (!string.IsNullOrEmpty(meters))
        {
          List<SimpleMeter> lst = JsonSerializer.DeserializeFromString<List<SimpleMeter>>(meters);
          return lst;
        }
        else
          return null;
      }
      catch (Exception)
      {

        return null;
      }

    }

  }
}

