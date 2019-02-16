using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvc_filmy.Models
{
  public class GatunekFilmuViewModel
  {
    public List<Film> Filmy;
    public SelectList Gatunki;
    public string GatunekFilmu { get; set; }
    public string Szukane { get; set; }
  }
}