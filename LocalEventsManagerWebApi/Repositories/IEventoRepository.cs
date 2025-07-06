using LocalEventsManagerWebApi.Models;

namespace LocalEventsManagerWebApi.Repositories
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task<Evento> AddAsync(Evento evento);
        Task<bool> UpdateAsync(Evento evento);
        Task<bool> DeleteAsync(int id);
    }
}
