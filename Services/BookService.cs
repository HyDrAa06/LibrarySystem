using LibrarySystem.Data.Models;
using LibrarySystem.Data;
using Microsoft.EntityFrameworkCore;


namespace LibrarySystem.Services
{
	public class BookService
	{
		private IDbContextFactory<LibraryDbContext> _dbContextFactory;

		public BookService(IDbContextFactory<LibraryDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public void AddBook(Book book)
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{
				if(book.Author != null && book.Title != null)
				{
					context.Books.Add(book);
					context.SaveChanges();
				}
				

			}
		}

		public List<Book> CreateList()
		{
			List<Book> list = new List<Book>();
			using (var context = _dbContextFactory.CreateDbContext())
			{
				foreach (var item in context.Books)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public void DeleteABook(int id)
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{
				foreach (var item in context.Books)
				{
					if (id == item.Id)
					{

						context.Books.Remove(item);


						break;
					}
				}

				context.SaveChanges();
			}
		}
		
		public void DeleteBooks()
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{
				string resetId = "DBCC CHECKIDENT('Books', RESEED, 0)";
				string delete = "DELETE FROM Books";
				context.Database.ExecuteSqlRaw(delete);
				context.Database.ExecuteSqlRaw(resetId);
			}
		}
	}
}
