using ComunidadConectada.Models;
using ComunidadConectada.Repositories;
using System.ComponentModel.DataAnnotations;

namespace ComunidadConectada.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteRepository _repo;

        public ParticipanteService(IParticipanteRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Participante> Listar() => _repo.GetAll();

        public OperationResult Registrar(Participante participante)
        {
            participante.Normalizar();

            // Validación DataAnnotations
            var ctx = new ValidationContext(participante);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(participante, ctx, results, true))
                return OperationResult.Fail(results.Select(r => r.ErrorMessage ?? "Dato inválido").ToArray());

            // Regla de negocio: identificación única
            if (_repo.GetByIdentificacion(participante.Identificacion) is not null)
                return OperationResult.Fail("Ya existe un participante con esa identificación.");

            // Regla extra ilustrativa
            if (participante.Edad is < 0)
                return OperationResult.Fail("La edad no puede ser negativa.");

            _repo.Add(participante);
            return OperationResult.Ok();
        }
    }
}
