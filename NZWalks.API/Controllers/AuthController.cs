
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository.RepositoryInterface;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IRepositoryAuth repositoryAuth;

        public AuthController(UserManager<IdentityUser> userManager,IRepositoryAuth repositoryAuth)
        {
            this.userManager = userManager;
            this.repositoryAuth = repositoryAuth;
        }
        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> register([FromBody] RegisterDTO registerDTO) {

            var user = new IdentityUser {

                UserName = registerDTO.userName,
                Email = registerDTO.userName
            };

            var identityResult = await userManager.CreateAsync(user, registerDTO.password);
            if (identityResult.Succeeded) {
                // Add roles 
                if (registerDTO.roles != null && registerDTO.roles.Any()) {

                     identityResult = await userManager.AddToRolesAsync(user, registerDTO.roles);

                    if (identityResult.Succeeded) return Ok("User was registered! please login");
                }
            }
            return BadRequest("please try again");
        
        }
        [HttpPost]
        [Route("logIn")]
        public async Task<IActionResult> logIn([FromBody] LoginDTO loginDTO) {

            var user = await userManager.FindByEmailAsync(loginDTO.userName);
            if (user != null) {

                var checkPassword = await userManager.CheckPasswordAsync(user, loginDTO.password);
                if (checkPassword)
                {
                    // get roles from usermanger class
                    var roles = await userManager.GetRolesAsync(user);
                    //create token
                    var token = repositoryAuth.createJWTToken(user, roles.ToList());

                    var response = new TokenDTO
                    {
                        resposedToken = token
                    };
                    return Ok(response);
                }
            }
            return BadRequest("Username or password incorrect");
        }
    }
}