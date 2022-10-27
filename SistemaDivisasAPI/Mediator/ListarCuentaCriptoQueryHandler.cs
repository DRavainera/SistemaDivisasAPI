using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaDivisasAPI.Data;

namespace SistemaDivisasAPI.Mediator
{
    public class ListarCuentaCriptoQueryHandler : IRequestHandler<ListarCuentaCriptoQuery, List<ListarCuentaCriptoQueryResponse>>
    {
        protected readonly ApplicationDbContext _context;

        public ListarCuentaCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListarCuentaCriptoQueryResponse>> Handle(ListarCuentaCriptoQuery request, CancellationToken cancellationToken) =>
            _context.CuentaCripto
                .AsNoTracking()
                .Select(cp => new ListarCuentaCriptoQueryResponse()
                {
                    Id = cp.Id,
                    IdCliente = cp.IdCliente,
                    UUID = cp.UUID,
                    Saldo = cp.Saldo
                })
            .Where(c => c.IdCliente == request.ClienteId)
            .ToList();
    }
}
