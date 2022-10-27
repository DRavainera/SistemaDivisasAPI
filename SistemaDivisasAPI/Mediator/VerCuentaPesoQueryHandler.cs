using MediatR;
using SistemaDivisasAPI.Data;

namespace SistemaDivisasAPI.Mediator
{
    public class VerCuentaPesoQueryHandler : IRequestHandler<VerCuentaPesoQuery, VerCuentaPesoQueryResponse>
    {
        protected readonly ApplicationDbContext _context;

        public VerCuentaPesoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VerCuentaPesoQueryResponse> Handle(VerCuentaPesoQuery request, CancellationToken cancellationToken)
        {
            var cuentaPeso = await _context.CuentaPeso.FindAsync(request.CuentaId);

            return new VerCuentaPesoQueryResponse()
            {
                Id = cuentaPeso.Id,
                IdCliente = cuentaPeso.IdCliente,
                NumCuenta = cuentaPeso.NumCuenta,
                CBU = cuentaPeso.CBU,
                AliasCBU = cuentaPeso.AliasCBU,
                Saldo = cuentaPeso.Saldo
            };
        }
    }
}
