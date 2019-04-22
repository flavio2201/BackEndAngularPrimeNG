using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAngularPrimeNg.Controllers
{
    public class APIController
    {

        protected IConfiguration Configuration { get; set; }

        public APIController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
    }
}
