using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class BorrarCuentaDolarQueryHandler : IRequestHandler<BorrarCuentaDolarQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public BorrarCuentaDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(BorrarCuentaDolarQuery request, CancellationToken cancellationToken)
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

                _context.CuentaDolar.Remove(cuentaDolar);

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
