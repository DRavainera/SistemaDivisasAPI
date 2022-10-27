using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class BorrarCuentaCriptoQueryHandler : IRequestHandler<BorrarCuentaCriptoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public BorrarCuentaCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(BorrarCuentaCriptoQuery request, CancellationToken cancellationToken)
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

                _context.CuentaCripto.Remove(cuentaCripto);

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
