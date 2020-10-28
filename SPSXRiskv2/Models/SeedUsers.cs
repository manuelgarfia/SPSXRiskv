using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SPSXRiskv2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models
{
    public class SeedUsers
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<XRSKDataContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<XRSKUser>>();

            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user = new XRSKUser()
                {
                    Email = "bhaidar@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "bhaidar"
                };

                userManager.CreateAsync(user, "MySp$cialPassw0rd");
            }
        }
    }
}