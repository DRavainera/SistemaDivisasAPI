using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class ComprarCriptoQueryHandler : IRequestHandler<ComprarCriptoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public ComprarCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ComprarCriptoQuery request, CancellationToken cancellationToken)
        {
            double valorCripto = 0.0048;

            try
            {
                var cuentaOrigen = await _context.CuentaDolar.FindAsync(request.CuentaDolarId);

                var cuentaDestino = await _context.CuentaCripto.FindAsync(request.CuentaCriptoId);

                if (cuentaOrigen.Saldo >= request.Saldo)
                {
                    var conversionCripto = request.Saldo * valorCripto;

                    cuentaOrigen.Saldo -= request.Saldo;

                    cuentaDestino.Saldo += conversionCripto;

                    _context.CuentaDolar.Update(cuentaOrigen);

                    _context.CuentaCripto.Update(cuentaDestino);

                    string mensaje1 = "Se ha comprado " + conversionCripto.ToString() + " BTC y enviado a la cuenta en Bitcoin " + cuentaDestino.UUID.ToString();

                    var movimiento1 = new Movimiento()
                    {
                        NumCuenta = cuentaOrigen.NumCuenta.ToString(),
                        Fecha = DateTime.Now,
                        Descripcion = mensaje1
                    };

                    _context.Movimiento.Add(movimiento1);

                    string mensaje2 = "Se ha recibido u$s" + request.Saldo.ToString();

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
