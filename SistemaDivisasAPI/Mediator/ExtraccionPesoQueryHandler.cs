using MediatR;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;

namespace SistemaDivisasAPI.Mediator
{
    public class ExtraccionPesoQueryHandler : IRequestHandler<ExtraccionPesoQuery, bool>
    {
        protected readonly ApplicationDbContext _context;

        public ExtraccionPesoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ExtraccionPesoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaPeso = await _context.CuentaPeso.FindAsync(request.IdCuenta);
                
                if (cuentaPeso.Saldo >= request.Saldo)
                {
                    cuentaPeso.Saldo -= request.Saldo;

                    _context.CuentaPeso.Update(cuentaPeso);

                    string mensaje = "Se ha extraido $" + request.Saldo.ToString();

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

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
