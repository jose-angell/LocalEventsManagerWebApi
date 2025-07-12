using System.ComponentModel.DataAnnotations;

namespace LocalEventsManagerWebApi.DTOs
{
    public class EventoResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; }

        public string Descripcion { get; set; }
    }
}
