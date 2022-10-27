using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class DepositoDolarQueryHandler : IRequestHandler<DepositoDolarQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public DepositoDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DepositoDolarQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaDolar = await _context.CuentaDolar.FindAsync(request.IdCuenta);

                cuentaDolar.Saldo += request.Saldo;

                _context.CuentaDolar.Update(cuentaDolar);

                string mensaje = "Se ha depositado u$s" + request.Saldo.ToString();

                var movimiento = new Movimiento()
                {
                    NumCuenta = cuentaDolar.NumCuenta.ToString(),
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
