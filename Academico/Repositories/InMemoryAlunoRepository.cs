using Academico.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Academico.Repositories
{
    public class InMemoryAlunoRepository : IAlunoRepository
    {
        private readonly List<Aluno> _alunos = new List<Aluno>();
        private int _nextId = 1;
        private readonly object _lock = new object();

        public InMemoryAlunoRepository()
        {
            // Dado inicial (seed)
            _alunos.Add(new Aluno
            {
                AlunoID = _nextId++,
                Nome = "Aluno Exemplo",
                Email = "aluno@exemplo.com",
                Telefone = "(11) 99999-9999",
                Endereco = "Rua Exemplo, 123",
                Complemento = "Bloco A",
                Bairro = "Centro",
                Municipio = "Cidade",
                Uf = "SP",
                Cep = "01234-567"
            });
        }

        public Task<IEnumerable<Aluno>> GetAll(CancellationToken cancellationToken = default)
        {
            IEnumerable<Aluno> result;
            lock (_lock)
            {
                result = _alunos.ToList();
            }

            return Task.FromResult(result);
        }

        public Task<Aluno?> GetById(int id, CancellationToken cancellationToken = default)
        {
            Aluno? aluno;
            lock (_lock)
            {
                aluno = _alunos.FirstOrDefault(a => a.AlunoID == id);
            }

            return Task.FromResult(aluno);
        }

        public Task Create(Aluno aluno, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                aluno.AlunoID = _nextId++;
                _alunos.Add(aluno);
            }

            return Task.CompletedTask;
        }

        public Task Edit(Aluno aluno, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                var existing = _alunos.FirstOrDefault(a => a.AlunoID == aluno.AlunoID);
                if (existing != null)
                {
                    existing.Nome = aluno.Nome;
                    existing.Email = aluno.Email;
                    existing.Telefone = aluno.Telefone;
                    existing.Endereco = aluno.Endereco;
                    existing.Complemento = aluno.Complemento;
                    existing.Bairro = aluno.Bairro;
                    existing.Municipio = aluno.Municipio;
                    existing.Uf = aluno.Uf;
                    existing.Cep = aluno.Cep;
                }
            }

            return Task.CompletedTask;
        }

        public Task Delete(int id, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                var existing = _alunos.FirstOrDefault(a => a.AlunoID == id);
                if (existing != null)
                {
                    _alunos.Remove(existing);
                }
            }

            return Task.CompletedTask;
        }

        public Task<bool> Exists(int id, CancellationToken cancellationToken = default)
        {
            bool exists;
            lock (_lock)
            {
                exists = _alunos.Any(a => a.AlunoID == id);
            }

            return Task.FromResult(exists);
        }
    }
}