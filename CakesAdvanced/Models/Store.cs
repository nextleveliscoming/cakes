using CakesAdvanced.Models;
using ConsoleUtils;

namespace CakesAdvanced
{
    public class Store
    {
        public string Name { get; set; }

        

        private Storage _storage = new Storage();

        private Kitchen _kitchen;


        // Интерфейс для добавления новых ингредиентов на склад
        void AddIngredients()
        {
            try
            {

                // Название
                Console.Write("Введите название ингредиента: ");
                string name = Console.ReadLine();
                Console.WriteLine();

                // Цена
                Console.Write("Укажите цену ингредиента. ");
                decimal cost = InputService.GetDecimal();
                Console.WriteLine();

                // Количество
                Console.Write("Укажите количество ингрединта. ");
                int quantity = InputService.GetInt();
                Console.WriteLine();

                Ingredient ingredientToAdd = new Ingredient()
                {
                    Name = name,
                    Cost = cost,
                    Quantity = quantity
                };

                List<Ingredient> listOfIngredientsToAdd = new List<Ingredient>();
                listOfIngredientsToAdd.Add(ingredientToAdd);
                _storage.AddIngredients(listOfIngredientsToAdd);
            }

            catch
            {
                _storage.LoadIngredients();
            }
        }

        void optionUnavailable()
        {
            Console.Clear();
            Console.Write("В данный момент опция недоступна. Нажмите Enter, чтобы вернуться в главное меню ");
            Console.ReadLine();
            Open();
        }

        void pressEnterToReturn()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter, чтобы вернуться в главное меню");
            Console.ReadLine();
            Open();
        }

        // Интерфейс для менеджера
        void ShowManagerOptions()
        {
            Dictionary<char, string> options = new Dictionary<char, string>
            {
                {'1', "Добавить ингредиенты"},
                {'2', "Получить список ингредиентов"}
            };

            char selectedOption = InputService.GetOption("Выберите опцию:", options);

            switch (selectedOption)
            {
                case '1':
                    AddIngredients();
                    pressEnterToReturn();
                    break;

                case '2':

                    List<Ingredient> ingredients = _storage.GetAllIngrredients();

                    if (ingredients == null)
                    {
                        Console.WriteLine("В данный момент ингредиенты на складе отсутствуют");
                        pressEnterToReturn();
                    }

                    Console.WriteLine("Название\t\tЦена\t\tКоличество");

                    foreach (Ingredient ingredient in ingredients)
                    {
                        Console.WriteLine($"{ingredient.Name}\t\t\t{ingredient.Cost}\t\t{ingredient.Quantity}");
                    }

                    pressEnterToReturn();
                    break;

                default:
                    Open();
                    return;
            }
        }

        // Интерфейс для клиентских опций
        void ShowClientOptions()
        {
            Dictionary<char, string> options = new Dictionary<char, string>
            {
                {'1', "Показать список возможных тортов" },
                {'2', "Заказать торт" }
            };

            char selectedOption = InputService.GetOption("Выберите опцию:", options);

            Console.Clear();

            switch (selectedOption)
            {
                case '1':
                    ShowAvailableCakeOptions();
                    pressEnterToReturn();
                    break;

                case '2':
                    TakeOrder();
                    break;

                default:
                    Open();
                    return;
            }
        }


        // Отображение списка доступных для заказа тортов
        void ShowAvailableCakeOptions()
        {
            Storage storage = _storage;

            _kitchen = new Kitchen(storage);

            var availableRecipes = _kitchen.GetAvailableRecipes();

            if (availableRecipes.Count == 0)
            {
                Console.WriteLine("К сожалению, в данный момент невозможно сделать заказ");
                pressEnterToReturn();
            }
            else
            {
                Console.WriteLine("Список доступных для заказа тортов:");
                int cakeNumber = 0;

                foreach (string cakeName in availableRecipes.Keys)
                {
                    Console.WriteLine($"{cakeNumber++}. {cakeName}");
                }
            }
        }

        // Процесс заказа торта
        void TakeOrder()
        {
            string? userCake = Console.ReadLine();

            if (userCake == null)
            {
                throw new Exception("Ошибка! Введено некорректное название");
            }


            userCake = userCake.ToLower();

            /*
            if (_kitchen == null)
            {
                optionUnavailable();
            }
            */

            Cake cake = _kitchen.MakeCake(userCake);

            try
            {
                Console.WriteLine($"{cake.Name} готов. Его цена: {cake.Price}");
            }
            catch
            {
                throw new Exception("Возникла ошибка!");
            }
        }

        // Точка входа для взаимодействия с кондитерской
        public void Open()
        {

            Dictionary<char, string> options = new Dictionary<char, string>
            {
                { '1', "Менеджер" },
                { '2', "Клиент" }
            };

            char selectedOption = InputService.GetOption("Выберите режим:", options);

            switch (selectedOption)
            {
                case '1':
                    ShowManagerOptions();
                    break;

                case '2':
                    ShowClientOptions();
                    break;

                default:
                    Open();
                    return;
            }
        }



        // the end of the code
    }
}
