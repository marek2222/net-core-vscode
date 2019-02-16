using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using real_apps.Models;
using real_apps.ViewModels;

namespace real_apps.Controllers
{
  [Route("account")]
  public class AccountController : Controller
  {
    [Route("")]
    [Route("index")]
    [Route("~/")]
    public IActionResult Index()
    {
      var accountViewModel = new AccountVM();
      accountViewModel.Account = new Account()
      {
        Id = 123,
        Status = true,
        Gender = "male"
      };
      accountViewModel.Languages = new List<Language>() {
                new Language() { Id = "l1", Name = "Language 1", IsChecked = true  },
                new Language() { Id = "l2", Name = "Language 2", IsChecked = false  },
                new Language() { Id = "l3", Name = "Language 3", IsChecked = true  },
                new Language() { Id = "l4", Name = "Language 4", IsChecked = false  },
                new Language() { Id = "l5", Name = "Language 5", IsChecked = false  }
            };
      var roles = new List<Role>() {
                new Role { Id = "r1", Name = "Role 1" },
                new Role { Id = "r2", Name = "Role 2" },
                new Role { Id = "r3", Name = "Role 3" },
                new Role { Id = "r4", Name = "Role 4" }
            };
      accountViewModel.Roles = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(roles, "Id", "Name");
      return View("Index", accountViewModel);
    }

    [Route("save")]
    [HttpPost]
    public IActionResult Save(AccountVM accountViewModel, List<Language> Languages)
    {
      accountViewModel.Account.Languages = new List<string>();
      foreach (var language in Languages)
      {
        if (language.IsChecked)
        {
          accountViewModel.Account.Languages.Add(language.Id);
        }
      }
      ViewBag.Account = accountViewModel.Account;
      return View("Success");
    }

  }
}