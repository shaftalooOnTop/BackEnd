using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.Scripting;
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
        private readonly RmDbContext _db;

        public UserController(IConfiguration conf, UserManager<RestaurantIdentity> userManager, JwtService jwtService, RmDbContext db)
        {
            _conf = conf;
            _userManager = userManager;
            _jwtService = jwtService;
            _db = db;
        }
        [HttpPost("PostUser")]
        public async Task<ActionResult<UserLogin>> PostUser(UserSignUp user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var city = _db.Cities.FirstOrDefault(x => x.CityName == user.city);
            if (city == null)
            {
                var city1 = new City { CityName = user.city };
                _db.Cities.Add(city1);
                _db.SaveChanges();
            }
            var result = await _userManager.CreateAsync(

                new RestaurantIdentity
                {
                    UserName = Guid.NewGuid().ToString(),
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    FullName = user.FullName,
                    city = city,
                    Age = user.Age,
                    Gender = user.Gender,
                    Picture = user.Picture

                },
                user.Password
            ); ;

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.Password = null;
            return Created("", user);
        }
        [HttpGet("{emailOrPhoneNumber}")]
        //[Authorize]
        public async Task<ActionResult<UserLogin>> GetUser(string emailOrPhoneNumber)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(emailOrPhoneNumber);
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
        //[Authorize]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(UserLogin request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

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
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<AuthenticationResponse>> UserUpdate(UserSignUp userupdate)
        {
            var upuser = await _userManager.FindByEmailAsync(userupdate.Email);
            if (upuser == null)
            {
                return NotFound();
            }
            //          "email": "w@e.k",
            //"phoneNumber": "091",
            //"fullName": "ahmad",
            //"picture": "pic",
            //"age": 20,
            //"gender": "jhkgv"
            upuser.Email = userupdate.Email;
            upuser.PhoneNumber = userupdate.PhoneNumber;
            upuser.FullName = userupdate.FullName;
            upuser.Picture = userupdate.Picture;
            upuser.Age = userupdate.Age;
            upuser.Gender = userupdate.Gender;
            _userManager.UpdateAsync(upuser);
            return Ok();
        }
        [HttpPut("changpass")]
        [Authorize]
        public async Task<ActionResult<UserLogin>> ChangePasswoerd(UserLogin userupdate,  string newpass)
        {
            var upuser = await _userManager.FindByEmailAsync(userupdate.Email);
            if (upuser == null)
            {
                return NotFound();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(upuser);
            var r = await _userManager.ResetPasswordAsync(upuser, token, newpass);
            _userManager.UpdateAsync(upuser);
            _db.Update(upuser);
            _db.SaveChanges();
            return Ok();
        }
        [Authorize]
        [HttpGet("GetUserData")]
        public async Task<ActionResult<RestaurantIdentity>> GetUserData()
        {

            var email = User.FindFirst("sub")?.Value;
            var user=await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound();
            return user;
        }
    }
}
