using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFExercise.Models;

namespace EFExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FighterController : ControllerBase
    {
        private readonly FighterDbContext _context;

	public FighterController(FighterDbContext context)
	{
	    _context = context;
	}

        // GET: /api/fighter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fighter>>> GetFighters()
        {
	    return await _context.Fighters.ToListAsync();
        }

        // GET: /api/fighter/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Fighter>> GetFighter(int id)
        {
	    var fighter = await _context.Fighters.FindAsync(id);
	    if (fighter == null)
	    {
	        return NotFound();
	    }
	    return fighter;
        }

	// POST: /api/fighter
	[HttpPost]
	public async Task<ActionResult<Fighter>> PostFighter(Fighter fighter)
	{
	    _context.Fighters.Add(fighter);
	    await _context.SaveChangesAsync();

	    return CreatedAtAction("GetFighter", new { id = fighter.Id }, fighter);
	}

        // PUT: /api/fighters/3
        [HttpPut("{id}")]
        public async Task<ActionResult<Fighter>> PutFighter(int id, Fighter fighter)
        {
	    if (id != fighter.Id)
	    {
	        return BadRequest();
	    }

	    _context.Entry(fighter).State = EntityState.Modified;
	    await _context.SaveChangesAsync();

	    return NoContent();
        }

        // DELETE: api/fighters/3
        [HttpDelete("{id}")]
	public async Task<IActionResult> DeleteFighter (int id)
	{
            var fighter = await _context.Fighters.FindAsync(id);
	    if (fighter == null)
	    {
		return NotFound();
	    }

	    _context.Fighters.Remove(fighter);

	    await _context.SaveChangesAsync();

	    return NoContent();
	}

    }
}

