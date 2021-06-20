using System.Collections.Generic;

namespace PierresSweetAndSavoryTreats.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    public string TreatName { get; set; }
    public string TreatPrice { get; set; }
    public virtual ICollection<FlavorTreat> FlavorTreats { get; set; }

    public Treat()
    {
      this.FlavorTreats = new HashSet<FlavorTreat>();
    }
  }
}