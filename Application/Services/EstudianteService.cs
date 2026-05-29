using LP3.BlazorServer.Data.Repositories;
using LP3.BlazorServer.Domain.Entities;
using LP3.BlazorServer.Domain.Enums;
using LP3.BlazorServer.Shared.DTOs;
using LP3.BlazorServer.Shared.Extensions;

namespace LP3.BlazorServer.Application.Services;

public class EstudianteService : IEstudianteService
{
    private readonly IEstudianteRepository _estudianteRepository;

    public EstudianteService(IEstudianteRepository estudianteRepository)
    {
        _estudianteRepository = estudianteRepository;
    }

    public async Task<ICollection<EstudianteDto>> GetAll()
    {
        var estudiantes = await _estudianteRepository.ListAsync();

        return estudiantes
            .Select(e => e.ToDto())
            .ToList();
    }

    public async Task<EstudianteDto?> GetByIdAsync(int id)
    {
        var estudiante = await _estudianteRepository.GetByIdAsync(id);

        return estudiante?.ToDto();
    }

    public async Task<EstudianteDto?> GetByMatriculaAsync(string matricula)
    {
        var estudiante = await _estudianteRepository.GetByMatriculaAsync(matricula);

        return estudiante?.ToDto();
    }

    public async Task<bool> CreateAsync(EstudianteDto dto)
    {
        try
        {
            var estudiante = new Estudiante
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Matricula = dto.Matricula,
                FechaIngreso = DateTime.UtcNow,
                Estado = EstadoEstudiante.Activo
            };

            await _estudianteRepository.AddAsync(estudiante);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(int id, EstudianteDto dto)
    {
        try
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(id);

            if (estudiante == null)
                return false;

            estudiante.Nombre = dto.Nombre;
            estudiante.Apellido = dto.Apellido;
            estudiante.ActualizadoEn = DateTime.UtcNow;

            await _estudianteRepository.Update(estudiante);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(id);

            if (estudiante == null)
                return false;

            await _estudianteRepository.Remove(estudiante);

            return true;
        }
        catch
        {
            return false;
        }
    }
}