using CSharpFunctionalExtensions;
using KTSF.Core;
using KTSF.Core.Product_;
using KTSF.Dto.Product_;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        

        // поиск продукта по Id
        public async Task<Result<Product>> Find(int id)
        {
            Product? product = await dbContext.Products
                .Where(prod => prod.Id == id)                
                .FirstOrDefaultAsync();

            return product != null ? Result.Success(product) : Result.Failure<Product>("Not found");
        }


        // полная информация о продукте
        public async Task<Result<ProductDTO>> GetProductFullInfo(int id)
        {
            ProductDTO? product = await dbContext.Products
                .Where(prod => prod.Id == id)
                .Include(prodInf => prodInf.ProductInformation)
                .Include(unit => unit.Unit)
                .Include(art => art.Articles)
                .Include(bar => bar.Barcodes)
                .Include(cat => cat.Categories)
                .Select(prod => new ProductDTO()
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    BuyPrice = prod.BuyPrice,
                    SalePrice = prod.SalePrice,
                    OldPrice = prod.OldPrice,
                    UpdatedAt = prod.UpdatedAt,
                    UnitInfo = prod.Unit.Name,
                    ProductInformation = new ProductInformationDTO()
                    {
                        Id = prod.ProductInformation.Id,
                        NameToPrint = prod.ProductInformation.NameToPrint,
                        Description = prod.ProductInformation.Description,
                        Width = prod.ProductInformation.Width,
                        Height = prod.ProductInformation.Height,
                        Length = prod.ProductInformation.Length,
                        Weight = prod.ProductInformation.Weight,
                        CreatedAt = prod.ProductInformation.CreatedAt,
                        UpdatedAt = prod.ProductInformation.UpdatedAt
                    },
                    Articles = prod.Articles.Select(art => new ArticleDTO() 
                    {
                        Id = art.Id, 
                        Name = art.Name
                    }).ToList(),
                    Barcodes = prod.Barcodes.Select(bar => new BarcodeDTO()
                    {
                        Id = bar.Id,
                        Code = bar.Code,
                        Type = (int)bar.Type
                    }).ToList(),
                    Categories = prod.Categories.Select(category => new CategoryDTO()
                    {
                        Id= category.Id,
                        Name = category.Name,
                    }).ToList()

                })
                .FirstOrDefaultAsync();

            return product != null ? Result.Success(product) : Result.Failure<ProductDTO>("Not found");
        }


        // поиск продукта по названию
        public async Task<Result<Product[]>> SearchProduct(string name)
        {
            Product[] products = await dbContext.Products.ToArrayAsync();
            List<Product> results = [];

            int count = 0;

            foreach(Product product in products)
            {                
                if (product.Name.ToLower().Contains(name.ToLower()))
                {
                    results.Add(product);
                    count++;
                }

                if (count == 20) break;
            }

            return results != null ? Result.Success(results.ToArray()) : Result.Failure<Product[]>("Not found");
        }


        // получить первую страницу с продуктами
        public async Task<Result<FirstPage>> GetFirstPage()
        {
            FirstPage result = new FirstPage();

            int count = await dbContext.Products.CountAsync();

            result.pageCount = (double)count / 20 > (double)1 ? count / 20 + 1 : 1;

            result.Products = await dbContext.Products
                .Take(20)
                .ToArrayAsync();

            return result;
        }


        // получить определенную страницу с продуктами
        public async Task<Result<Product[]>> GetProducts(int page)
        {
            int position = 0;

            if (page != 1)
            {
                position = (page - 1) * 20;
            }                   

            var products = await dbContext.Products               
                .Skip(position)
                .Take(20)
                .ToArrayAsync();            

            return products != null ? Result.Success(products) : Result.Failure<Product[]>("Not found");
        }
                     

        // получение всех продуктов
        public async Task<Result<List<Product>>> GetAll()
        {
            return Result.Success(dbContext.Products.ToList());
        }


        // создание 
        public async Task<Result<Product>> Insert(Product product)
        {
            dbContext.Products.Add(product);
            try
            {
                await dbContext.SaveChangesAsync();
                return Result.Success(product);

            }
            catch (Exception ex)
            {
                return Result.Failure<Product>(ex.ToString());
            }
        }


        // обновление
        public async Task<Result<Product>> Update(Product product)
        {
            try
            {
                dbContext.Attach(product);
                await dbContext.SaveChangesAsync();

                return Result.Success(product);
            }
            catch (Exception ex)
            {
                return Result.Failure<Product>(ex.Message);
            }
        }


    }
}
