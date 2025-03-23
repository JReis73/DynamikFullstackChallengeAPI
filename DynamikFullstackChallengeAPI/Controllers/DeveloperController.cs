using DynamikFullstackChallengeAPI.Data;
using DynamikFullstackChallengeAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Mime;

namespace DynamikFullstackChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly DataContext _context;

        public DeveloperController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("/devs")]
        public async Task<IActionResult> AddDeveloper(Developer developer)
        {
            Developer existingDev = await _context.Developers.Where(X => X.Name == developer.Name).FirstOrDefaultAsync();
            
            if (existingDev == null && developer.NickName != null && developer.Name != null)
            {
                //Poderíamos utilizar um dto de forma a pedir apenas os campos necessários
                //O Id, ou um DateCreate, são exemplos de campos não necessários
                _context.Developers.Add(developer);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDeveloperById), new { id = developer.Id }, developer); //falta guid
                //return new ObjectResult(developer) { StatusCode = StatusCodes.Status201Created };
            }
            else
            {
                return UnprocessableEntity(developer);
            }
        }

        [HttpGet("/devs")]
        public async Task<ActionResult<List<Developer>>> GetAllDevelopers()
        {
            var developers = await _context.Developers.Include(X => X.Stacks).Take(20).ToListAsync(); //Top 20

            Response.Headers.Add("Total-de-registos", developers.Count.ToString());

            return Ok(developers);
        }

        [HttpGet]
        [Route("/dev/{id}")]
        public async Task<ActionResult<Developer>> GetDeveloperById([FromRoute] int id)
        {
            //O ideal seria ter uma tabela intermédia (n-n) para interligar os devs com as stacks

            var developer = await _context.Developers.Include(X => X.Stacks).FirstOrDefaultAsync(X => X.Id == id);

            //Abordagem LINQ

            //var developer = await _context.Developers
            //    .Where(X => X.Id == id)
            //    .Select(Y => new
            //    {
            //        Y.Id,
            //        Y.Name,
            //        Stacks = _context.Stacks.Where(X => X.DeveloperId == Y.Id).ToList()
            //    }).FirstOrDefaultAsync();

            if (developer is null)
                return NotFound();

            return Ok(developer);
        }

        [HttpGet]
        [Route("/search")]
        public async Task<ActionResult<List<Developer>>> SearchDevByTerm([FromQuery] string terms)
        {
            var developers = await _context.Developers
                .Where(X => X.Name.Contains(terms) || X.NickName.Contains(terms) ||
                    X.Stacks.Any(Y => Y.Name.Contains(terms)))
                .Include(X => X.Stacks)
                .Take(20)
                .ToListAsync();

            return Ok(developers);
        }
    }
}
