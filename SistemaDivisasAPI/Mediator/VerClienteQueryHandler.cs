using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;
using SistemaDivisasAPI.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConfigurationManager = SistemaDivisasAPI.Data.ConfigurationManager;

namespace SistemaDivisasAPI.Mediator
{
    public class VerClienteQueryHandler : IRequestHandler<VerClienteQuery, VerClienteQueryResponse>
    {
        protected readonly ApplicationDbContext _context;

        public VerClienteQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VerClienteQueryResponse> Handle(VerClienteQuery request, CancellationToken cancellationToken)
        {
            var listaClientes = await _context.Cliente.ToListAsync();

            foreach (var unCliente in listaClientes)
            {
                if (request.Usuario == unCliente.Usuario && request.Contrasenia == unCliente.Contrasenia)
                {
                    var clienteResponse = new VerClienteQueryResponse() 
                    { 
                        Id = unCliente.Id,
                        Nombre = unCliente.Nombre,   
                        Apellido = unCliente.Apellido,
                        DNI = unCliente.DNI,
                        Direccion = unCliente.Direccion,
                        FechaNacimiento = unCliente.FechaNacimiento
                    };

                    return clienteResponse;
                }
            }

            return new VerClienteQueryResponse();
        }
    }
}
