using DemoCore.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DemoCore.Infra.CrossCutting.Identity.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task CreateUser(ApplicationUser user, string password, List<Claim> claims = null, List<IdentityRole> roles = null)
        {
            if (userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = userManager.CreateAsync(user, password).Result;
                if (resultado.Succeeded)
                {
                    if (claims != null)
                    {
                        foreach (var claim in claims)
                        {
                            await userManager.AddClaimAsync(user, claim);
                        }
                    }
                    if (roles != null)
                    {
                        foreach (var role in roles)
                        {
                            await userManager.AddToRoleAsync(user, role.Name);
                        }
                    }

                }
            }
        }

        public async Task CreateRoles(List<IdentityRole> roles)
        {
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }

        public IEnumerable<IdentityRole> GetIdentityRoles(string name)
        {
            if(string.IsNullOrEmpty(name)) return lstRoles;

            return lstRoles.Where(x => x.Name.Equals(name));

        }

        public IEnumerable<Claim> GetClientClaims()
        {
            var types = new string[] { "People" };
            var values = new string[] { "Write", "Read"};
            return GetClaimsFilter(types, values);
        }

        public IEnumerable<Claim> GetManagerClaims()
        {
            var types = new string[] { "People", "BestWorkTime", "Developer", "Designer", "WorkAvailability" };
            var values = new string[] { "Write", "Read"};
            return GetClaimsFilter(types, values);
        }

        public IEnumerable<Claim> GetAdminMasterClaims()
        {
            var types = new string[] { "People", "BestWorkTime", "Developer", "Designer", "WorkAvailability" };
            var values = new string[] { "Write", "Read", "Delete" };
            return GetClaimsFilter(types, values);
        }

        public IEnumerable<IdentityRole> GetClientRoles()
        {
            return new List<IdentityRole>
            {
                new IdentityRole("Client")
            };
        }

        public IEnumerable<IdentityRole> GetManagerRoles()
        {
            return new List<IdentityRole>
            {
                new IdentityRole("Manager")
            };
        }

        public IEnumerable<IdentityRole> GetAdminMasterRoles()
        {
            return lstRoles;
        }

        private IEnumerable<Claim> GetClaimsFilter(string[] nameFilter, string[] valueFilter)
        {
            var lstClaims = new List<Claim>();

            if (nameFilter == null && valueFilter == null) return null;

            if (nameFilter != null && valueFilter != null)
            {
                foreach (var type in nameFilter)
                {
                    foreach (var value in valueFilter)
                    {
                        var claim = lstAllClaims.Where(x => x.Type.Equals(type) && x.Value.Equals(value));
                        lstClaims.AddRange(claim);
                    }
                }
            }
            else if (nameFilter != null)
            {
                foreach (var type in nameFilter)
                {
                    lstClaims.AddRange(lstAllClaims.Where(x => x.Type.Equals(valueFilter)));
                }
            }
            else
            {
                lstClaims.AddRange(lstAllClaims.Where(x => x.Value.Equals(valueFilter)));
            }
            return lstClaims;
        }

        private readonly IEnumerable<IdentityRole> lstRoles = new List<IdentityRole>
        {
            new IdentityRole("Admin"),
            new IdentityRole("Manager"),
            new IdentityRole("Client"),
        };

        private readonly IEnumerable<Claim> lstAllClaims = new List<Claim>
        {
            new Claim("BestWorkTime","Write"),
            new Claim("BestWorkTime","Read"),
            new Claim("BestWorkTime","Delete"),

            new Claim("Developer","Write"),
            new Claim("Developer","Read"),
            new Claim("Developer","Delete"),

            new Claim("Designer", "Write"),
            new Claim("Designer", "Read"),
            new Claim("Designer", "Delete"),

            new Claim("WorkAvailability", "Write"),
            new Claim("WorkAvailability", "Read"),
            new Claim("WorkAvailability", "Delete"),

            new Claim("People", "Write"),            
            new Claim("People", "Read"),
            new Claim("People", "Delete"),

        };
    }
}
