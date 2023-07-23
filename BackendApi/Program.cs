using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

using BackendApi.Services.Contrato;
using BackendApi.Services.Implementacion;

using AutoMapper;
using BackendApi.DTOs;
using BackendApi.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddDbContext<DbApiContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});


builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region PETICIONES API REST
app.MapGet("/pais/lista", async (
    IPaisService _paisService,
    IMapper _mapper
    ) =>
{
    var listaPaisDTO = await _paisService.GetAllPaisesConDepartamentos();

    if (listaPaisDTO.Count > 0)
        return Results.Ok(listaPaisDTO);
    else
    {
        return Results.NotFound();
    }
});
app.MapGet("/empleado/lista", async (
    IEmpleadoService _empleadoService
    ) =>
{
    var listaEmpleadosDTO = _empleadoService.GetAllEmpleadosConDepartamentosPaises();

    if (listaEmpleadosDTO.Count > 0)
        return Results.Ok(listaEmpleadosDTO);
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("/empleado", async (
    IEmpleadoService _empleadoService,
    Empleado nuevoEmpleado
    ) =>
{
    _empleadoService.CreateEmpleado(nuevoEmpleado);
    return Results.Created($"/empleado/{nuevoEmpleado.IdEmpleado}", nuevoEmpleado);
});

app.MapPut("/empleado/{id}", async (
    IEmpleadoService _empleadoService,
    Empleado actualizadoEmpleado,
    int id
    ) =>
{
    var empleadoExistente = _empleadoService.GetEmpleadoById(id);

    if (empleadoExistente == null)
    {
        return Results.NotFound();
    }

    empleadoExistente.Nombres = actualizadoEmpleado.Nombres;
    empleadoExistente.Apellidos = actualizadoEmpleado.Apellidos;
    empleadoExistente.IdDepartamento = actualizadoEmpleado.IdDepartamento;
    empleadoExistente.IdPais = actualizadoEmpleado.IdPais;
    empleadoExistente.Sueldo = actualizadoEmpleado.Sueldo;
    empleadoExistente.FechaContrato = actualizadoEmpleado.FechaContrato;

    _empleadoService.UpdateEmpleado(empleadoExistente);

    return Results.Ok();
});

app.MapDelete("/empleado/{id}", async (
    IEmpleadoService _empleadoService,
    int id
    ) =>
{
    var empleadoExistente = _empleadoService.GetEmpleadoById(id);

    if (empleadoExistente == null)
    {
        return Results.NotFound();
    }

    _empleadoService.DeleteEmpleado(id);

    return Results.Ok();
});

#endregion

app.UseCors("NuevaPolitica");

app.Run();
