// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
                   };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("ResourceCatolog")
                {
                    Scopes = { "Catalog.FullPermission", "Catalog.ReadPermission", "Catalog.WritePermission" }
                },
                new ApiResource("ResourceDiscount")
                {
                    Scopes = { "Discount.FullPermission", "Discount.ReadPermission", "Discount.WritePermission" }
                },
                new ApiResource("ResourceOrder")
                {
                    Scopes = { "Order.FullPermission", "Order.ReadPermission", "Order.WritePermission" }
                },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Catalog.FullPermission", "Full access to Catalog API"),
                new ApiScope("Catalog.ReadPermission", "Read access to Catalog API"),
                new ApiScope("Catalog.WritePermission", "Write access to Catalog API"),

                new ApiScope("Discount.FullPermission", "Full access to Discount API"),
                new ApiScope("Discount.ReadPermission", "Read access to Discount API"),
                new ApiScope("Discount.WritePermission", "Write access to Discount API"),

                new ApiScope("Order.FullPermission", "Full access to Order API"),
                new ApiScope("Order.ReadPermission", "Read access to Order API"),
                new ApiScope("Order.WritePermission", "Write access to Order API"),

                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients => new Client[] {
            //visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "MultiShop Visitor User",
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "Catalog.ReadPermission", "Discount.ReadPermission", "Order.ReadPermission", "Order.WritePermission" }
                },
            //manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "Catalog.FullPermission","Catalog.WritePermission", "Catalog.ReadPermission", "Discount.FullPermission" }
            },

            //admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "Catalog.FullPermission", "Discount.FullPermission", "Order.FullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }
        };

        //public static IEnumerable<IdentityResource> IdentityResources =>
        //           new IdentityResource[]
        //           {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //           };

        //public static IEnumerable<ApiScope> ApiScopes =>
        //    new ApiScope[]
        //    {
        //        new ApiScope("scope1"),
        //        new ApiScope("scope2"),
        //    };

        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //        // m2m client credentials flow client
        //        new Client
        //        {
        //            ClientId = "m2m.client",
        //            ClientName = "Client Credentials Client",

        //            AllowedGrantTypes = GrantTypes.ClientCredentials,
        //            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

        //            AllowedScopes = { "scope1" }
        //        },

        //        // interactive client using code flow + pkce
        //        new Client
        //        {
        //            ClientId = "interactive",
        //            ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

        //            AllowedGrantTypes = GrantTypes.Code,

        //            RedirectUris = { "https://localhost:44300/signin-oidc" },
        //            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
        //            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

        //            AllowOfflineAccess = true,
        //            AllowedScopes = { "openid", "profile", "scope2" }
        //        },
        //    };
    }
}