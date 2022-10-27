using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class CrearCuentaDolarQueryHandler : IRequestHandler<CrearCuentaDolarQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public CrearCuentaDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CrearCuentaDolarQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaDolar = new CuentaDolar()
                {
                    IdCliente = request.IdCliente,
                    NumCuenta = request.NumCuenta,
                    CBU = request.CBU,
                    AliasCBU = request.AliasCBU,
                    Saldo = request.Saldo
                };

                _context.CuentaDolar.Add(cuentaDolar);

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
