using ComunidadConectada.Models;

namespace ComunidadConectada.Repositories
{
    /// <summary>
    /// Implementación del repositorio en memoria (guarda los datos temporalmente mientras la app está encendida).
    /// </summary>
    public class InMemoryParticipanteRepository : IParticipanteRepository
    {
        // Lista temporal en memoria (no se guarda en base de datos)
        private readonly List<Participante> _data = new();

        // Retorna todos los registros
        public IEnumerable<Participante> GetAll() => _data;

        // Busca un participante por identificación
        public Participante? GetByIdentificacion(string identificacion) =>
            _data.FirstOrDefault(p => p.Identificacion.Equals(identificacion, StringComparison.OrdinalIgnoreCase));

        // Agrega un nuevo participante
        public void Add(Participante participante)
        {
            _data.Add(participante);
        }
    }
}
