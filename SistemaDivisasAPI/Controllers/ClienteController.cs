using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDivisasAPI.DTO;
using SistemaDivisasAPI.Mediator;

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
                return Unauthorized();
            }

            return Ok(loginResponse);
        }

        [HttpGet]
        [Authorize]
        [Route("VerCliente")]
        public async Task<IActionResult> VerCliente(string usuario, string contrasenia)
        {
            var cliente = new VerClienteQuery()
            {
                Usuario = usuario,
                Contrasenia = contrasenia
            };

            if (cliente == null)
            {
                return BadRequest();
            }

            var verCliente = await _mediator.Send(cliente);

            var verClienteResponse = _mapper.Map<VerClienteResponseDTO>(verCliente);

            if (verClienteResponse == null)
            {
                return Unauthorized();
            }

            return Ok(verClienteResponse);
        }
    }
}
