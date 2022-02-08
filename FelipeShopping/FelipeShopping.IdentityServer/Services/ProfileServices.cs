using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using FelipeShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FelipeShopping.IdentityServer.Services
{
    public class ProfileServices : IProfileService
    {
        //Adicionar mais informações no JwtToken
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;

        public ProfileServices(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string id = context.Subject.GetSubjectId();
            var user = await _userManager.FindByNameAsync(id);
            var userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);

            var claims = userClaims.Claims.ToList();
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.UltimoNome));
            claims.Add(new Claim(JwtClaimTypes.GivenName, user.PrimeiroNome));

            if (_userManager.SupportsUserRole)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, role));
                    if (_roleManager.SupportsRoleClaims)
                    {
                        var identityRole = await _roleManager.FindByNameAsync(role);
                        if (identityRole != null)
                            claims.AddRange(await _roleManager.GetClaimsAsync(identityRole));
                    }
                }
            }

            context.IssuedClaims = claims;
            throw new NotImplementedException();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string id = context.Subject.GetSubjectId();
            var user = await _userManager.FindByNameAsync(id);
            context.IsActive = user != null;
        }
    }
}
