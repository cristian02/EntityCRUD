
using FormulaOneApp.Data;
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneApp.Controllers.V1;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0", Deprecated = true)]
public class TeamsController : ControllerBase
{
    private static AppDbContext _context;

    public TeamsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get()
    {
        var teams = await _context.Teams.ToListAsync();
        return Ok(teams);
    }

    [HttpGet("{id:int}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
        if (team == null)
            return BadRequest("Invalid id");
        return Ok(team);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", team.Id, team);
    }

    [HttpPatch]
    public async Task<IActionResult> Patch(int id, string country)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
        if (team == null)
            return BadRequest("Invalid id");
        team.Country = country;
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
        if (team == null)
            return BadRequest("Invalid id");
        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}