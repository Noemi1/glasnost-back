using glasnost_back.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Controllers
{
    [Route("api/cliente-risco")]
    [ApiController]
    public class Cliente_RiscoComplianceController : ControllerBase
    {
        private readonly ModelDB db;

        public Cliente_RiscoComplianceController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Cliente_RiscoCompliance> Get()
        {
            return db.Cliente_RiscoCompliance
                .OrderBy(c => c.Nome);
        }
    }
}
