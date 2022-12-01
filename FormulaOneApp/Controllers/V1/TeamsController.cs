
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace FormulaOneApp.Controllers.V1;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0", Deprecated = true)]
public class TeamsController : ControllerBase
{
    private List<Team> teams = new List<Team>
    {
        new Team(){
            Country = "Germany", 
            Id = 1, 
            Name = "Mercedes AMG", 
            TeamPrinciple = "Cristian"
        }, 
        new Team(){
            Country ="Italy", 
            Id = 2, 
            Name = "Ferrari", 
            TeamPrinciple = "Juan Prueba"
        }
    };

     [HttpGet]
     [MapToApiVersion("1.0")]
     public IActionResult Get()
     {
        return Ok(teams); 
     }

     [HttpGet("{id:int}")]
     [MapToApiVersion("1.0")]
     public IActionResult Get(int id)
     {
        var team = teams.FirstOrDefault(x=>x.Id == id);
        if (team == null)
            return BadRequest("Invalid id");
        return Ok(team);
     }
}