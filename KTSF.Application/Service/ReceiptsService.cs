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
using KTSF.Core.Receipt_;
using KTSF.Dto.Receipt_;

namespace KTSF.Application.Service
{
    public class ReceiptsService
    {
        private AppDbContext dbContext;

        public ReceiptsService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        

        // поиск чека по Id
        public async Task<Result<Receipt>> Find(int id)
        {
            Receipt? receipt = await dbContext.Receipts
                .Where(receipt => receipt.Id == id)                
                .FirstOrDefaultAsync();

            return receipt != null ? Result.Success(receipt) : Result.Failure<Receipt>("Not found");
        }


        // полная информация о чеке
        public async Task<Result<ReceiptDTO>> GetReceiptFullInfo(int id)
        {
            ReceiptDTO? receipt = await dbContext.Receipts
                .Where(receipt => receipt.Id == id)
                .Include(receipt => receipt.BuyProducts)
                .Include(receipt => receipt.ReceiptPaymentInfo)
                .ThenInclude(rpi => rpi.PaymentMethod)
                .Select(receipt => new ReceiptDTO()
                {
                    Id = receipt.Id,
                    Discount = receipt.Discount,
                    ReceiptPaymentInfo = new PaymentInfoDTO()
                    {
                        
                    }
                })
                .FirstOrDefaultAsync();

            return receipt != null ? Result.Success(receipt) : Result.Failure<ReceiptDTO>("Not found");
        }


        // поиск чека по названию
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


        // получить первую страницу с чеками
        public async Task<Result<FirstPage<Product>>> GetFirstPageProduct()
        {
            FirstPage<Product> result = new FirstPage<Product>();

            int count = await dbContext.Products.CountAsync();

            result.PageCount = (double)count / 20 > (double)1 ? count / 20 + 1 : 1;

            result.Items = await dbContext.Products
                .Take(20)
                .ToArrayAsync();

            return result != null ? Result.Success(result) : Result.Failure<FirstPage<Product>>("Not found");
        }




        // получить определенную страницу с чеками
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
                     

        // получение всех чеков
        public async Task<Result<List<Product>>> GetAll()
        {
            return Result.Success(await dbContext.Products.ToListAsync());
        }

        

        // !!!!! ИСПРАВИТЬ !!!!
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
                Product? prod = dbContext.Products.Where(pr => pr.Id == product.Id).FirstOrDefault();

                if (prod == null) return Result.Failure<Product>("Not found");

                prod.Id = product.Id;
                prod.Name = product.Name;
                prod.BuyPrice = product.BuyPrice;
                prod.SalePrice = product.SalePrice;
                prod.OldPrice = product.OldPrice;
                prod.UpdatedAt = product.UpdatedAt;
                prod.UnitId = product.UnitId;

                await dbContext.SaveChangesAsync();

                return Result.Success(prod);
            }
            catch (Exception ex)
            {
                return Result.Failure<Product>(ex.Message);
            }
        }


    }
}
