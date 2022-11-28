
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace FormulaOneApp.Controllers;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class TeamsController : ControllerBase
{
    private List<Team> teams = new List<Team>
    {
        new Team(){
            Country = "Germany", 
            Id = 1, 
            Name = "Mercedes AMG", 
            TeamPrinciple = "Cristian"
        }
    };

     [HttpGet]
     public IActionResult Get()
     {
        return Ok(teams); 
     }

     [HttpGet]
     public IActionResult Get(int id)
     {
        var team = teams.FirstOrDefault(x=>x.Id == id);
        if (team == null)
            return BadRequest("Invalid id");
        return Ok(team);
     }
}