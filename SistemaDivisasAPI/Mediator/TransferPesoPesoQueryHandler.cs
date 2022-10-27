using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class TransferPesoPesoQueryHandler : IRequestHandler<TransferPesoPesoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public TransferPesoPesoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(TransferPesoPesoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaOrigen = await _context.CuentaPeso.FindAsync(request.IdCuentaOrigen);

                var cuentaDestino = await _context.CuentaPeso.FindAsync(request.IdCuentaDestino);

                if (cuentaOrigen.Saldo >= request.Saldo)
                {
                    cuentaOrigen.Saldo -= request.Saldo;

                    cuentaDestino.Saldo += request.Saldo;

                    _context.CuentaPeso.Update(cuentaOrigen);

                    _context.CuentaPeso.Update(cuentaDestino);

                    string mensaje1 = "Se ha transferido $" + request.Saldo.ToString() + " a la cuenta en pesos " + cuentaDestino.NumCuenta.ToString();

                    var movimiento1 = new Movimiento()
                    {
                        NumCuenta = cuentaOrigen.NumCuenta.ToString(),
                        Fecha = DateTime.Now,
                        Descripcion = mensaje1
                    };

                    _context.Movimiento.Add(movimiento1);

                    string mensaje2 = "Se ha recibido $" + request.Saldo.ToString() + " de la cuenta en pesos " + cuentaOrigen.NumCuenta.ToString();

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
            catch(Exception e)
            {
                return false;
            }

        }
    }
}
