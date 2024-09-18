using System.Runtime;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleUtils
{
    public class InputService
    {
        public static int GetInt()
        {
            while (true)
            {
                Console.Write("Введите целое число: ");

                if (int.TryParse(Console.ReadLine(), out int userNumber))
                {
                    Console.Clear();
                    return userNumber;
                }

                Console.Write("Ошибка! ");
            }
        }

        public static decimal GetDecimal()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            while (true)
            {
                Console.Write("Ввод должен быть числом с десятичной точкой (например, 10.5): ");

                string? userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) && !userInput.Contains(',') && decimal.TryParse(userInput, out decimal userNumber))
                {
                    Console.Clear();
                    return userNumber;
                }

                Console.Write("Ошибка! ");
            }
        }

        public static string GetScale()
        {
            string? userInput;

            while (true)
            {
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    userInput = userInput.ToLower();

                    if (userInput == "c" || userInput == "f")
                    {
                        return userInput;
                    }
                }
                Console.WriteLine("Неверный ввод!");
                Console.Write("Пожалуйста выберите шкалу \"F\" или \"С\": ");
            }
        }

        public static string GetDate()
        {
            /* Почему-то после первой записи даты, формат даты
            меняется с "дд.мм.гггг" на "мм.дд.гггг". Код ниже
            поправляет это дело */
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            /* Цикл работает, пока пользователь не введет
            дату в правильном формате и правильной длины (10 символов)*/
            while (true)
            {
                Console.Write("Введите дату в формате \"дд.мм.гггг\" (например, 31.12.2012): ");
                string? userInput = Console.ReadLine();

                if (DateOnly.TryParse(userInput, out DateOnly result) && userInput.Length == 10)
                {
                    /* В случае успеха, возвращаем то, что ввел
                    пользоатель в формате строки */
                    Console.Clear();
                    return userInput;
                }

                Console.Write("Ошибка! ");
            }
        }

        public static string GetWeatherDescription()
        {
            // Описание погоды тоже должно быть соответствующим    

            string[] description = { "Солнечно", "Облачно", "Дождь", "Снег", "Туман" };

            while (true)
            {
                Console.Write("Опишите погоду (например: Солнечно, Облачно, Дождь, Снег, Туман): ");
                string? userInput = Console.ReadLine();

                foreach (string state in description)
                {
                    if (!string.IsNullOrEmpty(userInput) && userInput.ToLower() == state.ToLower())
                    {
                        Console.Clear();
                        return state;
                    }
                }

                Console.Write("Ошибка! ");
            }
        }

        public static char GetOption(string message, Dictionary<char, string> options)
        {
            Console.Clear();

            Console.WriteLine(message);

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}. {option.Value}");
            }

            try
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.Clear();

                // Пытаемся получить числовое значение
                char mode = input.KeyChar;
                if (!options.ContainsKey(mode) && mode != '\r')
                {
                    // Если ошибка, запускаем текущий метод, заново
                    return GetOption(message, options);
                }

                // Если код дошел сюда, возвращаем значение выбранного режима
                return mode;
            }
            catch (Exception)
            {
                // Если ошибка, запускаем текущий метод, заново
                return GetOption(message, options);
            }
        }


        


        // the end of the code
    }
}
