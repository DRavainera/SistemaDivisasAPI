using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class VenderDolarQuery : IRequest<bool>
    {
        public int CuentaPesoId { get; set; }
        public int CuentaDolarId { get; set; }
        public double Saldo { get; set; }
    }
}
