using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class TransferDolarDolarQuery : IRequest<bool>
    {
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public double Saldo { get; set; }
    }
}
