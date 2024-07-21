using KTSFClassLibrary;
using KTSFClassLibrary.ABAC;
using KTSFClassLibrary.PackingList_;
using KTSFClassLibrary.Product_;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Configuration;
using System.Reflection.Metadata;

namespace CRST_ServerAPI.Data
{
    public class AppDbContext : DbContext
    {

        public static string ConnectionString { get; set; } = String.Empty;
 

        public DbSet<Employee> Employees { get; set; }
        public DbSet<KTSFClassLibrary.Object> Objects { get; set; }
        public DbSet<User> MainUsers { get; set; }
        public DbSet<Company> Companies { get; set; }

        #region ABAC

        public DbSet<User> Users { get; set; }

        public DbSet<DataBaseAccessAttribute> DataBaseAccessAttributes { get; set; }
        public DbSet<DataBaseAction> DataBaseActions { get; set; }

        public DbSet<ComponentAccessAttribute> ComponentAccessAttributes { get; set; }

         public DbSet<EmployeeAction> EmployeeActions { get; set; }
         public DbSet<Appointment> Appointments { get; set; }

        #endregion


        #region PackingList

             //Товарная накладная
             public DbSet<PackingList> PackingLists { get; set; }
             public DbSet<PackingListProduct> PackingListProducts { get; set; }

        #endregion

        #region Product

              public DbSet<Article> Articles { get; set; }
              public DbSet<Barcode> Barcodes { get; set; }
              public DbSet<Category> Categories { get; set; }
              public DbSet<Group> Groups { get; set; }
              public DbSet<Price> Prices { get; set; }
              public DbSet<Product> Products { get; set; }
              public DbSet<Unit> Units { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseMySQL("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
        }
    }
}
