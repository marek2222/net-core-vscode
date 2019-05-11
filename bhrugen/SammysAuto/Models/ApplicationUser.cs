using Microsoft.AspNetCore.Identity;

namespace SammysAuto.Models
{
  public class ApplicationUser : IdentityUser
  {
    [PersonalData]
    public string Name { get; set; }
    [PersonalData]
    public string Address { get; set; }
    [PersonalData]
    public string City { get; set; }
    [PersonalData]
    public string PostalCode { get; set; }
  }
}