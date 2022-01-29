using Microsoft.AspNetCore.Identity;

namespace FelipeShopping.IdentityServer.Model.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string? PrimeiroNome { get; set; }
        public string? UltimoNome { get; set; }

    }
}
