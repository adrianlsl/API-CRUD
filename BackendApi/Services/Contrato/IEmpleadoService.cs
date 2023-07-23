using BackendApi.DTOs;
using BackendApi.Models;
namespace BackendApi.Services.Contrato
{
    public interface IEmpleadoService
    {
        List<Empleado> GetAllEmpleados();
        List<EmpleadoDTO> GetAllEmpleadosConDepartamentosPaises();
        Empleado GetEmpleadoById(int id);
        List<Empleado> GetEmpleadosByPaisYDepartamento(int idPais, int idDepartamento);
        void CreateEmpleado(Empleado empleado);
        void UpdateEmpleado(Empleado empleado);
        void DeleteEmpleado(int id);
    }
}
