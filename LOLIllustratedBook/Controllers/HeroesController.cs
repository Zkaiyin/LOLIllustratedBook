/* Controllers/HeroesController.cs */
using Microsoft.AspNetCore.Mvc;
using LOLIllustratedBook.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LOLIllustratedBook.Controllers
{
    public class HeroesController : Controller
    {
        private readonly HttpClient _httpClient;

        public HeroesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var response = await _httpClient.GetStringAsync("https://ddragon.leagueoflegends.com/cdn/10.22.1/data/zh_TW/champion.json");
            var data = JsonConvert.DeserializeObject<HeroResponse>(response);
            var heroes = data.Data.Values.ToList();

            int pageSize = 10;
            var pagedHeroes = heroes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.TotalPages = (int)Math.Ceiling(heroes.Count / (double)pageSize);
            ViewBag.CurrentPage = page;

            foreach (var hero in pagedHeroes)
            {
                hero.ImageUrl = $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{hero.Id}_0.jpg";
                hero.SpriteUrl = $"https://ddragon.leagueoflegends.com/cdn/10.22.1/img/sprite/{hero.Image.Sprite}";
                hero.AdditionalImageUrls = new List<string>
                {
                    $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{hero.Id}_1.jpg",
                    $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{hero.Id}_2.jpg"
                };
            }

            return View(pagedHeroes);
        }

        public async Task<IActionResult> Details(string id)
        {
            var response = await _httpClient.GetStringAsync($"https://ddragon.leagueoflegends.com/cdn/10.22.1/data/zh_TW/champion/{id}.json");
            var data = JsonConvert.DeserializeObject<HeroResponse>(response);
            var hero = data.Data[id];

            hero.ImageUrl = $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{id}_0.jpg";
            hero.SpriteUrl = $"https://ddragon.leagueoflegends.com/cdn/10.22.1/img/sprite/{hero.Image.Sprite}";
            hero.AdditionalImageUrls = new List<string>
            {
                $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{hero.Id}_1.jpg",
                $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{hero.Id}_2.jpg",
                $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{id}_3.jpg"
            };

            return View(hero);
        }

        [HttpPost]
        public IActionResult ShowSearchFields()
        {
            ViewBag.ShowSearchFields = true;
            return RedirectToAction("Index");
        }
    }
}
