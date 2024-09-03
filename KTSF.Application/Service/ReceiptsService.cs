using CSharpFunctionalExtensions;
using KTSF.Core.Object.Product_;
using KTSF.Dto.Product_;
using KTSF.Persistence;
using KTSF.Core.Object.Receipt_;
using KTSF.Dto.Receipt_;
using Microsoft.EntityFrameworkCore;

namespace KTSF.Application.Service
{
    public class ReceiptsService
    {
        private ObjectDbContext dbContext;

        public ReceiptsService(ObjectDbContext dbContext)
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
        public async Task<Result<Receipt>> Insert(Receipt receipt)
        {
            dbContext.Receipts.Add(receipt);
            try
            {
                await dbContext.SaveChangesAsync();
                return Result.Success(receipt);
            }
            catch (Exception ex)
            {
                return Result.Failure<Receipt>(ex.ToString());
            }
        }


        // обновление
        public async Task<Result<Receipt>> Update(Receipt receipt)
        {
            try
            {
                Receipt? updateReceipt = dbContext.Receipts.Where(rec => rec.Id == receipt.Id).FirstOrDefault();

                if (updateReceipt == null) return Result.Failure<Receipt>("Not found");

                updateReceipt.Id = receipt.Id;
                updateReceipt.Discount = receipt.Discount;
                updateReceipt.CreatedDate = receipt.CreatedDate;
                updateReceipt.PaymentInfoId = receipt.PaymentInfoId;

                await dbContext.SaveChangesAsync();

                return Result.Success(updateReceipt);
            }
            catch (Exception ex)
            {
                return Result.Failure<Receipt>(ex.Message);
            }
        }


    }
}
