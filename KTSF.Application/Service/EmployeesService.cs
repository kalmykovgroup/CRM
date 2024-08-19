using CSharpFunctionalExtensions;
using KTSF.Core;
using KTSF.Core.Product_;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore;
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


        // поиск по ID
        public async Task<Result<Employee>> Find(int id)
        {
            Employee? employee = await dbContext.Employees
                .Where(emp => emp.Id == id)
                .Include(obj => obj.Object)
                .ThenInclude(comp => comp.Company)
                .ThenInclude(us => us.User)
                .Include(stat => stat.EmployeeStatus)
                .Include(apoint => apoint.Appointment)
                .Include(aset => aset.ASetOfRules)
                .FirstOrDefaultAsync();

            return employee != null ? Result.Success(employee) : Result.Failure<Employee>("Not found");
        }


        // поиск по EMAIL
        public async Task<Result<Employee>> GetByEmail(string email)
        {
            Employee? employee = await dbContext.Employees
                .Where(emp => emp.Email == email)
                .Include(obj => obj.Object)
                .ThenInclude(comp => comp.Company)
                .ThenInclude(us => us.User)
                .Include(stat => stat.EmployeeStatus)
                .Include(apoint => apoint.Appointment)
                .Include(aset => aset.ASetOfRules)
                .FirstOrDefaultAsync();

            return employee != null ? Result.Success(employee) : Result.Failure<Employee>("Not found");
        }


        // получить всех EMPLOYEE
        public async Task<Result<Employee[]>> GetAll()
        {
            return Result.Success(await dbContext.Employees
                .Include(obj => obj.Object)
                .ThenInclude(comp => comp.Company)
                .ThenInclude(us => us.User)
                .Include(stat => stat.EmployeeStatus)
                .Include(apoint => apoint.Appointment)
                .Include(aset => aset.ASetOfRules).ToArrayAsync());
        }


        public async Task<Result<Employee>> Create(Employee employee)
        {
            dbContext.Employees.Add(employee);
            try
            {
                await dbContext.SaveChangesAsync();
                return Result.Success(employee);

            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>(ex.ToString());
            }
        }


        public async Task<Result<Employee>> Update(Employee employee)
        {
            try
            {
                dbContext.Attach(employee);
                await dbContext.SaveChangesAsync();

                return Result.Success(employee);
            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>(ex.Message);
            }
        }


    }
}
