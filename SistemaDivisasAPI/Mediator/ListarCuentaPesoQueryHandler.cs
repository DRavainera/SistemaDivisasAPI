using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaDivisasAPI.Data;

namespace SistemaDivisasAPI.Mediator
{
    public class ListarCuentaPesoQueryHandler : IRequestHandler<ListarCuentaPesoQuery, List<ListarCuentaPesoQueryResponse>>
    {
        protected readonly ApplicationDbContext _context;

        public ListarCuentaPesoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListarCuentaPesoQueryResponse>> Handle(ListarCuentaPesoQuery request, CancellationToken cancellationToken) =>
            await _context.CuentaPeso
                .AsNoTracking()
                .Select(cp => new ListarCuentaPesoQueryResponse()
                {
                    Id = cp.Id,
                    IdCliente = cp.IdCliente,
                    NumCuenta = cp.NumCuenta,
                    CBU = cp.CBU,
                    AliasCBU = cp.AliasCBU,
                    Saldo = cp.Saldo
                })
            .Where(c => c.IdCliente == request.ClienteId)
            .ToListAsync();
    }
}
