using System.ComponentModel.DataAnnotations;

namespace LocalEventsManagerWebApi.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El título debe tener entre 5 y 100 careacteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "La fecha debe ser una fecha válida.")]
        public DateTime Fecha { get; set; }

        [StringLength(200, ErrorMessage = "La ubicación no puede superar los 200 caracteres.")]
        public string? Ubicacion { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracters.")]
        public string? Descripcion { get; set; } 
    }
}
