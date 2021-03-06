// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            { 
                new ApiScope("api1", "MyAPI")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client> 
            { 
                new Client{ 
                    ClientId = "client",

                    //no interactive user, use the client/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    //secret for authentication
                    ClientSecrets = { 
                        new Secret("secret".Sha256())
                    },

                    //scopes that client has acess to
                    AllowedScopes = { "api1"}
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:44369/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
                }
            };
    }
}