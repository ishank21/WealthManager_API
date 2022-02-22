using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationInfrastructure.JWT
{
    public class Keys
    {
        private static IConfigurationSection _configuration;
        public static void Configure(IConfigurationSection configuration)
        {
            _configuration = configuration;
        }

        public static string WebSiteDomain => _configuration["WebSiteDomain"];
        public static string Token => _configuration["Secret"];
    }
}
