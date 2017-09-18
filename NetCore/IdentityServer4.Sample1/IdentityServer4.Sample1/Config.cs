// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer4.Sample1
{
    public class Config
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "web",
                    DisplayName = "Web API",
                    UserClaims =
                    {
                        "name",
                        ClaimTypes.Name,
                        ClaimTypes.Email
                    },
                    Scopes =
                    {
                        new Scope()
                        {
                            Name = "web.full_access",
                            DisplayName = "Full access to Web API",
                        },
                        new Scope
                        {
                            Name = "web.read_only",
                            DisplayName = "Read only access to Web API"
                        }
                    }
                }
            };
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "webapp",
                     ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "custom.profile",
                        "web",
                        "web.read_only"
                    }

                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new List<Claim>()
                    {
                        new Claim("name", "1"),
                        new Claim(System.Security.Claims.ClaimTypes.Name, "alice"),
                        new Claim(System.Security.Claims.ClaimTypes.Email, "alice@domain.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims = new List<Claim>()
                    {
                        new Claim("name", "2"),
                        new Claim(System.Security.Claims.ClaimTypes.Name, "bob"),
                        new Claim(System.Security.Claims.ClaimTypes.Email, "bob@domain.com")
                    }
                }
            };
        }
    }
}