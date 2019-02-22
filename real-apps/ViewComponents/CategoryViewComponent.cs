using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace real_apps.ViewComponents
{
  [ViewComponent(Name = "Category")]
  public class CategoryViewComponent : ViewComponent
  {
    public async Task<IViewComponentResult> InvokeAsync()
    {
      List<string> categories = new List<string>() {
                "Category 1", "Category 2", "Category 3", "Category 4", "Category 5"
            };
      return View("Index", categories);
    }

  }
}