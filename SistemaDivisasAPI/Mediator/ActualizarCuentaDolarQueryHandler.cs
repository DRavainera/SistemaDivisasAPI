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
    public class ActualizarCuentaDolarQueryHandler : IRequestHandler<ActualizarCuentaDolarQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public ActualizarCuentaDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ActualizarCuentaDolarQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaDolar = new CuentaDolar()
                {
                    Id = request.Id,
                    IdCliente = request.IdCliente,
                    NumCuenta = request.NumCuenta,
                    CBU = request.CBU,
                    AliasCBU = request.AliasCBU,
                    Saldo = request.Saldo
                };

                _context.CuentaDolar.Update(cuentaDolar);

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
