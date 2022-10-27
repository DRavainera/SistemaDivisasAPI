using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class ComprarCriptoQuery : IRequest<bool>
    {
        public int CuentaCriptoId { get; set; }
        public int CuentaDolarId { get; set; }
        public double Saldo { get; set; }
    }
}
