using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class DepositoPesoQuery : IRequest<bool>
    {
        public int IdCuenta { get; set; }
        public double Saldo { get; set; }
    }
}
