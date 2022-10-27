using MediatR;

namespace SistemaDivisasAPI.Mediator
{
    public class BorrarCuentaCriptoQuery : IRequest<bool>
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public int IdCliente { get; set; }
        public double Saldo { get; set; }
    }
}
