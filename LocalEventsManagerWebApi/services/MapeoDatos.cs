using LocalEventsManagerWebApi.DTOs;
using LocalEventsManagerWebApi.Models;

namespace LocalEventsManagerWebApi.services
{
    public static class MapeoDatos
    {
        public static Evento MapeoDtoToModel(EventoDto eventoDto)
        {
            return new Evento
            {
                Titulo = eventoDto.Titulo,
                Fecha = eventoDto.Fecha,
                Ubicacion = eventoDto.Ubicacion,
                Descripcion = eventoDto.Descripcion
            };
        }
        public static EventoResponseDto MapeoModelToResponseDto(Evento evento)
        {
            return new EventoResponseDto
            {
                Id = evento.Id,
                Titulo = evento.Titulo,
                Fecha = evento.Fecha,
                Ubicacion = evento.Ubicacion,
                Descripcion = evento.Descripcion
            };
        }
    }
}
