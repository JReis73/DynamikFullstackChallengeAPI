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

        [HttpPost]
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

        [HttpGet("")]
        public async Task<ActionResult<List<Developer>>> GetAllDevelopers()
        {
            var developers = await _context.Developers.Take(20).ToListAsync(); //Top 20

            Response.Headers.Add("Total-de-registos", developers.Count.ToString());

            return Ok(developers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloperById([FromRoute] int id)
        {
            var developer = await _context.Developers.FirstOrDefaultAsync(X => X.Id == id);

            if (developer is null)
                return NotFound();

            return Ok(developer);
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<List<Developer>>> SearchDevByTerm(string term = "")
        {
            var developers = await _context.Developers.Where(X => X.Stack.Contains(term)).ToListAsync();

            if (developers.Count == 0)
                return NotFound("There are no developers with the terms specified.");

            return Ok(developers);
        }
    }
}
