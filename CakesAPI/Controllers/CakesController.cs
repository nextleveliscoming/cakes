using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CakesLibrary;
using Cakes_API.Models;

namespace Cakes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        Kitchen _kitchen;
        Storage _storage;

        public CakesController(IngredientsContext context)
        {
            _storage = new Storage(context);
            _kitchen = new Kitchen(_storage);
        }

        [HttpGet]
        public List<string> GetAvailableRecipes()
        {
            List<string> avCakesList = new List<string>();
            foreach (var r in _kitchen.GetAvailableRecipes().Keys)
            {
                avCakesList.Add(r);
            }

            return avCakesList;
        }

        [HttpGet("{cakeName}")]
        public Cake GetCake(string cakeName)
        {
            return _kitchen.MakeCake(cakeName);
        }
    }
}
