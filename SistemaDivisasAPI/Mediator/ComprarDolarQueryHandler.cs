using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class ComprarDolarQueryHandler : IRequestHandler<ComprarDolarQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public ComprarDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ComprarDolarQuery request, CancellationToken cancellationToken)
        {
            double valorDolar = 155.00;

            try
            {
                var cuentaOrigen = await _context.CuentaPeso.FindAsync(request.CuentaPesoId);

                var cuentaDestino = await _context.CuentaDolar.FindAsync(request.CuentaDolarId);

                if (cuentaOrigen.Saldo >= request.Saldo)
                {
                    var conversionDolar = request.Saldo / valorDolar;

                    cuentaOrigen.Saldo -= request.Saldo;

                    cuentaDestino.Saldo += conversionDolar;

                    _context.CuentaPeso.Update(cuentaOrigen);

                    _context.CuentaDolar.Update(cuentaDestino);

                    string mensaje1 = "Se ha comprado u$s" + conversionDolar.ToString() + " y enviado a la cuenta en dolares " + cuentaDestino.NumCuenta.ToString();

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
