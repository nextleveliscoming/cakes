using System.Security.Cryptography.X509Certificates;

namespace CakesAdvanced
{
    public class Workshop
    {
        // Поле для списка всех рецептов
        Dictionary<string, Dictionary<string, int>> _recipes = new Dictionary<string, Dictionary<string, int>>();

        // Метод, который возвращает _recipes – список всех рецептов
        public Dictionary<string, Dictionary<string, int>> GetAllRecipes()
        {

            // Возвращаем общий список
            return _recipes;
        }


        public Workshop()
        {

            // Торт Медовик с ингредиентами
            string medovik = "медовик";

            var ingredientsMedovik = new Dictionary<string, int>()
            {
                { "мука", 150 },
                { "яйца", 2 },
                { "масло сливочное", 50 },
                { "сахар", 200 }
            };

            // Торт Наполеон с ингредиентами
            string napoleon = "наполеон";

            var ingredientsNapoleon = new Dictionary<string, int>()
            {
                { "мука", 100 },
                { "молоко", 1 },
                { "ванилин", 20 }
            };

            // Добавляем рецепты в общий список
            _recipes.Add(medovik, ingredientsMedovik);
            _recipes.Add(napoleon, ingredientsNapoleon);


        }

        // the end of the code
    }
}
