using CakesLibrary;
using ConsoleUtils;
using System.Diagnostics;

namespace CakesAdvanced
{
    public class Store
    {
        public string Name { get; set; }

        private Storage _storage = new Storage();

        private Kitchen _kitchen;

        public Store()
        {
            _storage = new Storage();
            _kitchen = new Kitchen(_storage);
            _kitchen.CakeReady += OnCakeReady;
        }

        void OnCakeReady(Cake cake)
        {
            Console.WriteLine($"{cake.Name} готов. Его цена: {cake.Price} руб.");
        }

        // Интерфейс для добавления новых ингредиентов на склад
        void AddIngredients()
        {
            try
            {
                // Название
                string name;

                do
                {
                    Console.Write("Введите название ингредиента: ");

                    name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.Write("Ошибка! Некорректный ввод. Попробуйте еще раз. ");
                    }

                } while (string.IsNullOrWhiteSpace(name));

                Console.Clear();

                // Цена
                Console.Write("Укажите цену ингредиента. ");
                decimal cost = InputService.GetDecimal();

                // Количество
                Console.Write("Укажите количество ингрединта. ");
                int quantity = InputService.GetInt();

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
                    Console.WriteLine("Ингредиенты добавлены");
                    pressEnterToReturn();
                    break;

                case '2':

                    List<Ingredient> ingredients = _storage.GetAllIngrredients();

                    if (ingredients == null)
                    {
                        Console.WriteLine("В данный момент ингредиенты на складе отсутствуют");
                        pressEnterToReturn();
                    }

                    string padding = "";

                    Console.WriteLine($"Название:\t\tЦена:\t\tКоличество:");

                    foreach (Ingredient ingredient in ingredients)
                    {
                        Console.WriteLine($"{ingredient.Name.PadRight(24)}{ingredient.Cost}\t\t{ingredient.Quantity}");
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
                {'1', "Показать список доступных тортов" },
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

            var availableRecipes = _kitchen.GetAvailableRecipes();

            if (availableRecipes.Count == 0)
            {
                Console.WriteLine("К сожалению, в данный момент невозможно сделать заказ. Попробуйте позже.");
                pressEnterToReturn();
            }
            else
            {
                Console.WriteLine("Список доступных для заказа тортов:");
                int cakeNumber = 1;

                foreach (string cakeName in availableRecipes.Keys)
                {
                    Console.WriteLine($"{cakeNumber++}. {cakeName}");
                }
            }
        }

        // Процесс заказа торта
        void TakeOrder()
        {
            string userCake = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userCake))
            {
                Console.Clear();
                Console.WriteLine("Вы ввели некорректное название");
                pressEnterToReturn();
            }

            Console.Clear();

            userCake = userCake.ToLower();

            try
            {
                _kitchen.MakeCake(userCake);
                Console.WriteLine($"Заказ на приготовление {userCake} принят");
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Исключение: {ex.Message}");
                throw new Exception($"К сожалению \"{userCake}\" невозможно приготовить");
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
                    try
                    {
                        ShowClientOptions();
                        pressEnterToReturn();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    Open();
                    return;
            }
        }



        // the end of the code
    }
}
