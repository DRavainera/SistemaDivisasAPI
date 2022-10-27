using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class VerCuentaDolarQuery : IRequest<VerCuentaDolarQueryResponse>
    {
        public int CuentaId { get; set; }
    }
}
