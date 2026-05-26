namespace LP3.BlazorServer.Domain.Entities;

public class Matriculacion
{
    public int Id { get; set; }

    public int EstudianteId { get; set; }

    public int CursoId { get; set; }

    public DateTime FechaInscripcion { get; set; }
        = DateTime.UtcNow;

    public decimal? CalificacionFinal { get; set; }

    public Estudiante Estudiante { get; set; } = null!;

    public Curso Curso { get; set; } = null!;
}