using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace booklist_razor.Model {
	public class Book {
		
		public int Id { get; set; }

		[DisplayName("Tytuł")]
		public string Tytul { get; set; }
		public string Autor { get; set; }
		public string ISBN { get; set; }

		[Required]
		[DisplayName("Dostepność")]
		public int Dostepnosc { get; set; }
		public double Cena { get; set; }
	}
}