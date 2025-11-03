using ComunidadConectada.Models;
using ComunidadConectada.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComunidadConectada.Controllers
{
    public class ParticipantesController : Controller
    {
        private readonly IParticipanteService _service;

        public ParticipantesController(IParticipanteService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var lista = _service.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View(new Participante());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Participante participante)
        {
            var result = _service.Registrar(participante);

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    ModelState.AddModelError(string.Empty, err);

                return View(participante);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
