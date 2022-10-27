using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaDivisasAPI.Data;

namespace SistemaDivisasAPI.Mediator
{
    public class VerMovimientosQueryHandler : IRequestHandler<VerMovimientosQuery, List<VerMovimientosQueryResponse>>
    {
        protected readonly ApplicationDbContext _context;

        public VerMovimientosQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VerMovimientosQueryResponse>> Handle(VerMovimientosQuery request, CancellationToken cancellationToken) =>
            await _context.Movimiento
                .AsNoTracking()
                .Select(m => new VerMovimientosQueryResponse()
                {
                    NumCuenta = m.NumCuenta,
                    Fecha = m.Fecha,
                    Descripcion = m.Descripcion
                })
            .Where(c => c.NumCuenta == request.NumCuenta)
            .ToListAsync();
    }
}
