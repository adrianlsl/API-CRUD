using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? Nombre { get; set; }

    public int? IdPais { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Pai? IdPaisNavigation { get; set; }
}
