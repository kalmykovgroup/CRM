using KTSF.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Service
{
    public class AuthMiddleware
    {
        RequestDelegate next; 


        public AuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {            
            await next.Invoke(httpContext); //Отработали все Middleware

            //Итоговый ответ
        }
    }
}
