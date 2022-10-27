using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class ListarCuentaCriptoQuery : IRequest<List<ListarCuentaCriptoQueryResponse>>
    {
        public int ClienteId { get; set; }
    }
}
