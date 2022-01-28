using Microsoft.AspNetCore.Identity;

namespace FelipeShopping.IdentityServer.Model.Context
{
    public class ApplicationUser : IdentityUser
    {
        private string? PrimeiroNome { get; set; }
        private string? UltimoNome { get; set; }

    }
}
