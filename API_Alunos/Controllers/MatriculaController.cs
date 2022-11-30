using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MatriculaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MatriculaModel>> Get()
        {
            var matriculas = _context.Matriculas.ToList();
            if (matriculas is null)
            {
                return NotFound();
            }
            return matriculas;
        }

        [HttpGet("{id:int}", Name = "ObterMatricula")]
        public ActionResult<MatriculaModel> Get(int id)
        {
            var matricula = _context.Matriculas.FirstOrDefault(p => p.MatriculaId == id);
            if (matricula is null)
            {
                return NotFound("Matricula não encontrada...");
            }
            return matricula;
        }

        [HttpPost]
        public ActionResult Post(MatriculaModel matricula)
        {
            if (matricula is null)
                return BadRequest();

            _context.Matriculas.Add(matricula);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterMatricula",
                new { id = matricula.MatriculaId }, matricula);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var matricula = _context.Matriculas.FirstOrDefault(p => p.MatriculaId == id);
            //var matricula = _context.Matriculas.Find(id);            

            if (matricula is null)
            {
                return NotFound("Matricula não localizada...");
            }
            _context.Matriculas.Remove(matricula);
            _context.SaveChanges();

            return Ok(matricula);
        }

    }
}
