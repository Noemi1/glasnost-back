using glasnost_back.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly ModelDB db;

        public PessoaController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return db.Pessoa
                .OrderBy(c => c.Nome);
        }
    }
}
