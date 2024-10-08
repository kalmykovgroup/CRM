﻿using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using KTSF.Application.Interfaces.Auth;
using KTSF.Core;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore; 

namespace KTSF.Application.Service
{
    public class UsersService
    {
      
        public IPasswordHasher passwordHasher;

        private ObjectDbContext dbContext;

        public UsersService(ObjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<User>> Find(int id)
        {
            User? user = await dbContext.Users.FindAsync(id);

            return user != null ? Result.Success(user) : Result.Failure<User>("Not found");
        }


        // поиск по EMAIL
        public async Task<Result<User>> GetByEmail(string email)
        {
            User? user = await dbContext.Users.Where(user => user.Email == email).FirstOrDefaultAsync();

            return user != null ? Result.Success(user) : Result.Failure<User>("Not found");
        }

        
        // получить всех USER
        public async Task<Result<User[]>> GetAll()
        {     
            return Result.Success(await dbContext.Users.ToArrayAsync());
        }


        public async Task<Result<User>> Create(User user)
        {
            User us = new User();

            us.Id = user.Id;
            us.Email = user.Email;
            us.PhoneNumber = user.PhoneNumber;
            us.PasswordHash = user.PasswordHash;
            us.AccessToken = user.AccessToken;
            us.Name = user.Name;
            us.Surname = user.Surname;
            us.Patronymic = user.Patronymic;

            dbContext.Users.Add(us);
            try
            {
                await dbContext.SaveChangesAsync();
                return Result.Success(us);

            }
            catch (Exception ex)
            {
                return Result.Failure<User>(ex.ToString());
            }
        }


        public async Task<Result<User>> Update(User user)
        {
            try
            {
                User? us = await dbContext.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();

                if (us == null) return Result.Failure<User>("Not found");

                us.Id = user.Id;
                us.Email = user.Email;
                us.PhoneNumber = user.PhoneNumber;
                us.PasswordHash = user.PasswordHash;
                us.JwtToken = user.JwtToken;
                us.Name = user.Name;
                us.Surname = user.Surname;
                us.Patronymic = user.Patronymic;

                await dbContext.SaveChangesAsync();

                return Result.Success(user);
            }
            catch (Exception ex) {
                return Result.Failure<User>(ex.Message);
            }       
        }

    }
}
