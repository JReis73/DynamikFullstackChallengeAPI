using DynamikFullstackChallengeAPI.Data;
using DynamikFullstackChallengeAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<Developer>> AddDeveloper(Developer developer)
        {
            //Poderíamos utilizar um dto de forma a pedir apenas os campos necessários
            //O Id, ou um DateCreate, são exemplos de campos não necessários
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();

            return Ok(await GetAllDevelopers());
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Developer>>> GetAllDevelopers()
        {
            var developers = await _context.Developers.ToListAsync();

            return Ok(developers);
        }

        [HttpGet]
        [Route("api/devs/{Id}")]
        public async Task<ActionResult<Developer>> GetDeveloper([FromRoute] int id)
        {
            var developer = await _context.Developers.FirstOrDefaultAsync(X => X.Id == id);
            if (developer is null)
                return NotFound("Developer not found.");

            return Ok(developer);
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<List<Developer>>> SearchDevByTerm([FromQuery] string term = "")
        {
            var developers = await _context.Developers.Where(X => X.Stack.Contains(term)).ToListAsync();

            if (developers.Count == 0)
                return NotFound("There are no developers with the terms specified.");

            return Ok(developers);
        }
    }
}
