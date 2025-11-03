using ComunidadConectada.Models;

namespace ComunidadConectada.Services
{
    /// <summary>
    /// Representa el resultado de una operación (éxito o errores).
    /// </summary>
    public class OperationResult
    {
        public bool Success { get; private set; }
        public List<string> Errors { get; } = new();

        public static OperationResult Ok() => new OperationResult { Success = true };

        public static OperationResult Fail(params string[] errors)
        {
            var r = new OperationResult { Success = false };
            r.Errors.AddRange(errors);
            return r;
        }
    }

    /// <summary>
    /// Contrato del servicio de dominio para gestionar participantes.
    /// </summary>
    public interface IParticipanteService
    {
        IEnumerable<Participante> Listar();
        OperationResult Registrar(Participante participante);
    }
}
