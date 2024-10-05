using CakesLibrary;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace CakesLibrary
{
    public class Kitchen
    {
        private Storage _storage;

        private Workshop _workshop;

        public Kitchen(Storage storage)
        {
            _storage = storage;

            _workshop = new Workshop();
        }

        public Dictionary<string, Dictionary<string, int>> GetAvailableRecipes()
        {
            var availableRecipes = new Dictionary<string, Dictionary<string, int>>();

            var allRecipes = _workshop.GetAllRecipes();

            foreach (string recipeName in allRecipes.Keys)
            {
                try
                {
                    _storage.VerifyIngredientsAvailability(allRecipes[recipeName]);
                    availableRecipes.Add(recipeName, allRecipes[recipeName]);
                }
                catch
                {
                    Debug.WriteLine($"{recipeName} недоступен!");
                }
            }

            return availableRecipes;
        }

        public event Action<Cake> CakeReady;
        public async void MakeCake(string cakeName)
        {
            var availableRecipes = GetAvailableRecipes();

            bool canCook = availableRecipes.ContainsKey(cakeName.ToLower());

            if (!canCook)
            {
                throw new Exception("Не могу приготовить");
            }

            var requiredIngredients = availableRecipes[cakeName];

            var takenIngredient = _storage.TakeIngredients(requiredIngredients);

            Cake cake = new Cake(cakeName, takenIngredient);

            await Task.Delay(5000);

            CakeReady?.Invoke(cake);

        }


    }
}
