namespace SistemaDivisasAPI.DTO
{
    public class BorrarCuentaCriptoDTO
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public int IdCliente { get; set; }
        public double Saldo { get; set; }
    }
}
