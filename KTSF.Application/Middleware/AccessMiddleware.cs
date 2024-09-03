using KTSF.Application.Interfaces.Auth; 
using KTSF.Core.App;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Middleware
{
    public class AccessMiddleware
    {

        private readonly RequestDelegate _next;

        public AccessMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
          
            //var claimGroupSid = context.User.Claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

            

            //Console.WriteLine(context.Request.Path);
 
          /*  if (context.User.IsInRole(Role.Employee))
            {
               // Console.WriteLine("You are employee");
                foreach (Claim claim in context.User.Claims)
                {
                    
                   // Console.WriteLine(claim.Value);
                  
                }
            }
            else if (context.User.IsInRole(Role.User))
            {
              //  Console.WriteLine("You are user");
                foreach (Claim claim in context.User.Claims)
                {

                 //   Console.WriteLine(claim.Value);

                }
            }
            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");

                return;
            }*/

          

           await _next.Invoke(context);
           
        }

    }
}
