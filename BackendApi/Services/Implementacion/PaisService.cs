using Microsoft.EntityFrameworkCore;
using BackendApi.Models;
using BackendApi.Services.Contrato;
using BackendApi.DTOs;
using AutoMapper;

namespace BackendApi.Services.Implementacion
{
    public class PaisService : IPaisService
    {
        private DbApiContext _contexto;
        private IMapper _mapper;

        public PaisService (DbApiContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;

        }

        public async Task<List<Pai>> GetAllPaises()
        {
            return await _contexto.Pais.ToListAsync();
        }

        public async Task<List<PaisDTO>> GetAllPaisesConDepartamentos()
        {
            var listaPaises = await _contexto.Pais.ToListAsync();
            var listaPaisesDTO = _mapper.Map<List<PaisDTO>>(listaPaises);

            foreach (var paisDTO in listaPaisesDTO)
            {
                var departamentos = await _contexto.Departamentos.Where(d => d.IdPais == paisDTO.IdPais).ToListAsync();
                var departamentosDTO = _mapper.Map<List<DepartamentoDTO>>(departamentos);
                paisDTO.Departamentos = departamentosDTO;
            }
            return listaPaisesDTO;
        }

        public Pai GetPaisById(int id)
        {
            return _contexto.Pais.FirstOrDefault(p => p.IdPais == id);
        }
    }
}
