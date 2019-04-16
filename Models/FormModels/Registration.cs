using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{
  public class Registration
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Confirm { get; set; }
  }
}