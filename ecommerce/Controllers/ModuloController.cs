using Dominio.DTOs;
using Dominio.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly IService _service;
        public ModuloController(IService service) { _service = service; }

        [HttpPost]
        public async Task<ModuloDto> Post([FromBody] ModuloDto value)
        {
            var token = HttpContext.Request.Headers["token"];

            return value;
            //return await _service.Modulo.Insert(value);
        }
    }
}
