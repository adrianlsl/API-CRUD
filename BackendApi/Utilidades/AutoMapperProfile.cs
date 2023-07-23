using AutoMapper;
using BackendApi.DTOs;
using BackendApi.Models;
using System.Globalization;

namespace BackendApi.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Pais
            CreateMap<Pai, PaisDTO>().ReverseMap();
            #endregion

            #region Departamento
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            #endregion

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(destino =>
                destino.NombrePais,
                opt => opt.MapFrom(origen => origen.IdPaisNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.NombreDepartamento,
                opt => opt.MapFrom(origen => origen.IdDepartamentoNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => origen.FechaContrato.Value.ToString("dd/MM/yyyy"))
            );
            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(destino =>
                destino.IdPaisNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.IdDepartamentoNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaContrato,"dd/MMMM/yyyy",CultureInfo.InvariantCulture))
                );
            #endregion

        }

    }
}
