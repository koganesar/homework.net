using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers;

[ApiController]
[Route("[action]")]
public class CharacterController : ControllerBase
{
    [HttpPost]
    public IActionResult CalculateCharacter([FromBody]Character character) => 
        new JsonResult(CharacterCalculator.Calculate(character));
}
