using System;

namespace LoginRegistration.Models
{
  public class Plan : DataModel
  {
    public int PlanId { get; set; }
    public string Content { get; set; }
    public decimal Cost { get; set; }
    public TimeSpan Duration { get; set; }
    public int VillainId { get; set; }

    // Navigation property
    public Villain Villain { get; set; }
  }
}