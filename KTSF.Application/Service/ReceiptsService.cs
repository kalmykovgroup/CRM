using CSharpFunctionalExtensions;
using KTSF.Dto.Product_;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore;

using KTSF.Core.Object.Receipt_;
using KTSF.Dto.Receipt_;

namespace KTSF.Application.Service
{
    public class ReceiptsService
    {
        private ObjectDbContext dbContext;
        private int countItems = 20;

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

        // получить первую страницу с чеками
        public async Task<Result<FirstPage<Receipt>>> GetFirstPageReceipt()
        {
            FirstPage<Receipt> result = new FirstPage<Receipt>();
            
            int count = await dbContext.Receipts.CountAsync();
            
            result.CountAllItems = count;

            result.CountItemsForPage = countItems;

            result.PageCount = (double)count / countItems > 1 ? count / countItems + 1 : 1;

            result.Items = await dbContext.Receipts
                .Include(receipt => receipt.ReceiptPaymentInfo)
                .ThenInclude(rpi => rpi.PaymentMethod)
                .Take(countItems)
                .ToArrayAsync();

            return result != null ? Result.Success(result) : Result.Failure<FirstPage<Receipt>>("Not found");
        }




        // получить определенную страницу с чеками
        public async Task<Result<Receipt[]>> GetReceipts(int page)
        {
            int position = 0;

            if (page != 1)
            {
                position = (page - 1) * countItems;
            }                   

            var receipts = await dbContext.Receipts               
                .Skip(position)
                .Take(countItems)
                .ToArrayAsync();            

            return receipts != null ? Result.Success(receipts) : Result.Failure<Receipt[]>("Not found");
        }
                     

        // получение всех чеков
        public async Task<Result<List<Receipt>>> GetAll()
        {
            return Result.Success(await dbContext.Receipts.ToListAsync());
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
