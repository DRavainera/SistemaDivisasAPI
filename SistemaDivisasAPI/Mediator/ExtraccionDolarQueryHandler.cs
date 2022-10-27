using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class ExtraccionDolarQueryHandler : IRequestHandler<ExtraccionDolarQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public ExtraccionDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ExtraccionDolarQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaDolar = await _context.CuentaDolar.FindAsync(request.IdCuenta);

                if (cuentaDolar.Saldo >= request.Saldo)
                {
                    cuentaDolar.Saldo -= request.Saldo;

                    _context.CuentaDolar.Update(cuentaDolar);

                    string mensaje = "Se ha extraido u$s" + request.Saldo.ToString();

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

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
