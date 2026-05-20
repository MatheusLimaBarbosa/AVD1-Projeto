using Academico.Models;

namespace Academico.Repositories
{
    public class InMemoryProfessorRepository : IProfessorRepository
    {
        private readonly List<Professor> _professores = new List<Professor>();
        private int _nextId = 1;
        private readonly object _lock = new object();

        public InMemoryProfessorRepository()
        {
            // SEED OPCIONAL
            _professores.Add(new Professor
            {
                ProfessorID = _nextId++,
                Nome = "Professor Exemplo",
                DataNascimento = new DateTime(1980, 1, 1),
                Titulacao = "Mestre",
                Cep = "27100-000",
                Endereco = "Rua Exemplo",
                Complemento = "Casa",
                Bairro = "Centro",
                Municipio = "Resende",
                Uf = "RJ"
            });
        }

        public Task<IEnumerable<Professor>> GetAll(CancellationToken cancellationToken = default)
        {
            IEnumerable<Professor> result;

            lock (_lock)
            {
                result = _professores.Select(p => p).ToList();
            }

            return Task.FromResult(result);
        }

        public Task<Professor?> GetById(int id, CancellationToken cancellationToken = default)
        {
            Professor? professor;

            lock (_lock)
            {
                professor = _professores.FirstOrDefault(p => p.ProfessorID == id);
            }

            return Task.FromResult(professor);
        }

        public Task Create(Professor professor, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                professor.ProfessorID = _nextId++;
                _professores.Add(professor);
            }

            return Task.CompletedTask;
        }

        public Task Edit(Professor professor, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                var existing = _professores.FirstOrDefault(p => p.ProfessorID == professor.ProfessorID);

                if (existing != null)
                {
                    existing.Nome = professor.Nome;
                    existing.DataNascimento = professor.DataNascimento;
                    existing.Titulacao = professor.Titulacao;
                    existing.Cep = professor.Cep;
                    existing.Endereco = professor.Endereco;
                    existing.Complemento = professor.Complemento;
                    existing.Bairro = professor.Bairro;
                    existing.Municipio = professor.Municipio;
                    existing.Uf = professor.Uf;
                }
            }

            return Task.CompletedTask;
        }

        public Task Delete(int id, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                var professor = _professores.FirstOrDefault(p => p.ProfessorID == id);

                if (professor != null)
                {
                    _professores.Remove(professor);
                }
            }

            return Task.CompletedTask;
        }

        public Task<bool> Exists(int id, CancellationToken cancellationToken = default)
        {
            bool exists;

            lock (_lock)
            {
                exists = _professores.Any(p => p.ProfessorID == id);
            }

            return Task.FromResult(exists);
        }
    }
}