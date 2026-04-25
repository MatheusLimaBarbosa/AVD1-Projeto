using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Academico.Controllers
{
    public class AcademicoController : Controller
    {
        private readonly AlunoDao alunoDao = new AlunoDao();

        // GET: /Academico/Aluno
        public IActionResult Aluno()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Aluno([Bind("Nome,Email,Telefone,Endereco,Complemento,Bairro,Municipio,Uf,Cep")] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await alunoDao.GravarAluno(aluno);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados. " + e.Message);
            }

            return View(aluno);
        }

        public IActionResult Index()
        {
            return View(alunoDao.ObterTodos());
        }
    }
}