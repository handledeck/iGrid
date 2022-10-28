using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedTree
{
  public class AllResMeter
  {
    public int id { get; set; }
    public int parent_id { get; set; }
    public string name { get; set; }
    public string ip_address { get; set; }
    public string meters { get; set; }

    public List<MeterType> ListMeterType { get; set; }

    public static List<MeterType> ResolveMeters(string meters)
    {
      if (!string.IsNullOrEmpty(meters))
      {
        List<MeterType> lst = JsonSerializer.DeserializeFromString<List<MeterType>>(meters);
        return lst;
      }
      else
        return null;
    }
  }
}
