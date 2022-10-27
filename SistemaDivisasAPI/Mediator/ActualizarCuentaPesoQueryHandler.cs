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
    public class ActualizarCuentaPesoQueryHandler : IRequestHandler<ActualizarCuentaPesoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public ActualizarCuentaPesoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ActualizarCuentaPesoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaPeso = new CuentaPeso()
                {
                    Id = request.Id,
                    IdCliente = request.IdCliente,
                    NumCuenta = request.NumCuenta,
                    CBU = request.CBU,
                    AliasCBU = request.AliasCBU,
                    Saldo = request.Saldo
                };

                _context.CuentaPeso.Update(cuentaPeso);

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
