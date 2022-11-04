using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.DTO;
using SistemaDivisasAPI.Mediator;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public ClienteController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(string usuario, string contrasenia)
        {
            var login = new LoginQuery()
            {
                Usuario = usuario,
                Contrasenia = contrasenia
            };

            if (login == null)
            {
                return BadRequest();
            }
            
            var loginUsuario = await _mediator.Send(login);

            var loginResponse = _mapper.Map<LoginResponseDTO>(loginUsuario);

            if (loginResponse == null)
            {
                return NotFound();
            }

            return Ok(loginResponse);
        }
    }
}
