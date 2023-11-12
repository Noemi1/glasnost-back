using glasnost_back.Helpers;
using glasnost_back.Models;
using glasnost_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace glasnost_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly ModelDBContext db;
        private readonly IPessoaService _services;

        public PessoaController(ModelDBContext context, IPessoaService service)
        {
            db = context;
            _services = service;
        }

        [HttpGet("All/{empresaId}/{ativo?}")]
        public ActionResult GetAll(int empresaId, bool? ativo)
        {
            try
            {
                return Ok(_services.GetAll(empresaId, ativo));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpGet("{Id}")]
        public ActionResult Get(int Id)
        {
            try
            {
                return Ok(_services.Get(Id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost()]
        public ActionResult Insert(PessoaResponse model)
        {
            try
            {
                return Ok(_services.Insert(model));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        public ActionResult Update(PessoaResponse model)
        {
            try
            {
                return Ok(_services.Update(model));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPatch("{Id}/{Active}"), ActionName("deactivate")]
        public ActionResult Deactivate(int Id, bool Active)
        {
            try
            {
                _services.Deactivated(Id, Active);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            try
            {
                _services.Delete(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}
