using System.Collections.Generic;

namespace real_apps.Models
{
  public class Product
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public List<string> Photos { get; set; }
  }
}