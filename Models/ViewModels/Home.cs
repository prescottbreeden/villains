using System.Collections.Generic;

namespace LoginRegistration.Models
{
  public class Home
  {
    public Villain Villain { get; set; }
    public Plan NewPlan { get; set; }
    public List<Plan> AllPlans { get; set; }
    public List<EvilGroup> AllGroups { get; set; }
  }
}