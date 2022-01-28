﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace FelipeShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Cliente = "Cliente";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("felipe_shopping", "FelipeShopping Server"),
                new ApiScope(name: "read", "Read data"),
                new ApiScope(name: "write", "Write data"),
                new ApiScope(name: "delete", "Delete data")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("my_scret_complexity_123_TYPE".Sha256()) }, //Pode e deve ficar no appsettings
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read","write","delete"}
                },
                new Client
                {
                    ClientId = "felipe_shoppping",
                    ClientSecrets = { new Secret("my_scret_complexity_123_TYPE".Sha256()) }, //Pode e deve ficar no appsettings
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"http://localhost:28870/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:28870/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "felipe_shoppping"
                    }
                }
            };
    }
}