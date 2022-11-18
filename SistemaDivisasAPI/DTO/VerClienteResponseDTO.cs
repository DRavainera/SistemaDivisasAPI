namespace SistemaDivisasAPI.DTO
{
    public class VerClienteResponseDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? DNI { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
