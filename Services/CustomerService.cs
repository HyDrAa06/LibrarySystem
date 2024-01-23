using LibrarySystem.Data;
using LibrarySystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class CustomerService
    {
        private IDbContextFactory<LibraryDbContext> _dbContextFactory;

        public CustomerService(IDbContextFactory<LibraryDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddCustomer(Customer customer)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
				if(customer.Name != null && customer.Address != null)
				{
					context.Customers.Add(customer);
					context.SaveChanges();
				}
                
            }
        }

        public List<Customer> CreateList()
        {
            List<Customer> list = new List<Customer>();
			using (var context = _dbContextFactory.CreateDbContext())
			{
				foreach (var item in context.Customers)
				{
                    list.Add(item);
				}
			}
            return list;
		}

        public void DeleteACustomer(int id)
        {
			using (var context = _dbContextFactory.CreateDbContext())
			{
				foreach (var item in context.Customers)
				{
					if (id == item.Id)
					{

						context.Customers.Remove(item);


						break;
					}
				}

				context.SaveChanges();

			}
		}
		public void DeleteCustomer()
		{
            using ( var context = _dbContextFactory.CreateDbContext())
            {
				string resetId = "DBCC CHECKIDENT('Customers', RESEED, 0)";
				string delete = "DELETE FROM Customers";
                context.Database.ExecuteSqlRaw(delete);
				context.Database.ExecuteSqlRaw(resetId);

			}

		}
    }
}
