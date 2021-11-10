using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todoListAPI.Data;
using todoListAPI.Data.Dtos.Tarefa;
using todoListAPI.Models;

namespace todoListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TarefasController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaTarefa([FromBody] CreateTarefaDto tarefaDto)
        {
            Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaTarefasPorId), new { Id = tarefa.Id }, tarefa);
        }

        [HttpGet]
        public IEnumerable<Tarefa> RecuperaTarefas()
        {
            return _context.Tarefas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaTarefasPorId(int id)
        {
            Tarefa tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
            if(tarefa != null)
            {
                ReadTarefaDto tarefaDto = _mapper.Map<ReadTarefaDto>(tarefa);
                return Ok(tarefaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaTarefa(int id, [FromBody] UpdateTarefaDto tarefaDto)
        {
            Tarefa tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
            if(tarefa == null)
            {
                return NotFound();
            }
            _mapper.Map(tarefaDto, tarefa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaTarefa(int id)
        {
            Tarefa tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
            if(tarefa == null)
            {
                return NotFound();
            }
            _context.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}