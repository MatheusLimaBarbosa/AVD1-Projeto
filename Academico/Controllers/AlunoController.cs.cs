using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno()
            {
                AlunoID = 1,
                Nome = "Aluno Teste",
                Email = "aluno@mail.com",
                Telefone = "(99)99999-9999",
                Endereco = "Rua X, numero 1000",
                Complemento = "apto 1001",
                Bairro = "Bairro do Aluno",
                Municipio = "Cidade do Aluno",
                Uf = "RJ",
                Cep = "27100-000"
            }
        };

        // LISTA
        public IActionResult Index()
        {
            return View(alunos);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);

                if (aluno == null)
                {
                    return NotFound();
                }

                alunos.Remove(aluno);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Não foi possível excluir o aluno: {ex.Message}");
            }

            return View(alunos);
        }
        public IActionResult Details(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }
        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            try
            {
                if (true)
                {
                    aluno.AlunoID = alunos
                        .Select(a => a.AlunoID)
                        .DefaultIfEmpty(0)
                        .Max() + 1;

                    alunos.Add(aluno);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
            }

            return View(aluno);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AlunoID,Nome,Email,Telefone,Endereco,Complemento,Bairro,Municipio,Uf,Cep")] Aluno aluno)
        {
            try
            {
                if (id != aluno.AlunoID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var existingAluno = alunos.FirstOrDefault(a => a.AlunoID == id);

                    if (existingAluno == null)
                    {
                        return NotFound();
                    }

                    existingAluno.Nome = aluno.Nome;
                    existingAluno.Email = aluno.Email;
                    existingAluno.Telefone = aluno.Telefone;
                    existingAluno.Endereco = aluno.Endereco;
                    existingAluno.Complemento = aluno.Complemento;
                    existingAluno.Bairro = aluno.Bairro;
                    existingAluno.Municipio = aluno.Municipio;
                    existingAluno.Uf = aluno.Uf;
                    existingAluno.Cep = aluno.Cep;

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Erro ao editar: {ex.Message}");
            }

            return View(aluno);
        }
    }
}