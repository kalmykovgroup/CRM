using CSharpFunctionalExtensions;
using KTSF.Core.App;
using KTSF.Core.Object;
using KTSF.Dto.Employee_;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Object = KTSF.Core.Object;

namespace KTSF.Application.Service
{
    public class EmployeesService
    {
        public ObjectDbContext dbContext;        

        public EmployeesService(ObjectDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }


        // поиск по ID
        public async Task<Result<Employee>> Find(int id)
        {
            Employee? employee = await dbContext.Employees
                .Where(emp => emp.Id == id)   
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
                .Include(stat => stat.EmployeeStatus)
                .Include(apoint => apoint.Appointment)
                .Include(aset => aset.ASetOfRules)
                .FirstOrDefaultAsync();

            return employee != null ? Result.Success(employee) : Result.Failure<Employee>("Not found");
        }


        // поиск по ФАМИЛИИ или ИМЕНИ
        public async Task<Result<List<Employee>>> GetBySurname(string name)
        {
            List<Employee> employees = await dbContext.Employees.ToListAsync();

            List<Employee> resultSurname = [];
            List<Employee> resultName = [];

            foreach (Employee employee in employees)
            {
                if (employee.Surname.ToLower().Contains(name.ToLower()))
                {
                    resultSurname.Add(employee);
                }

                if (employee.Name.ToLower().Contains(name.ToLower()))
                {
                    resultName.Add(employee);
                }
            }

            if (resultSurname.Count > 0)
            {
                return Result.Success(resultSurname);
            }
            else if (resultName.Count > 0)
            {
                return Result.Success(resultName);
            }
            else return Result.Failure<List<Employee>>("Not found");
        }


        // получить всех EMPLOYEE
        public async Task<Result<Employee[]>> GetAll()
        {
            return Result.Success(await dbContext.Employees  
                .Include(stat => stat.EmployeeStatus)
                .Include(apoint => apoint.Appointment)
                .Include(aset => aset.ASetOfRules).ToArrayAsync());
        }


        public async Task<Result<Employee>> Create(Employee employee)
        {
            Employee empl = new Employee();

            empl.Id = employee.Id;
            empl.ObjectId = employee.ObjectId;
            empl.AccessToken = employee.AccessToken;
            empl.AppointmentId = employee.AppointmentId;
            empl.Name = employee.Name;
            empl.Surname = employee.Surname;
            empl.Patronymic = employee.Patronymic;
            empl.PassportSeries = employee.PassportSeries;
            empl.PassportNumber = employee.PassportNumber;
            empl.Tin = employee.Tin;
            empl.Snils = employee.Snils;
            empl.Address = employee.Address;
            empl.Phone = employee.Phone;
            empl.Email = employee.Email;
            empl.ApplyingDate = employee.ApplyingDate;
            empl.LayoffDate = employee.LayoffDate;
            empl.Created_At = employee.Created_At;
            empl.Updated_At = employee.Updated_At;
            empl.Password = employee.Password;
            empl.EmployeeStatusId = employee.EmployeeStatusId;
            empl.ASetOfRulesId = employee.ASetOfRulesId;

            dbContext.Employees.Add(empl);

            try
            {
                await dbContext.SaveChangesAsync();                
                return Result.Success(empl);
            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>(ex.ToString());
            }
        }


        public async Task<Result<Employee>> Update(Employee employee)
        {

            await Console.Out.WriteLineAsync(employee.LayoffDate.ToString());
            try
            {
                Employee? empl = dbContext.Employees.Where(emp => emp.Id == employee.Id).FirstOrDefault();

                if (empl == null) return Result.Failure<Employee>("Not found");              

                empl.Id = employee.Id;           
                empl.JwtToken = employee.JwtToken;
                empl.AppointmentId = employee.AppointmentId;   
                empl.Name = employee.Name;
                empl.Surname = employee.Surname;
                empl.Patronymic = employee.Patronymic;
                empl.PassportSeries = employee.PassportSeries;
                empl.PassportNumber = employee.PassportNumber;
                empl.Tin = employee.Tin;
                empl.Snils = employee.Snils;
                empl.Address = employee.Address;
                empl.Phone = employee.Phone;
                empl.Email = employee.Email;
                empl.ApplyingDate = employee.ApplyingDate;
                empl.LayoffDate = employee.LayoffDate;
                empl.Created_At = employee.Created_At;
                empl.Updated_At = employee.Updated_At;
                empl.Password = employee.Password;
                empl.EmployeeStatusId = employee.EmployeeStatusId;

                await Console.Out.WriteLineAsync(empl.LayoffDate.ToString());

                await dbContext.SaveChangesAsync();               

                return Result.Success(empl);
            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>(ex.Message);
            }
        }
 

    }
}
