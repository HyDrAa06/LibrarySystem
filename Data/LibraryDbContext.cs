using LibrarySystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BooksCustomer> BooksCustomers{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasOne(c => c.BookCustomer)
                .WithOne(b => b.Books);



			builder.Entity<Customer>()
                .HasMany(b => b.BookCustomer)
                .WithOne(c => c.Customer);

            builder.Entity<BooksCustomer>(e =>
            {
                e.HasKey(bc => new { bc.BookId, bc.CustomerId });

                e.HasOne(c => c.Customer)
                .WithMany(bc => bc.BookCustomer);
                

                e.HasOne(c => c.Books)
                .WithOne(bc => bc.BookCustomer);
                

			});
        }          
	}
}
