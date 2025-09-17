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
                new ApiResource("ResourceCargo")
                {
                    Scopes ={ "Cargo.FullPermission", "Cargo.ReadPermission", "Cargo.WritePermission" }
                },
                new ApiResource("ResourceBasket")
                {
                    Scopes ={ "Basket.FullPermission", "Basket.ReadPermission", "Basket.WritePermission" }
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

                new ApiScope("Cargo.FullPermission", "Full access to Cargo API"),
                new ApiScope("Cargo.ReadPermission", "Read access to Cargo API"),
                new ApiScope("Cargo.WritePermission", "Write access to Cargo API"),

                new ApiScope("Basket.FullPermission", "Full access to Basket API"),
                new ApiScope("Basket.ReadPermission", "Read access to Basket API"),
                new ApiScope("Basket.WritePermission", "Write access to Basket API"),

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
                AllowedScopes = { "Catalog.ReadPermission", "Discount.ReadPermission", "Order.ReadPermission", "Order.WritePermission","Cargo.ReadPermission" }
                },

            //manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = { "Catalog.FullPermission","Catalog.WritePermission", "Catalog.ReadPermission", "Discount.FullPermission", "Cargo.FullPermission" }
            },

            //admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = { "Catalog.FullPermission", "Discount.FullPermission", "Order.FullPermission", "Cargo.FullPermission","Basket.FullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }
        };
    }
}