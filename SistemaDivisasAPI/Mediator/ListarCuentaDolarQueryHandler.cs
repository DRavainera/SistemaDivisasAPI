using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaDivisasAPI.Data;

namespace SistemaDivisasAPI.Mediator
{
    public class ListarCuentaDolarQueryHandler : IRequestHandler<ListarCuentaDolarQuery, List<ListarCuentaDolarQueryResponse>>
    {
        protected readonly ApplicationDbContext _context;

        public ListarCuentaDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListarCuentaDolarQueryResponse>> Handle(ListarCuentaDolarQuery request, CancellationToken cancellationToken) =>
            _context.CuentaDolar
                .AsNoTracking()
                .Select(cp => new ListarCuentaDolarQueryResponse()
                {
                    Id = cp.Id,
                    IdCliente = cp.IdCliente,
                    NumCuenta = cp.NumCuenta,
                    CBU = cp.CBU,
                    AliasCBU = cp.AliasCBU,
                    Saldo = cp.Saldo
                })
            .Where(c => c.IdCliente == request.ClienteId)
            .ToList();
    }
}
