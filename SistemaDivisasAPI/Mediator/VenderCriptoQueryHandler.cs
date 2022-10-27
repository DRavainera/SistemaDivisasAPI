using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class VenderCriptoQueryHandler : IRequestHandler<VenderCriptoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public VenderCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(VenderCriptoQuery request, CancellationToken cancellationToken)
        {
            double valorCripto = 0.0048;

            try
            {
                var cuentaOrigen = await _context.CuentaCripto.FindAsync(request.CuentaCriptoId);

                var cuentaDestino = await _context.CuentaDolar.FindAsync(request.CuentaDolarId);

                if (cuentaOrigen.Saldo >= request.Saldo)
                {
                    var conversionCripto = request.Saldo / valorCripto;

                    cuentaOrigen.Saldo -= request.Saldo;

                    cuentaDestino.Saldo += conversionCripto;

                    _context.CuentaDolar.Update(cuentaDestino);

                    _context.CuentaCripto.Update(cuentaOrigen);

                    string mensaje1 = "Se ha vendido " + conversionCripto.ToString() + " BTC y enviado a la cuenta en Dolars " + cuentaDestino.NumCuenta.ToString();

                    var movimiento1 = new Movimiento()
                    {
                        NumCuenta = cuentaOrigen.UUID.ToString(),
                        Fecha = DateTime.Now,
                        Descripcion = mensaje1
                    };

                    _context.Movimiento.Add(movimiento1);

                    string mensaje2 = "Se ha recibido $" + request.Saldo.ToString();

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
