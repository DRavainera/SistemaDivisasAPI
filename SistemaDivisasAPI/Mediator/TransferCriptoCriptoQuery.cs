using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class TransferCriptoCriptoQuery : IRequest<bool>
    {
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public double Saldo { get; set; }
    }
}
