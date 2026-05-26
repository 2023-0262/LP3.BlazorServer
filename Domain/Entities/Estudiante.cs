using LP3.BlazorServer.Domain.Enums;

namespace LP3.BlazorServer.Domain.Entities;

public class Estudiante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public string Matricula { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime FechaIngreso { get; set; }

    public EstadoEstudiante Estado { get; set; } = EstadoEstudiante.Activo;

    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

    public DateTime? ActualizadoEn { get; set; }

    public ICollection<Matriculacion> Matriculaciones { get; set; }
        = new List<Matriculacion>();
}