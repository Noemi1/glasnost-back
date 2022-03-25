using glasnost_back.Models;
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

        [HttpGet("user-roles/{role_id}")]
        public async Task<IActionResult> GetByRoles([FromRoute] string role_id)
        {
            try
            {
                var role = db.AspNetRoles.Find(role_id);
                if (role == null)
                {
                    return NotFound("Acesso não encontrado!");
                }
                var users = db.AspNetUserRoles
                    .Where(n => n.RoleId == role_id)
                    .Include(x => x.AspNetUsers)
                    .Select(x => x.AspNetUsers)
                    .OrderBy(c => c.Name);


                return Ok(users);
            } 
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("user-responsaveis")]
        public async Task<IActionResult> GetUserResponsavel()
        {
            try
            {
                var users = db.AspNetUserRoles
                .Where(n => n.RoleId == "1" || n.RoleId == "4")
                .Include(x => x.AspNetUsers)
                .Select(x => x.AspNetUsers)
                .OrderBy(c => c.Name);


                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
