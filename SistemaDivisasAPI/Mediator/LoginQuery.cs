using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class LoginQuery : IRequest<LoginQueryResponse>
    {
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
