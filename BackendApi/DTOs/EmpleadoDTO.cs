namespace BackendApi.DTOs
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }

        public int? IdDepartamento { get; set; }
        public string? NombreDepartamento { get; set; }


        public int? IdPais { get; set; }
        public string? NombrePais { get; set; }

        public decimal? Sueldo { get; set; }

        public string? FechaContrato { get; set; }
    }
}
