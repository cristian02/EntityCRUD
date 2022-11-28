
using Microsoft.AspNetCore.Mvc;
namespace FormulaOneApp.Controllers;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class TeamsController : ControllerBase
{
     [HttpGet]
     public IActionResult Get()
     {
        return Ok(""); 
     }
}