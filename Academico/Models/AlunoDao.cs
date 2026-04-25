using Academico.Models;

namespace Academico.Models
{
    public class AlunoDao
    {
        public AlunoDao()
        {
        }

        private static IList<Aluno> alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Nome = "Pedro",
                Email = "pedro@email.br",
                Telefone = "(21)98765-4321",
                Endereco = "condomínio Barra Bonita",
                Complemento = "Prédio Natural Surf",
                Bairro = "Recreio",
                Municipio = "Rio de Janeiro",
                Uf = "RJ",
                Cep = "21123-456"
            }
        };

        public async Task<Aluno> GravarAluno(Aluno aluno)
        {
            alunos.Add(aluno);
            return aluno;
        }

        public IList<Aluno> ObterTodos()
        {
            return alunos;
        }
    }
}
