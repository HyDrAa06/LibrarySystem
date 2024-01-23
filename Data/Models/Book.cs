using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Data.Models
{
    public class Book
    {
		[Key]
		public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public Boolean Available { get; set; } = true;

		#region NavigationProperty

		public BooksCustomer BookCustomer { get; set; }

		#endregion
	}
}
