namespace booklist_razor.Model {
	public class Book {
		
		public int Id { get; set; }
		public string Tytul { get; set; }
		public string Autor { get; set; }
		public string ISBN { get; set; }
		public int Dostepnosc { get; set; }
		public double Cena { get; set; }
	}
}