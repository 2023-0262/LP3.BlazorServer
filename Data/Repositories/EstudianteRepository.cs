using Microsoft.EntityFrameworkCore;
using LP3.BlazorServer.Domain.Entities;

namespace LP3.BlazorServer.Data.Repositories;

public class EstudianteRepository : Repository<Estudiante>, IEstudianteRepository
{
    private readonly ApplicationDbContext _context;

    public EstudianteRepository(ApplicationDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Estudiante?> GetByMatriculaAsync(string matricula)
    {
        return await _context.Estudiantes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Matricula == matricula);
    }
}