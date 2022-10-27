using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class DepositoCriptoQueryHandler : IRequestHandler<DepositoCriptoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public DepositoCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DepositoCriptoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaCripto = await _context.CuentaCripto.FindAsync(request.IdCuenta);

                cuentaCripto.Saldo += request.Saldo;

                _context.CuentaCripto.Update(cuentaCripto);

                string mensaje = "Se ha depositado " + request.Saldo.ToString() + " BTC";

                var movimiento = new Movimiento()
                {
                    NumCuenta = cuentaCripto.UUID.ToString(),
                    Fecha = DateTime.Now,
                    Descripcion = mensaje
                };

                _context.Movimiento.Add(movimiento);

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
