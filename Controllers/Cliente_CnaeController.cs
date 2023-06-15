using glasnost_back.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace glasnost_back.Controllers
{
    [Route("api/cnae")]
    [ApiController]
    public class Cliente_CnaeController : ControllerBase
    {
        private readonly ModelDB db;

        public Cliente_CnaeController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Cliente_Cnae> Get()
        {

            return db.Cliente_Cnae
                .OrderBy(c => c.Codigo);
        }


    }
}
