using Dominio.Utils;
using ecommerce.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IService _service;
        public AccountController(IService service)
        {
            _service = service;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] User user) =>
            Ok(await _service.Usuario.Login(user.Email, user.Password)) ??
            Problem(statusCode: 401, title: "No se pudo iniciar sesión.", detail: "Usuario o contraseña son incorrectos.");

        [HttpGet("Logout")]
        public async Task<ActionResult> LogOut()
        {
            var token = Request.Headers["Token"].ToString();
            await _service.Usuario.Logout(token);
            return Ok();
        }
    }

    public record User
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
