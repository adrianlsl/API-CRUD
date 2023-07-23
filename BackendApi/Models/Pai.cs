using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Pai
{
    public int IdPais { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
