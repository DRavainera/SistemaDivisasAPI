using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class VenderDolarQueryHandler : IRequestHandler<VenderDolarQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public VenderDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(VenderDolarQuery request, CancellationToken cancellationToken)
        {
            double valorDolar = 155.00;

            try
            {
                var cuentaOrigen = await _context.CuentaDolar.FindAsync(request.CuentaDolarId);

                var cuentaDestino = await _context.CuentaPeso.FindAsync(request.CuentaPesoId);

                if (cuentaOrigen.Saldo >= request.Saldo)
                {
                    var conversionDolar = request.Saldo * valorDolar;

                    cuentaOrigen.Saldo -= request.Saldo;

                    cuentaDestino.Saldo += conversionDolar;

                    _context.CuentaPeso.Update(cuentaDestino);

                    _context.CuentaDolar.Update(cuentaOrigen);

                    string mensaje1 = "Se ha vendido u$s" + conversionDolar.ToString() + " y enviado a la cuenta en pesos " + cuentaDestino.NumCuenta.ToString();

                    var movimiento1 = new Movimiento()
                    {
                        NumCuenta = cuentaOrigen.NumCuenta.ToString(),
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
