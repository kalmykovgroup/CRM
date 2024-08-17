using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Persistence.Configurations
{
    public class JwtOptions
    {
        public static string ISSUER { get; } = "MyAuthServer"; // издатель токена

        public static string AUDIENCE  { get; }  = "MyAuthClient"; // потребитель токена

        private static string KEY  { get; }  = "pvsrSWWWVSNYBkZE6b399BEnwHwiX1iM";   // ключ для шифрации (SecurityAlgorithms.HmacSha256 - необходим ключ длиной не менее 256 бит или 32 байта)

        public static TimeSpan LIFETIME { get; } = TimeSpan.FromHours(14); // время жизни токена - 14 часов

        //возвращает ключ безопасности, который применяется для генерации токена
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
