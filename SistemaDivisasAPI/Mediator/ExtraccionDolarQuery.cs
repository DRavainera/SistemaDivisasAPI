using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class ExtraccionDolarQuery : IRequest<bool>
    {
        public int IdCuenta { get; set; }
        public double Saldo { get; set; }
    }
}
