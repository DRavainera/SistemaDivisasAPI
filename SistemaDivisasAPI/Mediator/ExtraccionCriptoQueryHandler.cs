using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class ExtraccionCriptoQueryHandler : IRequestHandler<ExtraccionCriptoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public ExtraccionCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ExtraccionCriptoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaCripto = await _context.CuentaCripto.FindAsync(request.IdCuenta);

                if (cuentaCripto.Saldo >= request.Saldo)
                {
                    cuentaCripto.Saldo -= request.Saldo;

                    _context.CuentaCripto.Update(cuentaCripto);

                    string mensaje = "Se ha extraido " + request.Saldo.ToString() + " BTC";

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

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
