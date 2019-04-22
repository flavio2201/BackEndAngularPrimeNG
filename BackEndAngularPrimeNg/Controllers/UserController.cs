using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackEndAngularPrimeNg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : APIController
    {

        public UserController(IConfiguration configuration) : base(configuration)
        {
        }

        [HttpPost]
        [HttpPut]
        public IActionResult Save([FromBody] User user)
        {
            using (var business = new UserBusiness(Configuration))
            {
                business.Save(user);
                return new OkResult();
            }

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            using (var business = new UserBusiness(Configuration))
            {
                return new JsonResult(business.GetAll());
            }
        }
    }
}