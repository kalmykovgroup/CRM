 
using KTSF.Persistence.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Persistence.Configurations
{
    public static class ClaimsExtensions
    {
        public const string companyId = "company_id";
        public const string objectId = "object_id";
        public const string userId = "user_id";
        public const string employeeId = "employee_id";



        public static int? GetUserId(this IEnumerable<Claim> claims)
        {
            string? _id = claims.Where(claim => claim.Type == userId).FirstOrDefault()?.Value;

            return _id != null ? int.Parse(_id) : null;
        }

        public static int? GetCompanyId(this IEnumerable<Claim> claims)
        {
            string? _id = claims.Where(claim => claim.Type == companyId).FirstOrDefault()?.Value;

            return _id != null ? int.Parse(_id) : null;
        }

        public static int? GetEmployeeId(this IEnumerable<Claim> claims)
        {
            string? _id = claims.Where(claim => claim.Type == employeeId).FirstOrDefault()?.Value;

            return _id != null ? int.Parse(_id) : null;
        }

        public static int? GetObjectId(this IEnumerable<Claim> claims)
        {
            string? _id = claims.Where(claim => claim.Type == objectId).FirstOrDefault()?.Value;

            return _id != null ? int.Parse(_id) : null;
        }

        public static string? GetRole(this IEnumerable<Claim> claims)
        {
            return claims.Where(claim => claim.Type == ClaimsIdentity.DefaultRoleClaimType).FirstOrDefault()?.Value;

        }
    }
}
