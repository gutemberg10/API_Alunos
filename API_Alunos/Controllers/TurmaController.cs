using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase {

        private readonly AppDbContext _context;
        public TurmaController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TurmaModel>> Get() {
            var turmas = _context.Turmas.ToList();
            if (turmas is null) {
                return NotFound();
            }
            return Ok(turmas);
        }

        [HttpGet("{id:int}", Name = "ObterTurma")]
        public ActionResult<TurmaModel> Get(int id) {
            var turma = _context.Turmas.FirstOrDefault(p => p.TurmaId == id);
            if (turma is null) {
                return NotFound("Turma não encontrado...");
            }
            return turma;
        }

        [HttpPost]
        public ActionResult Post(TurmaModel turma) {
            if (turma is null)
                return BadRequest();

            _context.Turmas.Add(turma);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterTurma",
                new { id = turma.TurmaId }, turma);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, TurmaModel turma) {
            if (id != turma.TurmaId) {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(turma);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            var turma = _context.Turmas.FirstOrDefault(p => p.TurmaId == id);
            //var turma = _context.Turmas.Find(id);            

            if (turma is null) {
                return NotFound("Turma não localizado...");
            }
            _context.Turmas.Remove(turma);
            _context.SaveChanges();

            return Ok(turma);
        }
    }
}
