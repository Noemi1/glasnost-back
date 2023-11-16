using glasnost_back.Helpers;
using glasnost_back.Models;
using glasnost_back.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace glasnost_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly ModelDBContext db;
        private readonly IEmpresaService _services;

        public EmpresaController(ModelDBContext context, IEmpresaService service)
        {
            db = context;
            _services = service;
        }

        [HttpGet()]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_services.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        
        [HttpGet("risco-compliance")]
        public ActionResult GetRiscoCompliance()
        {
            try
            {
                return Ok(_services.GetRiscoCompliance());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpGet("tipo")]
        public ActionResult GetTipo()
        {
            try
            {
                return Ok(_services.GetTipo());
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

        [HttpPost]
        public ActionResult Insert(EmpresaResponse model)
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
        public ActionResult Update(EmpresaResponse model)
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

        [HttpGet("valida-cnpj/{Id}/{CNPJ}")]
        public ActionResult CNPJValido(int Id, long CNPJ)
        {
            try
            {
                var valid = _services.CNPJValido(Id, CNPJ);
                return Ok(valid);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
