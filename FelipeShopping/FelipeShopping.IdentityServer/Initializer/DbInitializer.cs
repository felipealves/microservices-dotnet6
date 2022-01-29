using FelipeShopping.IdentityServer.Configuration;
using FelipeShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FelipeShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySQLContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySQLContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null)
                return;

            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();

            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Cliente)).GetAwaiter().GetResult();

            //Config Admin
            ApplicationUser admin = new ApplicationUser
            {
                UserName = "felipe-admin",
                Email = "felipe-admin@shopping.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 1234-54321",
                PrimeiroNome = "Felipe",
                UltimoNome = "Admin"
            };

            _user.CreateAsync(admin, "Felipe$123").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{admin.PrimeiroNome} {admin.UltimoNome}"),
                    new Claim(JwtClaimTypes.GivenName, admin.PrimeiroNome),
                    new Claim(JwtClaimTypes.FamilyName, admin.UltimoNome),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
                }).Result;

            //Config Cliente
            ApplicationUser cliente = new ApplicationUser
            {
                UserName = "felipe-cliente",
                Email = "felipe-cliente@shopping.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 1234-54321",
                PrimeiroNome = "Felipe",
                UltimoNome = "Cliente"
            };

            _user.CreateAsync(cliente, "Felipe$123").GetAwaiter().GetResult();
            _user.AddToRoleAsync(cliente, IdentityConfiguration.Cliente).GetAwaiter().GetResult();

            var clienteClaims = _user.AddClaimsAsync(cliente, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{admin.PrimeiroNome} {admin.UltimoNome}"),
                    new Claim(JwtClaimTypes.GivenName, admin.PrimeiroNome),
                    new Claim(JwtClaimTypes.FamilyName, admin.UltimoNome),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Cliente)
                }).Result;
        }
    }
}
