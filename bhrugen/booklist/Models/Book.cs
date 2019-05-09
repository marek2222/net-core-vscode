using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace booklist.Models {

	public class Book {

		public int Id { get; set; }

		[Required]
		[DisplayName ("Nazwa")]
		public string Name { get; set; }
	}
}