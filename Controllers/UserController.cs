using glasnost_back.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ModelDB db;

        public UserController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<AspNetUsers> Get()
        {
            return db.AspNetUsers
                .OrderBy(c => c.Name);
        }
    }
}
