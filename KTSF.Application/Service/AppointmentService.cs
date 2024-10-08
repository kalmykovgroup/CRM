﻿using CSharpFunctionalExtensions;
 
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
    public class AppointmentService
    {
        private ObjectDbContext dbContext;

        public AppointmentService(ObjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        // создание 
        public async Task<Result<Appointment>> Insert(Appointment appointment)
        {
            Appointment app = new Appointment();

            app.Id = appointment.Id;
            app.Name = appointment.Name;
            app.Description = appointment.Description;

            dbContext.Appointments.Add(app);

            try
            {
                await dbContext.SaveChangesAsync();
                return Result.Success(app);
            }
            catch (Exception ex)
            {
                return Result.Failure<Appointment>(ex.ToString());
            }
        }


        // обновление
        public async Task<Result<Appointment>> Update(Appointment appointment)
        {
            try
            {
                Appointment? app = dbContext.Appointments.Where(ap => ap.Id == appointment.Id).FirstOrDefault();

                if (app == null) return Result.Failure<Appointment>("Not found");

                app.Id = appointment.Id;
                app.Name = appointment.Name;
                app.Description = appointment.Description;

                await dbContext.SaveChangesAsync();

                return Result.Success(app);
            }
            catch (Exception ex)
            {
                return Result.Failure<Appointment>(ex.Message);
            }
        }



        // получение всех 
        public async Task<Result<List<Appointment>>> GetAll()
        {
            return Result.Success(await dbContext.Appointments.ToListAsync());
        }


        // поиск по Id
        public async Task<Result<Appointment>> Find(int id)
        {
            Appointment? appointment = await dbContext.Appointments
                 .Where(prod => prod.Id == id)
                 .FirstOrDefaultAsync();

            return appointment != null ? Result.Success(appointment) : Result.Failure<Appointment>("Not found");    
        }




    }
}
