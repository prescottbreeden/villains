using System.Collections.Generic;

namespace LoginRegistration.Models
{
  public class Villain : DataModel
  {
    public int VillainId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Navigation property
    public List<Plan> Plans { get; set; }
    public List<VillainEvilGroup> VillainEvilGroups { get; set; }
  }
}