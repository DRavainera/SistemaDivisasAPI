using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class VenderCriptoQuery : IRequest<bool>
    {
        public int CuentaCriptoId { get; set; }
        public int CuentaDolarId { get; set; }
        public double Saldo { get; set; }
    }
}
