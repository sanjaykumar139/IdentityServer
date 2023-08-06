﻿using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Configs
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("myresourceapi", "My Resource API")
                //{
                //    Scopes = {new Scope("apiscope")}
                //}
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // for public api
                new Client
                {
                    ClientId = "secret_client_id",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new IdentityServer4.Models.Secret("secret".Sha256())
                    },
                    AllowedScopes = { "apiscope" }
                }
            };
        }
    }
}
