using MediatR;
using SistemaDivisasAPI.Data;

namespace SistemaDivisasAPI.Mediator
{
    public class VerCuentaDolarQueryHandler : IRequestHandler<VerCuentaDolarQuery, VerCuentaDolarQueryResponse>
    {
        protected readonly ApplicationDbContext _context;

        public VerCuentaDolarQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VerCuentaDolarQueryResponse> Handle(VerCuentaDolarQuery request, CancellationToken cancellationToken)
        {
            var cuentaDolar = await _context.CuentaDolar.FindAsync(request.CuentaId);

            return new VerCuentaDolarQueryResponse()
            {
                Id = cuentaDolar.Id,
                IdCliente = cuentaDolar.IdCliente,
                NumCuenta = cuentaDolar.NumCuenta,
                CBU = cuentaDolar.CBU,
                AliasCBU = cuentaDolar.AliasCBU,
                Saldo = cuentaDolar.Saldo
            };
        }
    }
}
