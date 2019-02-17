using DemoCore.Infra.CrossCutting.Identity.Data;
using DemoCore.Infra.CrossCutting.Identity.Models;
using DemoCore.Infra.CrossCutting.Identity.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DemoCore.Infra.CrossCutting.Identity.Migrations
{
    public class IdentityDbInitializer
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserService userService;

        public IdentityDbInitializer(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            userService = new UserService(userManager, roleManager);
        }

        public void Seed()
        {
            var lstRoles = userService.GetAdminMasterRoles().ToList();

            if (!context.Users.Any())
            {
                var lstClaims = userService.GetAdminMasterClaims().ToList();
                var user = new ApplicationUser()
                {
                    UserName = "hugo@sharpnet.com.br",
                    Email = "hugo@sharpnet.com.br",
                    EmailConfirmed = true
                };

                
                userService.CreateUser(user, "@Sharpnet01", lstClaims, lstRoles).Wait();
            }

            if (!context.Roles.Any())
            {
                userService.CreateRoles(lstRoles).Wait();
            }

        }
    }

}
