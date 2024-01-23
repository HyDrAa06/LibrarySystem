using LibrarySystem.Data.Models;
using LibrarySystem.Data;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
	public class BooksCustomerService
	{
		private IDbContextFactory<LibraryDbContext> _dbContextFactory;

		public BooksCustomerService(IDbContextFactory<LibraryDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public bool AddBooksCustomer(BooksCustomer bookCustomer)
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{
				bool returning = false;

				if (bookCustomer.BookId == -1 || bookCustomer.CustomerId == -1)
				{
					return returning;
				}

				else
				{
					foreach (var book in context.Books)
					{
						if(book.Id==bookCustomer.BookId)
						{
							if(book.Available == false)
							{
								return returning;
							}
							else
							{
								book.Available = false;
								context.BooksCustomers.Add(bookCustomer);

								returning = true; ;

							}
						}
					}
					context.SaveChanges();
					return returning;
				}
				
			}
		}

		public BooksCustomer CheckId(int bookId, int customerId)
		{
			BooksCustomer bookCustomer = new BooksCustomer();
			bookCustomer.CustomerId = -1;
			bookCustomer.BookId = -1;
			using (var context = _dbContextFactory.CreateDbContext())
			{
				List<int> bookIds = new List<int>();
				List<int> customerIds = new List<int>();

				foreach(var book in context.Books)
				{
					bookIds.Add(book.Id);
				}
				foreach(var customer in context.Customers)
				{
					customerIds.Add(customer.Id);
				}

				if(bookIds.Contains(bookId) && customerIds.Contains(customerId))
				{

					foreach (var item in context.Books)
					{
						if (bookId == item.Id)
						{
							bookCustomer.BookId = item.Id;
						}
					}
					foreach (var item in context.Customers)
					{
						if (customerId == item.Id)
						{
							bookCustomer.CustomerId = item.Id;
						}
					}
				}
				else
				{
				
				}

			}
			return bookCustomer;
		}

		public List<Customer> CreateCustomersList()
		{
			List<Customer> list = new List<Customer>();
			using (var context = _dbContextFactory.CreateDbContext())
			{
				foreach (var item in context.Customers)
				{
					foreach (var item2 in context.BooksCustomers)
					{
						if (item2.CustomerId == item.Id)
						{
							list.Add(item);
						}
					}
				}
			}
			return list;
		}

		public List<Book> BooksToACustomerList(Customer customer)
		{
			List<Book> allBooksToACustomer = new List<Book>();
			using (var context = _dbContextFactory.CreateDbContext())
			{
				foreach (var item in context.BooksCustomers)
				{
					if(item.CustomerId== customer.Id)
					{
						foreach(var item2 in customer.BookCustomer)
						{
							foreach(var book in context.Books)
							{
								if (item2.BookId == book.Id)
								{
									allBooksToACustomer.Add(book);
								}
							}
						}
					}
				}

			}
			return allBooksToACustomer;
		}


		public void DeleteARelationViaId(int customerId)
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{

				List<BooksCustomer> booksCustomerToRemove = new List<BooksCustomer>();
				foreach(var bookCustomer in context.BooksCustomers)
				{
					if(bookCustomer.CustomerId== customerId)
					{
						booksCustomerToRemove.Add(bookCustomer);
					}
				}
				for(int i = 0; i < booksCustomerToRemove.Count; i++)
				{
					foreach(var books in booksCustomerToRemove)
					{
						foreach(var book in context.Books)
						{
							if (book.Id == books.BookId)
							{
								book.Available = true;
							}
						}
					}
					context.BooksCustomers.Remove(booksCustomerToRemove[i]);

				}
				context.SaveChanges();

			}
		}
		public void DeleteAllRelations()
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{
				foreach(var book in context.Books)
				{
					book.Available = true;
				}
				string delete = "DELETE FROM BooksCustomers";
				context.Database.ExecuteSqlRaw(delete);
				context.SaveChanges();
			}
		}
	}
}

