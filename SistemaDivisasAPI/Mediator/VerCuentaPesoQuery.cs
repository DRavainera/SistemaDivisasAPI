using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class VerCuentaPesoQuery : IRequest<VerCuentaPesoQueryResponse>
    {
        public int CuentaId { get; set; }
    }
}
