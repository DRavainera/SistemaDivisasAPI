using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class TransferCriptoCriptoQueryHandler : IRequestHandler<TransferCriptoCriptoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public TransferCriptoCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(TransferCriptoCriptoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaOrigen = await _context.CuentaCripto.FindAsync(request.IdCuentaOrigen);

                var cuentaDestino = await _context.CuentaCripto.FindAsync(request.IdCuentaDestino);

                if (cuentaOrigen.Saldo >= request.Saldo)
                {
                    cuentaOrigen.Saldo -= request.Saldo;

                    cuentaDestino.Saldo += request.Saldo;

                    _context.CuentaCripto.Update(cuentaOrigen);

                    _context.CuentaCripto.Update(cuentaDestino);

                    string mensaje1 = "Se ha transferido " + request.Saldo.ToString() + " BTC a la cuenta en Bitcoin " + cuentaDestino.UUID.ToString();

                    var movimiento1 = new Movimiento()
                    {
                        NumCuenta = cuentaOrigen.UUID.ToString(),
                        Fecha = DateTime.Now,
                        Descripcion = mensaje1
                    };

                    _context.Movimiento.Add(movimiento1);

                    string mensaje2 = "Se ha recibido " + request.Saldo.ToString() + " BTC de la cuenta en Bitcoin " + cuentaOrigen.UUID.ToString();

                    var movimiento2 = new Movimiento()
                    {
                        NumCuenta = cuentaDestino.UUID.ToString(),
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