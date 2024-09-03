using CSharpFunctionalExtensions; 
using KTSF.Core.App;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore; 

namespace KTSF.Application.Service
{
    public class CompanyService
    {
        private AppDbContext userDbContext;

        public CompanyService(AppDbContext userDbContext) {
            this.userDbContext = userDbContext;
        }

        public async Task<Result<List<Company>>> All()
        {
            List<Company> result = await userDbContext.Companies.Where(c => c.CompanyStatus == CompanyStatus.Active)
                .Include(c => c.Objects)              
                .ToListAsync();

            return Result.Success(result);
        }

        public async Task<Result<Company>> Get(int id)
        {
            Company? result = await userDbContext.Companies.Where(c  => c.Id == id && c.CompanyStatus == CompanyStatus.Active).FirstOrDefaultAsync();

            if (result == null) {
                return Result.Failure<Company>("Not found");
            }
            return Result.Success(result);
        }

        public async Task<Result<Company>> Create(Company company)
        {
            userDbContext.Companies.Add(company);
            company.Created_At = DateTime.Now;

            try
            {
                await userDbContext.SaveChangesAsync();
            }
            catch (Exception ex) {
                return Result.Failure<Company>(ex.Message);
            }
           

            return Result.Success(company); 
        }

        public async Task<Result<bool>> Delete(int id)
        {
            Company? company = await userDbContext.Companies.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (company != null) {
                company.CompanyStatus = CompanyStatus.Delete;
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
