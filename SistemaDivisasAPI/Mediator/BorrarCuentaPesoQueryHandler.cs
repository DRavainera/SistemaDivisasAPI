using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class BorrarCuentaPesoQueryHandler : IRequestHandler<BorrarCuentaPesoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public BorrarCuentaPesoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(BorrarCuentaPesoQuery request, CancellationToken cancellationToken)
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

                _context.CuentaPeso.Remove(cuentaPeso);

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
