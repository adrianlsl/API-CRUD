using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdPais { get; set; }

    public decimal? Sueldo { get; set; }

    public DateTime? FechaContrato { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual Pai? IdPaisNavigation { get; set; }
}
