namespace SistemaDivisasAPI.DTO
{
    public class ListarCuentasCriptoResponseDTO
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public int IdCliente { get; set; }
        public double Saldo { get; set; }
    }
}
