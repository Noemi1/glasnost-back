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
        public IActionResult GetCliente([FromRoute] int id)
        {
            try
            {
                Cliente cliente = db.Cliente
                .Include(x => x.Cliente_Cnae_Rel)
                .Include(x => x.Cliente_Responsavel)
                .Include(x => x.Cliente_Tipo)
                .Include(x => x.Cliente_RiscoCompliance)
                .FirstOrDefault(x => x.Id == id);

                cliente.Cliente_Cnae_Rel.ToList().ForEach(rel =>
                {
                    rel.Cnae = db.Cliente_Cnae.Find(rel.Cnae_Id);
                });

                cliente.Cliente_Responsavel.ToList().ForEach(rel =>
                {
                    rel.User = db.AspNetUsers.Find(rel.User_Id);
                });

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                return Ok(cliente);

            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Create([FromBody] ClienteCreate model)
        {
            if (model.cliente == null)
                return BadRequest("Dados inválidos");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                db.Cliente.Add(model.cliente);
                db.SaveChanges();

                if(model.cnaes != null)
                {
                    var rels = model.cnaes.Select(cnae =>
                    {
                        Cliente_Cnae_Rel rel = new Cliente_Cnae_Rel
                        {
                            Cliente_Id = model.cliente.Id,
                            Cnae_Id = cnae.Id
                        };
                        return rel;
                    });
                    db.Cliente_Cnae_Rel.AddRange(rels);
                    db.SaveChanges();
                }

                if(model.users != null)
                {
                    var rels = model.users.Select(user => 
                    {
                        Cliente_Responsavel rel = new Cliente_Responsavel
                        {
                            Cliente_Id = model.cliente.Id,
                            User_Id = user.Id,
                        };
                        return rel;
                    });
                    db.Cliente_Responsavel.AddRange(rels);
                    db.SaveChanges();
                }

                return Ok(GetClientes());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] ClienteCreate model)
        {
            if (id == 0)
                return BadRequest("Id inválido");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Cliente objAntigo = db.Cliente
                    .Include(x => x.Cliente_Responsavel)
                    .Include(x => x.Cliente_Cnae_Rel)
                    .FirstOrDefault(x => x.Id == id);

                if (objAntigo == null)
                    return BadRequest("Cliente não encontrado.");

                db.Entry(model.cliente).State = EntityState.Modified;
                db.SaveChanges();

                // Adiciona novos cnaes
                if (model.cnaes != null)
                {
                    List<Cliente_Cnae_Rel> rels = model.cnaes.Select(cnae =>
                    {
                        Cliente_Cnae_Rel rel = db.Cliente_Cnae_Rel.FirstOrDefault(x => x.Cnae_Id == cnae.Id && x.Cliente_Id == id);
                        if(rel == null)
                        {
                            rel = new Cliente_Cnae_Rel
                            {
                                Cliente_Id = model.cliente.Id,
                                Cnae_Id = cnae.Id
                            };
                            return rel;
                        } else
                        {
                            return null;
                        }
                    }).ToList();

                    db.Cliente_Cnae_Rel.AddRange(rels);
                    db.SaveChanges();
                }

                // Adiciona novos usuarios responsaveis
                if (model.users != null)
                {
                    List<Cliente_Responsavel> rels = model.users.Select(user =>
                    {
                        Cliente_Responsavel rel = db.Cliente_Responsavel.FirstOrDefault(x => x.User_Id == user.Id && x.Cliente_Id == id);
                        if (rel == null)
                        {
                            rel = new Cliente_Responsavel
                            {
                                Cliente_Id = model.cliente.Id,
                                User_Id = user.Id
                            };
                            return rel;
                        }
                        else
                        {
                            return null;
                        }
                    }).ToList();

                    db.Cliente_Responsavel.AddRange(rels);
                    db.SaveChanges();
                }

                // Remove cnaes
                model.cliente.Cliente_Cnae_Rel.Where(x => x.Excluir == true).Select(rel =>
                {
                    db.Cliente_Cnae_Rel.Attach(rel);
                    db.Cliente_Cnae_Rel.Remove(rel);
                    return rel;
                });
                db.SaveChanges();

                // Remove users
                model.cliente.Cliente_Responsavel.Where(x => x.Excluir == true).Select(rel =>
                {
                    db.Cliente_Responsavel.Attach(rel);
                    db.Cliente_Responsavel.Remove(rel);
                    return rel;
                });
                db.SaveChanges();

                return Ok();
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
