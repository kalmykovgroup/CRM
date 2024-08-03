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
    public class EmployeesService
    {
        public AppDbContext dbContext;

        public EmployeesService(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }



        public Result<Employee> Find(int id)
        {
            Employee? employee = dbContext.Employees.Find(id);

            return employee != null ? Result.Success(employee) : Result.Failure<Employee>("Not found");
        }

        public Result<Employee[]> GetAll()
        {
            return Result.Success(dbContext.Employees.ToArray());
        }


        public Result<Employee> Create(Employee employee)
        {
            dbContext.Employees.Add(employee);
            try
            {
                dbContext.SaveChanges();
                return Result.Success(employee);

            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>(ex.ToString());
            }

        }

        public Result<Employee> Update(Employee employee)
        {

            try
            {
                dbContext.Attach(employee);
                dbContext.SaveChanges();

                return Result.Success(employee);
            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>(ex.Message);
            }

        }
    }
}
