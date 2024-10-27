using Microsoft.AspNetCore.Mvc;
using EntityFramework_CRUD.Context;
using EntityFramework_CRUD.Entities;

namespace EntityFramework_CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext agendaContext)
        {
            _context = agendaContext;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();

            return Ok(contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contatoBanco = _context.contatos.Find(id);
            
            if(contatoBanco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(contatoBanco);
            }
        }

        [HttpPut]
        public IActionResult AtualizarContato(int id, Contato contato)
        {
            var contatoBanco = _context.contatos.Find(id);

            if(contatoBanco == null)
            {
                return NotFound();
            }
            else
            {
                contatoBanco.Nome = contato.Nome;
                contatoBanco.Telefone = contato.Telefone;
                contatoBanco.Ativos = contato.Ativos;

                _context.contatos.Update(contatoBanco);

                return Ok(contato);
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var contatoBanco = _context.contatos.Find(id);

            if(contatoBanco == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(id);

                _context.SaveChanges();
                return Ok(contatoBanco);
            }
        }
    }
}