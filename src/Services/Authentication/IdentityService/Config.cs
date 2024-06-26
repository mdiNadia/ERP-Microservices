﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {

            //new ApiScope("identityapi", "Identity Web Api"),
            //new ApiScope( IdentityServerConstants.StandardScopes.OfflineAccess, "Offline Access"),
            //new ApiScope("scope1"),
            new ApiScope("CRMApi","CRM Api"),
        };
     
    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "CRMClient",
                    AllowOfflineAccess = true,
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = new List<Secret> {
                    new Secret("7e2aadac-5d17-4da4-b662-0d13387fcb2b".Sha256())
                },
                AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "CRMApi" },

                AccessTokenLifetime = 30*24*60*60,
                IdentityTokenLifetime = 30*24*60*60
            }
            //    new Client
            //{
            //    ClientId = "identityapiClient",
            //    AllowOfflineAccess = true,
            //    AlwaysSendClientClaims = true,
            //    AlwaysIncludeUserClaimsInIdToken = true,
            //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            //    ClientSecrets = new List<Secret> {
            //        new Secret("7e2aadac-5d17-4da4-b662-0d13387fcb2b".Sha256())
            //    },
            //    AllowedScopes = {
            //            IdentityServerConstants.StandardScopes.OpenId,
            //            IdentityServerConstants.StandardScopes.OfflineAccess,
            //            "identityapi" },

            //    AccessTokenLifetime = 30*24*60*60,
            //    IdentityTokenLifetime = 30*24*60*60
            //},
            //// m2m client credentials flow client
            //new Client
            //{
            //    ClientId = "m2m.client",
            //    ClientName = "Client Credentials Client",

            //    AllowedGrantTypes = GrantTypes.ClientCredentials,
            //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

            //    AllowedScopes = { "scope1" }
            //},

            //// interactive client using code flow + pkce
            //new Client
            //{
            //    ClientId = "interactive",
            //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

            //    AllowedGrantTypes = GrantTypes.Code,

            //    RedirectUris = { "https://localhost:44300/signin-oidc" },
            //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
            //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

            //    AllowOfflineAccess = true,
            //    AllowedScopes = { "openid", "profile", "scope2" }
            //},
        };
}
