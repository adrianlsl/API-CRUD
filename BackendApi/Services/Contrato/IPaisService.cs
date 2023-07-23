using BackendApi.DTOs;
using BackendApi.Models;

namespace BackendApi.Services.Contrato
{
    public interface IPaisService
    {
        Task<List<Pai>> GetAllPaises();
        Task<List<PaisDTO>> GetAllPaisesConDepartamentos();
        Pai GetPaisById(int id);
    }
}
