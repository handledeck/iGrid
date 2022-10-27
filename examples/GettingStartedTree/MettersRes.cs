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

  public class MeterValue {
    public int id { get; set; }
    public DateTime date_time { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    public double value { get; set; }

    public static bool CheckTableDb(IDbConnection dbConnection) {
      
      try
      {
        return dbConnection.CreateTableIfNotExists(typeof(MeterValue));
      }
      catch  {
        return false;
      }
    }
  }

  public class MeterType {
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
  }

  public class MettersRes
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string IP { get; set; }
    public List<MeterType> ListMeterType { get; set; }

    public static List<MeterType> ResolveMeters(string meters) {
      if (!string.IsNullOrEmpty(meters))
      {
        List<MeterType> lst= JsonSerializer.DeserializeFromString<List<MeterType>>(meters);
        return lst;
      }
      else
        return null;
    }
  }
}
