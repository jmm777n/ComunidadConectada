using ComunidadConectada.Models;

namespace ComunidadConectada.Repositories
{
    public interface IParticipanteRepository
    {
        IEnumerable<Participante> GetAll();
        Participante? GetByIdentificacion(string identificacion);
        void Add(Participante participante);
    }
}
