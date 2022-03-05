using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Name is required!")]
		[StringLength(255)]
		public string Name { get; set; }
		[Required]
		public string AuthorName { get; set; }
		public Genre Genre { get; set; }
		[Range(1, byte.MaxValue, ErrorMessage = "Genre is required!")]
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Display(Name="Release Date")]
		[Required(ErrorMessage = "Release date is required!")]
		public DateTime? ReleaseDate { get; set; }
		[Display(Name="Number in Stock")]
		[Range(1,20, ErrorMessage = "Range should be between 1 and 20")]
		[Required(ErrorMessage = "Number in stock can not be empty!")]
		public int? NumberInStock { get; set; }
		public int NumberAvailable { get; set; }
	}

}
