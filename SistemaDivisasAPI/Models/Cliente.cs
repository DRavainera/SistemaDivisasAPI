namespace SistemaDivisasAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? DNI { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
