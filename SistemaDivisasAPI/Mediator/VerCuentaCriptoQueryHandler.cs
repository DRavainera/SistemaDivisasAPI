using MediatR;
using SistemaDivisasAPI.Data;

namespace SistemaDivisasAPI.Mediator
{
    public class VerCuentaCriptoQueryHandler : IRequestHandler<VerCuentaCriptoQuery, VerCuentaCriptoQueryResponse>
    {
        protected readonly ApplicationDbContext _context;

        public VerCuentaCriptoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VerCuentaCriptoQueryResponse> Handle(VerCuentaCriptoQuery request, CancellationToken cancellationToken)
        {
            var cuentaCripto = await _context.CuentaCripto.FindAsync(request.CuentaId);

            return new VerCuentaCriptoQueryResponse()
            {
                Id = cuentaCripto.Id,
                IdCliente = cuentaCripto.IdCliente,
                UUID = cuentaCripto.UUID,
                Saldo = cuentaCripto.Saldo
            };
        }
    }
}
