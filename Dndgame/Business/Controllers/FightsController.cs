using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers;

[ApiController]
[Route("[action]")]
public class FightsController : ControllerBase
{
    public record FightStartingModel(CalculatedCharacter Player, CalculatedCharacter Monster);


    public class FightStart
    {
        public Character Player { get; set; }
        public Character Monster { get; set; }
    }
    private class FightResult
    {
        public string Log { get; set; }
    }
    [HttpPost]
    public IActionResult MakeTurn(FightStart fightStart)
    {
        var log = FightsDealer.Fight(fightStart.Player, fightStart.Monster);
        Console.WriteLine(log);
        return new JsonResult(new FightResult {Log = log});
    }
}
