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

        public static string ConnectionString { get; } = @"Server=127.0.0.1;Database=test;Uid=root;Pwd=;";
 

        public DbSet<Employee> Employees { get; set; }
        public DbSet<KTSFClassLibrary.Object> Objects { get; set; }
        public DbSet<User> MainUsers { get; set; }
        public DbSet<Company> Companies { get; set; }

        #region ABAC

        public DbSet<DataBaseAccessAttribute> AccessAttributes { get; set; }
        public DbSet<DataBaseAction> DatabaseActions { get; set; }  

        #endregion 


        #region PackingList

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
            optionsBuilder.UseMySQL(ConnectionString);
        }
    }
}
