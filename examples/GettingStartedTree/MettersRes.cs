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

  public class MeterInfo
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }
    public int ctrl_id { get; set; }
   
    public string meter_type { get; set; }
    public string meter_factory { get; set; }

    public static bool CheckTableDb(IDbConnection dbConnection)
    {

      try
      {
        return dbConnection.CreateTableIfNotExists(typeof(MeterInfo));
      }
      catch
      {
        return false;
      }
    }
  }

  public class MeterValue {
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }
    public int ctrl_id { get; set; }
    public int parent_id { get; set; }
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
    public DateTime date_time { get; set; }
    public float value { get; set; }
  }

  public class MettersRes
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string IP { get; set; }
    public List<MeterType> ListMeterType { get; set; }

    public static List<MeterType> ResolveMeters(string meters) {
      try
      {
        if (!string.IsNullOrEmpty(meters))
        {
          List<MeterType> lst = JsonSerializer.DeserializeFromString<List<MeterType>>(meters);
          return lst;
        }
        else
          return null;
      }
      catch (Exception)
      {

        throw;
      }
      
    }
  }
}
