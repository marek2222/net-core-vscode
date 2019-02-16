using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using real_apps.Models;

namespace real_apps.ViewModels
{
  public class AccountVM
  {
    public Account Account { get; set; }
    public List<Language> Languages { get; set; }
    public SelectList Roles { get; set; }
  }
}