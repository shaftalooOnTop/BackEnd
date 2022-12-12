using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;
using Resturant_managment.Services;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<RestaurantIdentity> _userManager;
        private readonly JwtService _jwtService;
        private readonly RmDbContext _db;
        private readonly RestaurantIdentity _RestaurantUser = null;
        private readonly RoleManager<IdentityRole> _roleManager;
        private RestaurantIdentity RestaurantUser
  
        {
            get
            {
                if (_RestaurantUser == null) return GetUser();
                else return _RestaurantUser;
            }
        }
        public UserController(RoleManager<IdentityRole> roleManager, UserManager<RestaurantIdentity> userManager, JwtService jwtService, RmDbContext db)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _db = db;
            _roleManager = roleManager;

        }
        private RestaurantIdentity GetUser()
        {
            var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            return _userManager.FindByEmailAsync(email).Result;
        }
        [HttpPost("PostUser")]
        [AllowAnonymous]
        public async Task<ActionResult<ReturnData>> PostUser(UserSignUp user)
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
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            var BearerData = await GetBearerToken(
    new UserLogin { Email = user.Email, FullName = user.FullName, Password = user.Password, PhoneNumber = user.PhoneNumber }

    );
            user.Password = null;


            var d = new ReturnData
            {
                Email = user.Email,
                Expiration = BearerData.Expiration,
                FullName = BearerData.FullName,
                PhoneNumber = BearerData.PhoneNumber,
                Password = null,
                Token = BearerData.Token,
                Role = new List<string> { "User" }

            };
            RegisterRole("User");
            return Created("", d);
        }

        [HttpPost("PostRestaurantAdmin")]
        [AllowAnonymous]

        public async Task<ActionResult<ReturnData>> PostRestaurantAdmin(RestaurantAdminSignup user)
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

                    Email = user.Email,
                    FullName = user.FullName,
                    city = city,


                },
                user.Password
            ); ;

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            var BearerData = await GetBearerToken(
    new UserLogin { Email = user.Email, FullName = user.FullName, Password = user.Password }

    );
            user.Password = null;


            var d = new ReturnData
            {
                Email = user.Email,
                Expiration = BearerData.Expiration,
                FullName = BearerData.FullName,
                Password = null,
                Token = BearerData.Token,
                Role= new List<string> { "RestaurantAdmin" }
            };
            RegisterRole("RestaurantAdmin");
            return Created("", d);
        }

        [HttpGet("{emailOrPhoneNumber}")]
        [AllowAnonymous]

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

        private async Task<ReturnData> GetBearerToken(UserLogin userIdentity)
        {
            var user = await _userManager.FindByEmailAsync(userIdentity.Email);

            if (user == null)
            {
                return null;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, userIdentity.Password);

            if (!isPasswordValid)
            {
                return null;

            }

            var token = _jwtService.CreateToken(user);

            var result = new ReturnData
            {
                Email = userIdentity.Email,
                Expiration = token.Expiration,
                FullName = userIdentity.FullName,
                Id = userIdentity.Id,
                Password = null,
                PhoneNumber = userIdentity.PhoneNumber,
                Token = token.Token
            };
            return (result);
        }
        [HttpPost("BearerToken")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(BearerTokenModel request)
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
        public async Task<ActionResult<ReturnData>> UserUpdate(UserSignUp userupdate)
        {
            var upuser = await _userManager.FindByEmailAsync(userupdate.Email);
            if (upuser == null)
                return NotFound();
            upuser.PhoneNumber = userupdate.PhoneNumber;
            upuser.FullName = userupdate.FullName;
            upuser.Picture = userupdate.Picture;
            upuser.Age = userupdate.Age;
            upuser.Gender = userupdate.Gender;
            var u = new UserLogin { Email = upuser.Email, FullName = upuser.FullName, Id = upuser.Id, PhoneNumber = upuser.PhoneNumber, Password = userupdate.Password };
            await _userManager.UpdateAsync(upuser);
            return Ok(GetBearerToken(u));
        }
        [HttpPut("changpass")]
        [Authorize]
        public async Task<ActionResult<UserLogin>> ChangePassword(string newpass)
        {
            var userupdate = _RestaurantUser;
            var upuser = await _userManager.FindByEmailAsync(userupdate.Email);
            if (upuser == null)
            {
                return NotFound();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(upuser);
            var r = await _userManager.ResetPasswordAsync(upuser, token, newpass);

            if (r.Succeeded)
                return Ok(upuser);
            return BadRequest(r.Errors);
        }


        [Authorize]
        [HttpGet("GetUserData")]
        public async Task<ActionResult<RestaurantIdentity>> GetUserData()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound();
            user.PasswordHash = null;
            var IRoles = await _userManager.GetRolesAsync(user);
            var roles = new List<String>(IRoles);
            user.RoleName = roles;
            return user;
        }

        [HttpPost("RegisterRole")]
        [Authorize]
        public async Task<ActionResult> RegisterRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                //create the roles and seed them to the database: Question 2
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (!roleResult.Succeeded) throw new Exception("error");
            }
            var e = await _userManager.AddToRoleAsync(RestaurantUser, roleName);

            if (e.Succeeded)

                return Ok(RestaurantUser);
            return BadRequest(RestaurantUser);
        }

    }
    public class BearerTokenModel
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ReturnData : UserLogin
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
        public List<string> Role { get; set; }
    }
}
