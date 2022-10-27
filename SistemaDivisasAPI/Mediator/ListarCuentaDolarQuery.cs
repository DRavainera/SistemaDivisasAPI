using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class ListarCuentaDolarQuery : IRequest<List<ListarCuentaDolarQueryResponse>>
    {
        public int ClienteId { get; set; }
    }
}
