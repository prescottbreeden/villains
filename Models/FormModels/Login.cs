using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{
  public class Login
  {
    [Required(ErrorMessage = "Email is required.")]
    public string LoginEmail { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string LoginPassword { get; set; }

  }
}