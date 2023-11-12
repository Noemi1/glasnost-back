using glasnost_back.Helpers;
using glasnost_back.Models;
using glasnost_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace glasnost_back.Controllers
{
    [Route("api/cnae")]
    [ApiController]
    public class EmpresaCnaeController : ControllerBase
    {
        private readonly ModelDBContext db;
        private readonly ICnaeService _services;

        public EmpresaCnaeController(ModelDBContext context, ICnaeService service)
        {
            db = context;
            _services = service;
        }

        [HttpGet]
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
   
    }
}
