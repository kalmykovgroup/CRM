using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using KTSF.Application.Interfaces.Auth;
using KTSF.Core;
using KTSF.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Service
{
    public class UsersService
    {
        public IPasswordHasher passwordHasher;

        private AppDbContext dbContext;

        public UsersService(AppDbContext dbContext, IPasswordHasher passwordHasher)
        {
            this.passwordHasher = passwordHasher;
            this.dbContext = dbContext;
        }

        public void Register(string username, string password)
        {
            var hashedPassword = passwordHasher.Generate(password);
            Result<User> result = new Result<User>();
          
        }

 
        public Result<User> Find(int id)
        {
            User? user = dbContext.Users.Find(id);

            return user != null ? Result.Success(user) : Result.Failure<User>("Not found");
        }

        public Result<User[]> GetAll()
        {
            return Result.Success(dbContext.Users.ToArray());
        }



        public Result<User> Create(User user)
        {
            dbContext.Users.Add(user);
            try
            {
                dbContext.SaveChanges();
                return Result.Success(user);

            }
            catch (Exception ex)
            {
                return Result.Failure<User>(ex.ToString());
            }

        }

        public Result<User> Update(User user)
        {
            try
            {
                dbContext.Attach(user);
                dbContext.SaveChanges();

                return Result.Success(user);
            }
            catch (Exception ex) {
                return Result.Failure<User>(ex.Message);
            }
       
        }

    }
}
