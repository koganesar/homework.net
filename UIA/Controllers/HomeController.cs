using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UIA.Models;

namespace UIA.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        public HomeController()
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
            _client = new HttpClient(clientHandler);
        }


        public IActionResult Index() =>
            View();

        private record FightStartingModel(Character Player, Character Monster);

        public class FightModel
        {
            public CalculatedCharacter Player { get; set; }
            public CalculatedCharacter Monster { get; set; }
            public string Log { get; set; }
        }
        private class FightResult
        {
            public string Log { get; set; }
        }
        [HttpPost]
        public async Task<IActionResult> Fight(Character player)
        {
            var t = (await _client.GetAsync("https://localhost:5001/GetRandomMonster")).Content;
            var monster = await t.ReadFromJsonAsync<Character>();
            t = (await _client.PostAsync("https://localhost:7299/CalculateCharacter", JsonContent.Create(monster)))
                .Content;
            var calculatedMonster = await t.ReadFromJsonAsync<CalculatedCharacter>();
            t = (await _client.PostAsync("https://localhost:7299/CalculateCharacter", JsonContent.Create(player)))
                .Content;
            var calculatedPlayer = await t.ReadFromJsonAsync<CalculatedCharacter>();
            t = (await _client.PostAsync("https://localhost:7299/MakeTurn",
                JsonContent.Create(new FightStartingModel(calculatedPlayer, calculatedMonster)))).Content;
            Console.WriteLine(await t.ReadAsStringAsync());
            var log = (await t.ReadFromJsonAsync<FightResult>())!.Log;
            return View(new FightModel
            {
                Player = calculatedPlayer,
                Monster = calculatedMonster,
                Log = log
            });
        }
    }
}
