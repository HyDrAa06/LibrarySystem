using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Data.Models
{
	public class BooksCustomer
	{
		[ForeignKey("CustomerId")]
		public int CustomerId { get; set; }

		[ForeignKey("BookId")]

		public int BookId { get; set; }

		#region NavigationProperties
		public Book Books { get;set; }
		public Customer Customer { get;set; }

		#endregion
	}
}
