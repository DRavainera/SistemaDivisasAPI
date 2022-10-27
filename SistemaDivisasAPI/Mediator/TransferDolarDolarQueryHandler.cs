using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class TransferDolarDolarQueryHandler : IRequestHandler<TransferDolarDolarQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public TransferDolarDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(TransferDolarDolarQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaOrigen = await _context.CuentaDolar.FindAsync(request.IdCuentaOrigen);

                var cuentaDestino = await _context.CuentaDolar.FindAsync(request.IdCuentaDestino);

                if (cuentaOrigen.Saldo >= request.Saldo)
                {
                    cuentaOrigen.Saldo -= request.Saldo;

                    cuentaDestino.Saldo += request.Saldo;

                    _context.CuentaDolar.Update(cuentaOrigen);

                    _context.CuentaDolar.Update(cuentaDestino);

                    string mensaje1 = "Se ha transferido u$s" + request.Saldo.ToString() + " a la cuenta en dolares " + cuentaDestino.NumCuenta.ToString();

                    var movimiento1 = new Movimiento()
                    {
                        NumCuenta = cuentaOrigen.NumCuenta.ToString(),
                        Fecha = DateTime.Now,
                        Descripcion = mensaje1
                    };

                    _context.Movimiento.Add(movimiento1);

                    string mensaje2 = "Se ha recibido u$s" + request.Saldo.ToString() + " de la cuenta en dolares " + cuentaOrigen.NumCuenta.ToString();

                    var movimiento2 = new Movimiento()
                    {
                        NumCuenta = cuentaDestino.NumCuenta.ToString(),
                        Fecha = DateTime.Now,
                        Descripcion = mensaje2
                    };

                    _context.Movimiento.Add(movimiento2);

                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
