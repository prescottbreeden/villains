using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{
  public class NewPlan
  {
    [Required]
    public string Content { get; set; }
    [Required]
    public decimal Cost { get; set; }
    [Required]
    public TimeSpan Duration { get; set; }
  }
}