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
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var loginMapper = _mapper.Map<LoginQuery>(login);

            if (loginMapper == null)
            {
                return BadRequest();
            }
            
            var loginUsuario = await _mediator.Send(loginMapper);

            var loginResponse = _mapper.Map<LoginResponseDTO>(loginUsuario);

            if (loginResponse == null)
            {
                return NotFound();
            }

            return Ok(loginResponse);
        }
    }
}
