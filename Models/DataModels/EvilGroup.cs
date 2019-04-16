using System.Collections.Generic;

namespace LoginRegistration.Models
{
  public class EvilGroup : DataModel
  {
    public int EvilGroupId { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public List<VillainEvilGroup> VillainEvilGroups { get; set; }
  }
}