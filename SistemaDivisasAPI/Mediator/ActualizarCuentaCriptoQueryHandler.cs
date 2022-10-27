using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConfigurationManager = SistemaDivisasAPI.Data.ConfigurationManager;

namespace SistemaDivisasAPI.Mediator
{
    public class ActualizarCuentaCriptoQueryHandler : IRequestHandler<ActualizarCuentaCriptoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public ActualizarCuentaCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ActualizarCuentaCriptoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaCripto = new CuentaCripto()
                {
                    Id = request.Id,
                    IdCliente = request.IdCliente,
                    UUID = request.UUID,
                    Saldo = request.Saldo
                };

                _context.CuentaCripto.Update(cuentaCripto);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
