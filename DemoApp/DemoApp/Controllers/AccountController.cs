using DemoApp.Cache;
using DemoApp.Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;
using System.Security.Claims;

namespace DemoApp.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("api/account/register")]
        [AllowAnonymous]
        public  Response Post([FromBody]User user)
        {

            if (!ModelState.IsValid)
            {
                return new Response { Sucsses = false , Error="Request Error"};
            }
            if (user.UserName == null)
            {
                return new Response { Sucsses = false, Error = "User Name cannot be Empty" };
            }
            if (user.Email == null)
            {
                return new Response { Sucsses = false, Error = "Email cannot be Empty" };
            }
            if (user.Password == null)
            {
                return new Response { Sucsses = false, Error = "Password cannot be Empty" };
            }

            if (UserCache.getInstance().getByUserName(user.UserName) == null)
            {
                UserCache.getInstance().addUser(user);
                return new Response { Sucsses = true};

            }
            else
            {
                return new Response { Sucsses = false, Error = "User Already Exist" };
            }

        }

        [HttpGet]
        [Route("api/account/login")]
        public User loginDetails()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            User model = new User()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }
    }
}
