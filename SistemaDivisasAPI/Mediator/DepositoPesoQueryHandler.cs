using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class DepositoPesoQueryHandler : IRequestHandler<DepositoPesoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public DepositoPesoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DepositoPesoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaPeso = await _context.CuentaPeso.FindAsync(request.IdCuenta);

                cuentaPeso.Saldo += request.Saldo;

                _context.CuentaPeso.Update(cuentaPeso);

                string mensaje = "Se ha depositado $" + request.Saldo.ToString();

                var movimiento = new Movimiento()
                {
                    NumCuenta = cuentaPeso.NumCuenta.ToString(),
                    Fecha = DateTime.Now,
                    Descripcion = mensaje
                };

                _context.Movimiento.Add(movimiento);

                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception e) 
            {
                return false;
            }
        }
    }
}
