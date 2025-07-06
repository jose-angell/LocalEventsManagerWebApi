using System.ComponentModel.DataAnnotations;

namespace LocalEventsManagerWebApi.DTOs
{
    public class EventoDto
    {
        [Required, StringLength(100, MinimumLength = 5)]
        public string Titulo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [StringLength(200)]
        public string Ubicacion { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }
    }
}
