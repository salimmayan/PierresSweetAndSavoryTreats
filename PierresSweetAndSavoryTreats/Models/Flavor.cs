using System.Collections.Generic;

namespace PierresSweetAndSavoryTreats.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public string FlavorName { get; set; }
    public virtual ICollection<FlavorTreat> FlavorTreats { get; set; }

    public Flavor()
    {
      this.FlavorTreats = new HashSet<FlavorTreat>();
    }
  }
}