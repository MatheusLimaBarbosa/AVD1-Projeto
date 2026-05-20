using Academico.Models;

namespace Academico.Repositories
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetAll(CancellationToken cancellationToken = default);

        Task<Professor?> GetById(int id, CancellationToken cancellationToken = default);

        Task Create(Professor professor, CancellationToken cancellationToken = default);

        Task Edit(Professor professor, CancellationToken cancellationToken = default);

        Task Delete(int id, CancellationToken cancellationToken = default);

        Task<bool> Exists(int id, CancellationToken cancellationToken = default);
    }
}