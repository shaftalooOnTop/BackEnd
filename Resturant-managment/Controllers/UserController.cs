using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_managment.Models;
using Resturant_managment.Services;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private IConfiguration _conf;
        private readonly UserManager<RestaurantIdentity> _userManager;
        private readonly JwtService _jwtService;

        public UserController(IConfiguration conf,UserManager<RestaurantIdentity> userManager,JwtService jwtService)
        {
            _conf = conf;
            _userManager = userManager;
            _jwtService = jwtService;
        }
        [HttpPost("PostUser")]
        public async Task<ActionResult<UserLogin>> PostUser(UserLogin user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                
                new RestaurantIdentity
                {
                    UserName= Guid.NewGuid().ToString(),
                    PhoneNumber= user.PhoneNumber,
                    Email = user.Email,
                    FullName = user.FullName
                },
                user.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.Password = null;
            return Created("", user);
        }
        [HttpGet("{emailOrPhoneNumber}")]
        public async Task<ActionResult<UserLogin>> GetUser(string emailOrPhoneNumber)
        {
            IdentityUser user = await _userManager.Users.FirstOrDefaultAsync(x=>x.Email==emailOrPhoneNumber||x.PhoneNumber==emailOrPhoneNumber);

            if (user == null)
            {
                return NotFound();
            }

            return new UserLogin()
            {
                Email = user.Email
            };
        }
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(UserLogin request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.Users.SingleOrDefaultAsync(x=>x.Email==request.Email||x.PhoneNumber==request.PhoneNumber);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtService.CreateToken(user);
            
            return Ok(token);
        }
    }
}
