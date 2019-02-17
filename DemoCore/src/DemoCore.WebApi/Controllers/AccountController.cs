using System.Threading.Tasks;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Core.Notifications;
using DemoCore.Infra.CrossCutting.Identity.Models;
using DemoCore.Infra.CrossCutting.Identity.Models.AccountViewModels;
using DemoCore.Infra.CrossCutting.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoCore.WebAPI.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger logger;
        private readonly UserService userService;
 
        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            INotificationHandler<DomainNotification> notifications,
            ILoggerFactory loggerFactory,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            logger = loggerFactory.CreateLogger<AccountController>();
            userService = new UserService(userManager, roleManager);

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            if (!result.Succeeded)
                NotifyError(result.ToString(), "Login failure");

            logger.LogInformation(1, "User logged in.");
            return Response(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var claims = userService.GetClientClaims();
                foreach(var claim in claims)
                {
                    await userManager.AddClaimAsync(user, claim);
                }

                var roles = userService.GetClientRoles();
                foreach(var role in roles)
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
                
                await signInManager.SignInAsync(user, false);
                logger.LogInformation(3, "User created a new account with password.");
                return Response(model);
            }

            AddIdentityErrors(result);
            return Response(model);
        }
    }
}