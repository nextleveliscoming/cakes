using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using CakesWPF;

namespace CakesLibrary
{

    // Класс Storage, который будет управлять хранением, добавлением и поиском ингредиентов
    public class Storage
    {

        // 1. Приватный список ингредиентов, где хранятся все ингредиенты на складе
        private List<Ingredient> _allIngredients = new List<Ingredient>();


        // Формирование пути к файлу Ingredients.db
        string path = Directory.GetCurrentDirectory() + @"\Ingredients.db";

        // 2. Сохранение текущего списка ингредиентов в файл
        void SaveIngredients()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                foreach (Ingredient ingredient in _allIngredients)
                {
                    db.Ingredients.Add(ingredient);
                }
                db.SaveChanges();
            }
        }

        // 3. Метод выгружает ингредиенты из файла
        public void LoadIngredients()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                _allIngredients = db.Ingredients.ToList();
            }
        }


        /* 4. Вызываем метод LoadIngredients() внутри конструктора,
        для того чтобы считать данные о ранее сохраненных ингредиентах
        при создании объекта Storage */

        public Storage()
        {
            LoadIngredients();
        }


        /* 5. Метод ищет ингредиент по названию.
        Возвращает найденный ингредиент или null,
        если таковой не найден */
        Ingredient? FindIngredientByName(string userInputedIngredient)
        {

            var foundIngredient = _allIngredients.Find(ingredient => ingredient.Name.ToLower() == userInputedIngredient.ToLower());

            if (foundIngredient == null)
            {
                return null;
            }

            return foundIngredient;

        }

        /* 6. Метод возвращает ингредиент по названию.
        Вызывает ошибку, если ингредиент не найден. */
        Ingredient GetIngredientByName(string userInputedIngredient)
        {
            try
            {
                var foundIngredient = _allIngredients.First(ingredient => ingredient.Name.ToLower() == userInputedIngredient.ToLower());
                return foundIngredient;
            }
            catch
            {
                throw new Exception($"Ошибка! Ингредиент {userInputedIngredient} не найден.");
            }
        }

        /* 7. Метод добавляет один ингредиент на склад.
        Если ингредиент уже есть на складе, увеличивает его количество.
        После добавления, сохраняет текущее состояние склада в файл. */
        public void AddIngredient(Ingredient ingredient)
        {

            Ingredient? existingIngredient = FindIngredientByName(ingredient.Name);

            if (existingIngredient == null)
            {
                _allIngredients.Add(ingredient);
            }
            else
            {
                existingIngredient.Quantity += ingredient.Quantity;
            }

            // Сохранение изменений
            SaveIngredients();

        }

        /* 8. Метод позволяет добавить список ингредиентов на склад.
        Для каждого ингредиента в списке вызывается
        метод AddIngredient(Ingredient). */

        public void AddIngredients(List<Ingredient> ingredients)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                AddIngredient(ingredients[i]);
            }
        }


        // Завершение создания склада

        /* Проверяем, что все необходимые ингредиенты
        доступны на складе в требуемом количестве. */

        public void VerifyIngredientsAvailability(Dictionary<string, int> neededIngredients)
        {
            // Перебор всех элементов в neededIngredients
            foreach (var neededIngredient in neededIngredients)
            {
                // Создаем переменную для наглядности
                var foundIngredient = FindIngredientByName(neededIngredient.Key);

                if (foundIngredient == null)
                {
                    throw new Exception($"Ошибка! Ингредиент \"{neededIngredient.Key}\" не найден!");
                }
                else if (foundIngredient.Quantity < neededIngredient.Value)
                {
                    throw new Exception($"Ошибка! Ингредиент \"{neededIngredient.Key}\" найден, но его количества недостаточно.");
                }
            }
        }

        /* Берём необходимые ингредиенты со склада,
         * обновляем их количество и возвращаем список
         * взятых ингредиентов. */

        public List<Ingredient> TakeIngredients(Dictionary<string, int> neededIngredients)
        {
            // Вызываем метод для проверки наличия всех требуемых ингредиентов.
            VerifyIngredientsAvailability(neededIngredients);

            // Пустой список
            List<Ingredient> ingredientsToReturn = new List<Ingredient>();

            // Перебор всех элементов в neededIngredients
            foreach (var neededIngredient in neededIngredients)
            {
                // Вызываем метод, чтобы получить ингредиент со склада
                var foundIngredient = GetIngredientByName(neededIngredient.Key);

                // Получаем индекс ингредиента со всей коллекции (со всего склада)
                int indexOfIngredient = _allIngredients.IndexOf(foundIngredient);

                // Уменьшаем количество этого ингредиента на требуемое значение
                _allIngredients[indexOfIngredient].Quantity -= neededIngredient.Value;

                // Объект с названием, требуемым количеством и стоимостью
                Ingredient ingredientToReturn = new Ingredient();
                ingredientToReturn.Quantity = neededIngredient.Value;
                ingredientToReturn.Name = _allIngredients[indexOfIngredient].Name;
                ingredientToReturn.Cost = _allIngredients[indexOfIngredient].Cost;

                // Добавляем объект выше в возвращаемый список ингредиентов
                ingredientsToReturn.Add(ingredientToReturn);
            }

            // Сохраняем изменения на складе
            SaveIngredients();

            // Возвращаем список
            return ingredientsToReturn;
        }

        public List<Ingredient> GetAllIngredients()
        {
            LoadIngredients();
            return _allIngredients;
        }

        // the end of the code
    }

}
