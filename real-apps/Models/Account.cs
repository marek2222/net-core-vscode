using System.Collections.Generic;

namespace real_apps.Models
{
  public class Account
  {
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Description { get; set; }

    public bool Status { get; set; }

    public List<string> Languages { get; set; }

    public string Gender { get; set; }

    public string Role { get; set; }
  }
}