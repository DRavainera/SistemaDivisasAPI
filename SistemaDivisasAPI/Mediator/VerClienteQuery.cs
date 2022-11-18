using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class VerClienteQuery : IRequest<VerClienteQueryResponse>
    {
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
