﻿using glasnost_back.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace glasnost_back.Controllers
{
    [Route("api/cliente-tipo")]
    [ApiController]
    public class Cliente_TipoController : ControllerBase
    {
        private readonly ModelDB db;

        public Cliente_TipoController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Cliente_Tipo> Get()
        {
            return db.Cliente_Tipo
                .OrderBy(c => c.Nome);
        }

    }
}
