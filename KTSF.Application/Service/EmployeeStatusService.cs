using CSharpFunctionalExtensions;
 
using KTSF.Core.Object;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Service
{
    public class EmployeeStatusService
    {
        private ObjectDbContext dbContext;

        public EmployeeStatusService(ObjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        // создание 
        public async Task<Result<EmployeeStatus>> Insert(EmployeeStatus employeeStatus)
        {
            dbContext.EmployeeStatuses.Add(employeeStatus);
            try
            {
                await dbContext.SaveChangesAsync();
                return Result.Success(employeeStatus);
            }
            catch (Exception ex)
            {
                return Result.Failure<EmployeeStatus>(ex.ToString());
            }
        }


        // обновление
        public async Task<Result<EmployeeStatus>> Update(EmployeeStatus employeeStatus)
        {
            try
            {
                EmployeeStatus? status = dbContext.EmployeeStatuses
                    .Where(empl => empl.Id == employeeStatus.Id).FirstOrDefault();

                if (status == null) return Result.Failure<EmployeeStatus>("Not found");

                status.Id = employeeStatus.Id;
                status.Name = employeeStatus.Name;
               
                await dbContext.SaveChangesAsync();

                return Result.Success(status);
            }
            catch (Exception ex)
            {
                return Result.Failure<EmployeeStatus>(ex.Message);
            }
        }



        // получение всех 
        public async Task<Result<List<EmployeeStatus>>> GetAll()
        {
            return Result.Success(await dbContext.EmployeeStatuses.ToListAsync());
        }


        // поиск по Id
        public async Task<Result<EmployeeStatus>> Find(int id)
        {
            EmployeeStatus? appointment = await dbContext.EmployeeStatuses
                 .Where(emp => emp.Id == id)
                 .FirstOrDefaultAsync();

            return appointment != null ? Result.Success(appointment) : Result.Failure<EmployeeStatus>("Not found");
        }




    }
}
