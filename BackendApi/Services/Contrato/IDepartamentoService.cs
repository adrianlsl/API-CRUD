using BackendApi.Models;
using System.Collections.Generic;

namespace BackendApi.Services.Contrato
{
    public interface IDepartamentoService
    {
        List<Departamento> GetDepartamentosByPais(int idPais);
    }
}
