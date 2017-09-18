using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer4.Sample1
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            bool isAuthenticated = context.UserName.Equals("sercan", StringComparison.CurrentCultureIgnoreCase) && context.Password.Equals("akmaz", StringComparison.CurrentCultureIgnoreCase);

            if (isAuthenticated)
            {
                context.Result = new GrantValidationResult("1", OidcConstants.AuthenticationMethods.Password, claims: new List<Claim> { new Claim("name", "1") });
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
            }

            return Task.CompletedTask;
        }
    }
}
