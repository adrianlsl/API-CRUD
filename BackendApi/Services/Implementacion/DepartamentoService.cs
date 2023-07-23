using BackendApi.Models;
using BackendApi.Services.Contrato;

namespace BackendApi.Services.Implementacion
{
    public class DepartamentoService : IDepartamentoService
    {
        private DbApiContext _contexto;

        public DepartamentoService(DbApiContext contexto)
        {
            _contexto = contexto;
        }

        public List<Departamento> GetDepartamentosByPais(int idPais)
        {
            return _contexto.Departamentos.Where(d => d.IdPais == idPais).ToList();
        }
    }
}
