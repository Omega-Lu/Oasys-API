using Microsoft.EntityFrameworkCore;
using OaSys.API.Models;

namespace OaSys.API.Data
{
    public class OasysDBContext : DbContext
    {
        public OasysDBContext(DbContextOptions options) : base(options)
        {
        }

        //DBset for the databaseS
        public DbSet<User> User { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Employee_Type> Employee_Type { get; set; }

        public DbSet<Rate> Rate { get; set; }

        public DbSet<Warning> Warning { get; set; }

        public DbSet<Warning_Type> Warning_Type { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Customer_Account> Customer_Account { get; set; }

        public DbSet<Product_Category> Product_Category { get; set; }

        public DbSet<Product_Type> Product_Type { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<Return> Return { get; set;}

        public DbSet<StockTake> Stocktake { get; set; }

        public DbSet<AuditLog> AuditLog { get; set; }

        
    }
}
