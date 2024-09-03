using CSharpFunctionalExtensions; 
using KTSF.Core.App;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore;
using Object = KTSF.Core.App.Object;

namespace KTSF.Application.Service
{
    public class ObjectService
    {
        private AppDbContext userDbContext;

        public ObjectService(AppDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public async Task<Result<List<Object>>> All()
        {
            List<Object> result = await userDbContext.Objects.Where(obj => obj.ObjectStatus == ObjectStatus.Active).ToListAsync();

            return Result.Success(result);
        }

        public async Task<Result<Object>> Get(int id)
        {
            Object? result = await userDbContext.Objects.Where(obj => obj.Id == id && obj.ObjectStatus == ObjectStatus.Active).FirstOrDefaultAsync();

            if (result == null)
            {
                return Result.Failure<Object>("Not found");
            }
            return Result.Success(result);
        }

        public async Task<Result<Object>> Create(Object @object)
        {
            userDbContext.Objects.Add(@object);

            @object.Created_At = DateTime.Now;

            try
            {
                await userDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Result.Failure<Object>(ex.Message);
            }


            return Result.Success(@object);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            Object? @object = await userDbContext.Objects.Where(obj => obj.Id == id).FirstOrDefaultAsync();

            if (@object != null)
            {
                @object.ObjectStatus = ObjectStatus.Delete;
            }
            else
            {
                return Result.Failure<bool>("Company not found");
            }

            try
            {
                await userDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Result.Failure<bool>(ex.Message);
            }

            return Result.Success(true);
        }
    }
}
