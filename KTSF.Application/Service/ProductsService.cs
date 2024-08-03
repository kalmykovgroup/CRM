using CSharpFunctionalExtensions;
using KTSF.Core;
using KTSF.Core.Product_;
using KTSF.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Service
{
    public class ProductsService
    {
        private AppDbContext dbContext;

        public ProductsService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Result<Product> Find(int id)
        {
            Product? product = dbContext.Products.Find(id);

            return product != null ? Result.Success(product) : Result.Failure<Product>("Not found");
        }

        public Result<Product[]> GetAll()
        {
            return Result.Success(dbContext.Products.ToArray());
        }


        public Result<Product> Create(Product product)
        {
            dbContext.Products.Add(product);
            try
            {
                dbContext.SaveChanges();
                return Result.Success(product);

            }
            catch (Exception ex)
            {
                return Result.Failure<Product>(ex.ToString());
            }

        }

        public Result<Product> Update(Product product)
        {

            try
            {
                dbContext.Attach(product);
                dbContext.SaveChanges();

                return Result.Success(product);
            }
            catch (Exception ex)
            {
                return Result.Failure<Product>(ex.Message);
            }

        }
    }
}
