using CSharpFunctionalExtensions;
using KTSF.Core;
using KTSF.Core.ABAC;
using KTSF.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KTSF.Application.Service
{
    public class ASetOfRulesService
    {
        private AppDbContext dbContext;

        public ASetOfRulesService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        // создание 
        public async Task<Result<ASetOfRules>> Insert(ASetOfRules setOfRules)
        {
            dbContext.ASetOfRules.Add(setOfRules);
            try
            {
                await dbContext.SaveChangesAsync();
                return Result.Success(setOfRules);
            }
            catch (Exception ex)
            {
                return Result.Failure<ASetOfRules>(ex.ToString());
            }
        }


        // обновление
        public async Task<Result<ASetOfRules>> Update(ASetOfRules setOfRules)
        {
            try
            {
                ASetOfRules? aSetOf = dbContext.ASetOfRules
                    .Where(aset => aset.Id == setOfRules.Id).FirstOrDefault();

                if (aSetOf == null) return Result.Failure<ASetOfRules>("Not found");

                aSetOf.Id = setOfRules.Id;
                aSetOf.Name = setOfRules.Name;
                aSetOf.Description = setOfRules.Description;

                await dbContext.SaveChangesAsync();

                return Result.Success(aSetOf);
            }
            catch (Exception ex)
            {
                return Result.Failure<ASetOfRules>(ex.Message);
            }
        }



        // получение всех 
        public async Task<Result<List<ASetOfRules>>> GetAll()
        {
            return Result.Success(await dbContext.ASetOfRules.ToListAsync());
        }


        // поиск по Id
        public async Task<Result<ASetOfRules>> Find(int id)
        {
            ASetOfRules? appointment = await dbContext.ASetOfRules
                 .Where(emp => emp.Id == id)
                 .FirstOrDefaultAsync();

            return appointment != null ? Result.Success(appointment) : Result.Failure<ASetOfRules>("Not found");
        }


    }
}
