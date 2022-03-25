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
                .OrderBy(c => c.Nome);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente([FromRoute] int id)
        {
            try
            {
                Cliente cliente = await db.Cliente
                .AsNoTracking()
                .Include(x => x.Cliente_Cnae_Rel)
                .Include(x => x.Cliente_Responsavel)
                .Include(x => x.Cliente_Tipo)
                .Include(x => x.Cliente_RiscoCompliance)
                .FirstOrDefaultAsync(x => x.Id == id);

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                var cnaesId = cliente.Cliente_Cnae_Rel.Select(y => y.Cnae_Id).ToList();
                var usersId = cliente.Cliente_Responsavel.Select(y => y.User_Id).ToList();

                var cnaes = db.Cliente_Cnae.Where(x => cnaesId.Contains(x.Id)).ToList();
                var users = db.AspNetUsers.Where(x => usersId.Contains(x.Id)).ToList();

                cliente.cnaes = cnaes;
                cliente.users_Responsaveis = users;

                return Ok(cliente);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            if(cliente == null)
            {
                return BadRequest("Dados inválidos");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return Ok(cliente);
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
