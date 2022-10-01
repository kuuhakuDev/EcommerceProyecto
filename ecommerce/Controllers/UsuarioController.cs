using Data.Models.DataBase;
using Dominio.DTOs;
using Dominio.Utils;
using ecommerce.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IService _service;
        public UsuarioController(IService service) { _service = service; }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDto>> Get() => Ok(_service.Usuario.GetData());

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto usuario)
        {
            if (HasUniqueEmail(usuario)) return await _service.Usuario.Insert(usuario);
            return Problem(statusCode: 400, title: "Error al agregar el nuevo usuario", detail: "El correo debe de ser unico.");
        }
        [HttpPut]
        public async Task<ActionResult<UsuarioDto>> Put([FromBody] UsuarioDto usuario) => Ok(await _service.Usuario.Update(usuario));
        [HttpDelete]
        public async Task<ActionResult<UsuarioDto>> Delete([FromBody] UsuarioDto usuario) => Ok(await _service.Usuario.Delete(usuario));

        private bool HasUniqueEmail(UsuarioDto user) => _service.Usuario.GetData().Any(u => u.Email != user.Email);
    }
}
