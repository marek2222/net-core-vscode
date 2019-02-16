using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvc_filmy.Models
{
  public class MovieGenreViewModel
  {
    public List<Movie> Movies;
    public SelectList Genres;
    public string MovieGenre { get; set; }
    public string SearchString { get; set; }
  }
}