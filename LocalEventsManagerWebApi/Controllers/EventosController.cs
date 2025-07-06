using LocalEventsManagerWebApi.Models;
using LocalEventsManagerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LocalEventsManagerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        private readonly IEventoRepository _evento;
        public EventosController(IEventoRepository evento)
        {
            _evento = evento;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _evento.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _evento.GetByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdEvento = await _evento.AddAsync(evento);
            return CreatedAtAction(nameof(GetById), new { id= createdEvento.Id}, createdEvento);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Evento evento)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id <= 0)
            {
                return BadRequest("El id es invalido");
            }
            evento.Id = id;
            var existingEvento = await _evento.UpdateAsync(evento);
            if (!existingEvento)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id es invalido");
            }
            var deleted = await _evento.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
