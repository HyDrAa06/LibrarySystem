using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

		#region NavigationProperty
		public ICollection<BooksCustomer>? BookCustomer { get; set; }

		#endregion
	}
}
