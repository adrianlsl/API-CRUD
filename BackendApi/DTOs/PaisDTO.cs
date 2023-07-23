namespace BackendApi.DTOs
{
    public class PaisDTO
    {
        public int IdPais { get; set; }

        public string? Nombre { get; set; }
        public List<DepartamentoDTO> Departamentos { get; set; }
    }
}
