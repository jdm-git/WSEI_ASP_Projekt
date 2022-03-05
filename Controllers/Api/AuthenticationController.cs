using System.Linq;
using System.Threading.Tasks;
using LibApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signIn;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
        {
            _userManager = userManager;
            _signIn = signIn;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserRole()
        {
            var user = GetLoggedInUser();
            await _userManager.AddToRoleAsync(user, RolesConstants.User);
            return Ok("logout and login again for changes to be applied");
        }

        [HttpGet("storeManager")]
        public async Task<IActionResult> GetStoreManagerRole()
        {
            var user = GetLoggedInUser();
            await _userManager.AddToRoleAsync(user, RolesConstants.StoreManager);
            return Ok("logout and login again for changes to be applied");
        }

        [HttpGet("owner")]
        public async Task<IActionResult> GetOwnerRole()
        {
            var user = GetLoggedInUser();
            await _userManager.AddToRoleAsync(user, RolesConstants.Owner);
            return Ok("logout and login again for changes to be applied");
        }

        private IdentityUser GetLoggedInUser()
        {
            return _signIn.UserManager.Users.First(x => x.UserName == _signIn.Context.User.Identity.Name);
        }
    }
}
