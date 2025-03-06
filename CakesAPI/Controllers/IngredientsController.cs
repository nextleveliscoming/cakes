using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cakes_API.Models;
using CakesLibrary;

namespace Cakes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private Storage _storage;
        private readonly IngredientsContext _context;

        public IngredientsController(IngredientsContext context)
        {
            _context = context;
            _storage = new Storage(_context);
        }

        // GET: api/Ingredients
        [HttpGet]
        public List<Ingredient> GetIngredients()
        {
            return _storage.GetAllIngredients();
        }
        
        // POST: api/Ingredients
        [HttpPost]
        public List<Ingredient> PostIngredient(Ingredient ingredient)
        {
            _storage.AddIngredient(ingredient);
            return _storage.GetAllIngredients();
        }

    }
}
