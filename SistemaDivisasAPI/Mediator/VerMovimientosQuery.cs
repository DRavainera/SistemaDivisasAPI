using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class VerMovimientosQuery : IRequest<List<VerMovimientosQueryResponse>>
    {
        public string NumCuenta;
    }
}
