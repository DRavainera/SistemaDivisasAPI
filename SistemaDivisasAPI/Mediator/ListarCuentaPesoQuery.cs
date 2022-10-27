using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class ListarCuentaPesoQuery : IRequest<List<ListarCuentaPesoQueryResponse>>
    {
        public int ClienteId { get; set; }
    }
}
