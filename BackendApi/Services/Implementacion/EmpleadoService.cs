using Microsoft.EntityFrameworkCore;
using BackendApi.Models;
using BackendApi.Services.Contrato;
using AutoMapper;
using BackendApi.DTOs;

namespace BackendApi.Services.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private DbApiContext _contexto;
        private IMapper _mapper;

        public EmpleadoService(DbApiContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public List<Empleado> GetAllEmpleados()
        {
            return _contexto.Empleados.ToList();
        }

        public Empleado GetEmpleadoById(int id)
        {
            return _contexto.Empleados.FirstOrDefault(e => e.IdEmpleado == id);
        }

        public List<Empleado> GetEmpleadosByPaisYDepartamento(int idPais, int idDepartamento)
        {
            return _contexto.Empleados.Where(e => e.IdPais == idPais && e.IdDepartamento == idDepartamento).ToList();
        }
        public List<EmpleadoDTO> GetAllEmpleadosConDepartamentosPaises()
        {
            var empleados = _contexto.Empleados.ToList();
            var empleadosDTO = _mapper.Map<List<EmpleadoDTO>>(empleados);

            foreach (var empleadoDTO in empleadosDTO)
            {
                var departamento = _contexto.Departamentos.FirstOrDefault(d => d.IdDepartamento == empleadoDTO.IdDepartamento);
                var pais = _contexto.Pais.FirstOrDefault(p => p.IdPais == empleadoDTO.IdPais);

                empleadoDTO.NombreDepartamento = departamento?.Nombre;
                empleadoDTO.NombrePais = pais?.Nombre;
            }

            return empleadosDTO;
        }
        public void CreateEmpleado(Empleado empleado)
        {
            _contexto.Empleados.Add(empleado);
            _contexto.SaveChanges();
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            _contexto.Empleados.Update(empleado);
            _contexto.SaveChanges();

        }

        public void DeleteEmpleado(int id)
        {
            var empleado = _contexto.Empleados.Find(id);
            if (empleado != null)
            {
                _contexto.Empleados.Remove(empleado);
                _contexto.SaveChanges();
            }

        }

    }
}
