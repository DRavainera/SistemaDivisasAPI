using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class CrearCuentaCriptoQueryHandler : IRequestHandler<CrearCuentaCriptoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public CrearCuentaCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CrearCuentaCriptoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaCripto = new CuentaCripto()
                {
                    IdCliente = request.IdCliente,
                    UUID = request.UUID,
                    Saldo = request.Saldo
                };

                _context.CuentaCripto.Add(cuentaCripto);

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
