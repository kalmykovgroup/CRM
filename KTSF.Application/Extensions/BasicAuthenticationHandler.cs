using CSharpFunctionalExtensions;
using KTSF.Application.Service;
 
using KTSF.Core.App;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace KTSF.Application.Extensions
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        // UserManager<IdentityUser> _userManager;

        private AuthService _authService;

        public BasicAuthenticationHandler(
         IOptionsMonitor<AuthenticationSchemeOptions> options,
         ILoggerFactory logger,
         UrlEncoder encoder,
         TimeProvider timeProvider, AuthService authService) : base(options, logger, encoder)
        {
            _authService = authService;
        }


        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] attribute
            var endpoint = Context.GetEndpoint();

            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                return AuthenticateResult.NoResult();

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            Result<User> result;
            try
            {
                AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                if (authHeader == null) return AuthenticateResult.Fail("Invalid Authorization Header");
                if (authHeader.Parameter is null) return AuthenticateResult.Fail("Invalid Authorization Parameter");

                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                result = await _authService.Login(new Dto.Auth.LoginUserRequest(username, password));
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (result.IsFailure)
                return AuthenticateResult.Fail("Invalid Username or Password");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, result.Value.Id.ToString()),
                new Claim(ClaimTypes.Name, result.Value.Email ?? result.Value.PhoneNumber),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
