using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedTree
{
  public class TreeListNodeModel
  {
      public int id { get; set; }
      public string name { get; set; }
      public DateTime? date_time { get; set; }
      public string ip { get; set; }
      public string meter_type { get; set; }
      public string meter_factory { get; set; }
      public double? value { get; set; }
      public bool is_true { get; set; }
      public List<TreeListNodeModel> Nodes { get; set; }
    }
  }

