
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace FormulaOneApp.Controllers.V2;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
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
        }, 
        new Team(){
            Country ="Italy", 
            Id = 2, 
            Name = "Ferrari", 
            TeamPrinciple = "Juan Prueba112"
        }
    };

     [HttpGet]
     [MapToApiVersion("2.0")]
     public IActionResult Get()
     {
        return Ok(teams); 
     }

     [HttpGet("{id:int}")]
     [MapToApiVersion("2.0")]
     public IActionResult Get(int id)
     {
        var team = teams.FirstOrDefault(x=>x.Id == id);
        if (team == null)
            return BadRequest("Invalid id");
        return Ok(team);
     }

     [HttpGet("{id:int}/{id2:int}")]
     [MapToApiVersion("2.0")]
     public IActionResult Get(int id, int id2)
     {
        var team = teams.FirstOrDefault(x=>x.Id == id);
        if (team == null)
            return BadRequest("Invalid id");
        return Ok(team);
     }
}