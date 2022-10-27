using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class VerCuentaCriptoQuery : IRequest<VerCuentaCriptoQueryResponse>
    {
        public int CuentaId { get; set; }
    }
}
