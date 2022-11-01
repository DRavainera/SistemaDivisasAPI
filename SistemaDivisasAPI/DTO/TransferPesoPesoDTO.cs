namespace SistemaDivisasAPI.DTO
{
    public class TransferPesoPesoDTO
    {
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public double Saldo { get; set; }
    }
}
