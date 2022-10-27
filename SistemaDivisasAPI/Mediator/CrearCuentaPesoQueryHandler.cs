using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class CrearCuentaPesoQueryHandler : IRequestHandler<CrearCuentaPesoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public CrearCuentaPesoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CrearCuentaPesoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaPeso = new CuentaPeso()
                {
                    IdCliente = request.IdCliente,
                    NumCuenta = request.NumCuenta,
                    CBU = request.CBU,
                    AliasCBU = request.AliasCBU,
                    Saldo = request.Saldo
                };

                _context.CuentaPeso.Add(cuentaPeso);

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
