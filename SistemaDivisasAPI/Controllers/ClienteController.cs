using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Mediator;

namespace SistemaDivisasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery login)
        {
            if (login == null)
            {
                return BadRequest();
            }

            var loginUsuario = await _mediator.Send(login);

            if (loginUsuario == null)
            {
                return NotFound();
            }

            return Ok(loginUsuario);
        }
    }
}
