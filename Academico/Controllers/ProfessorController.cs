using Academico.Models;
using Academico.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository repository)
        {
            _professorRepository = repository;
        }

        // LISTA
        public async Task<IActionResult> Index()
        {
            var professores = await _professorRepository.GetAll();
            return View(professores);
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var professor = await _professorRepository.GetById(id);

            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return View(professor);
            }

            await _professorRepository.Create(professor);

            return RedirectToAction(nameof(Index));
        }

        // EDIT (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var professor = await _professorRepository.GetById(id);

            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Professor professor)
        {
            if (id != professor.ProfessorID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(professor);
            }

            await _professorRepository.Edit(professor);

            return RedirectToAction(nameof(Index));
        }

        // DELETE (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var professor = await _professorRepository.GetById(id);

            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _professorRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}