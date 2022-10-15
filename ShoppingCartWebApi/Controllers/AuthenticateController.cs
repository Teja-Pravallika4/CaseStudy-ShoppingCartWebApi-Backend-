using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCartWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ShoppingCartWebApi.Data;
using System.Linq;

namespace ShoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        #region Property  
        /// <summary>  
        /// Property Declaration  
        /// </summary>  
        /// <param name="data"></param>  
        /// <returns></returns>  
        private IConfiguration _config;
        private readonly ShoppingCartDbContext _context;
        #endregion

        #region Contructor Injector  
        /// <summary>  
        /// Constructor Injection to access all methods or simply DI(Dependency Injection)  
        /// </summary>  
        public AuthenticateController(ShoppingCartDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        #endregion


        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public IActionResult Login([FromBody] LoginModel loginmodel)
        {
            try
            {
                //IActionResult response = Unauthorized();
                var user = AuthenticateUser(loginmodel);
                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    // response = Ok(new { Token = tokenString, Message = "Success" });
                    return Ok(new { Token = tokenString, Message = "Success" });
                }

                return NotFound("User not found");

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server error {e.Message}");
            }
            //var tokenString = GenerateJSONWebToken(user);
            //response = Ok(new { Token = tokenString, Message = "Success" });
            //return Ok(tokenString);

        }



        #region GenerateJWT  
        /// <summary>  
        /// Generate Json Web Token Method  
        /// </summary>  
        /// <param name="userInfo"></param>  
        /// <returns></returns>  
        private string GenerateJSONWebToken(UserDetails user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Email,user.EmailId)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

        #region AuthenticateUser  
        /// <summary>  
        /// Hardcoded the User authentication  
        /// </summary>  
        /// <param name="login"></param>  
        /// <returns></returns>  
        private UserDetails AuthenticateUser(LoginModel loginmodel)
        {
            var user = _context.UserDetails.FirstOrDefault(q => q.EmailId == loginmodel.EmailId && q.Password == loginmodel.Password);


            if (user != null)
            {

                //return user;
                return user;
            }
            return null;
        }
        #endregion

        //#region Login Validation  
        ///// <summary>  
        ///// Login Authenticaton using JWT Token Authentication  
        ///// </summary>  
        ///// <param name="data"></param>  
        ///// <returns></returns>  
        //[AllowAnonymous]
        //[HttpPost(nameof(Login))]
        //public IActionResult Login([FromBody] LoginModel data)
        //{
        //    //IActionResult response = Unauthorized();
        //    var user = AuthenticateUser(data);
        //    if (user != null)
        //    {
        //        var tokenString = GenerateJSONWebToken(user);
        //        //response = Ok(new { Token = tokenString, Message = "Success" });
        //        return Ok(tokenString);
        //    }
        //    else {
        //    //return NotFound("User not found")
        //        var tokenString = GenerateJSONWebToken(user);
        //    //response = Ok(new { Token = tokenString, Message = "Success" });
        //    return Ok(tokenString);
        //    }
        //}

        //private object GenerateJSONWebToken(LoginModel user)
        //{
        //    throw new NotImplementedException();
        //}
        //#endregion

        //#region Get  
        ///// <summary>  
        ///// Authorize the Method  
        ///// </summary>  
        ///// <returns></returns>  
        //[HttpGet(nameof(Get))]
        //public async Task<IEnumerable<string>> Get()
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");

        //    return new string[] { accessToken };
        //}


        //#endregion

        //#region JsonProperties  
        ///// <summary>  
        ///// Json Properties  
        ///// </summary>  
        ////public class LoginModel
        ////{
        ////    [Required]
        ////    public string UserName { get; set; }
        ////    [Required]
        ////    public string Password { get; set; }
        ////}
        //#endregion

    }
}