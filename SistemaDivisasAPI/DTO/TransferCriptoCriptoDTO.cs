namespace SistemaDivisasAPI.DTO
{
    public class TransferCriptoCriptoDTO
    {
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public double Saldo { get; set; }
    }
}
