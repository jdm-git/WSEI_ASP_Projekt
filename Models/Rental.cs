using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public int BookId { get; set; }
        [Required]
        public Book Book { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}
