using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Auth.Server
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserStore<ApplicationUser> _userStore;

        public ResourceOwnerPasswordValidator(UserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager)
        {
            _userStore = userStore;
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            Console.WriteLine("Checking username/password");

            var user = await _userStore.FindByNameAsync(context.UserName, CancellationToken.None);
            if (user != null && await _userManager.CheckPasswordAsync(user, context.Password))
            {
                context.Result = new GrantValidationResult(
                    subject: user.Id,
                    authenticationMethod: context.Request.GrantType,
                    claims: user.Claims.Select(c=>new Claim(c.ClaimType, c.ClaimValue)));
            }
            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                "invalid custom credential");

        }
    }
}