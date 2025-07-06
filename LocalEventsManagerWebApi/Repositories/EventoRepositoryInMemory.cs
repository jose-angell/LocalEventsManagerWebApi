using LocalEventsManagerWebApi.Models;

namespace LocalEventsManagerWebApi.Repositories
{
    public class EventoRepositoryInMemory : IEventoRepository
    {
        private static List<Evento> eventos = new List<Evento>
        {
            new Evento { Id = 1, Titulo = "Concierto de Rock", Fecha = new DateTime(2023, 10, 15), Ubicacion = "Estadio Municipal", Descripcion = "Un gran concierto de rock con bandas locales." },
            new Evento { Id = 2, Titulo = "Feria de Artesanía", Fecha = new DateTime(2023, 11, 5), Ubicacion = "Plaza Central", Descripcion = "Feria con artesanos locales y productos únicos." },
            new Evento { Id = 3, Titulo = "Festival Gastronómico", Fecha = new DateTime(2023, 12, 20), Ubicacion = "Parque de la Ciudad", Descripcion = "Disfruta de la mejor comida local y música en vivo." }
        };
        public static int NextId = 4;
        public Task<IEnumerable<Evento>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Evento>>(eventos);
        }
        public Task<Evento?> GetByIdAsync(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(evento);
        }
        public Task<Evento> AddAsync(Evento evento)
        {
            evento.Id = NextId++;
            eventos.Add(evento);
            return Task.FromResult(evento);
        }

        public Task<bool> UpdateAsync(Evento evento)
        {
            var existingEvento = eventos.FirstOrDefault(e => e.Id == evento.Id);
            if(existingEvento == null)
            {
                return Task.FromResult(false);
            }
            existingEvento.Titulo = evento.Titulo;
            existingEvento.Fecha = evento.Fecha;
            existingEvento.Ubicacion = evento.Ubicacion;
            existingEvento.Descripcion = evento.Descripcion;
            return Task.FromResult(true);
        }
        public Task<bool> DeleteAsync(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.Id == id);
            if (evento == null)
            {
                return Task.FromResult(false);
            }
            eventos.Remove(evento);
            return Task.FromResult(true);
        }
    }
}
