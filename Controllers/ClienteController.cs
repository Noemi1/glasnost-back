using glasnost_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace glasnost_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ModelDB db;

        public ClienteController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {

            return db.Cliente
                .AsNoTracking()
                .OrderBy(c => c.Nome);
        }


    }
}
