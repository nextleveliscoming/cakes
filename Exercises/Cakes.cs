public class Cakes
{
    /*
    Список тортов. Составлен с помощью чата GPT.
    Чат GPT мне помог не только с этим на самом деле))
    
    1. "Наполеон" - 900 руб.
    2. "Тирамису" - 800 руб.
    3. "Прага" - 1000 руб.
    4. "Шоколадный" - 1500 руб.  
    5. "Ред Велвет" - 1700 руб.
    6. "Медовик" - 750 руб.
    7. "Сникерс" - 1100 руб.
    8. "Фруктовый" - 1000 руб.
    9. "Картошка" - 650 руб.
    10. "Чизкейк" - 1450 руб.
    */
    public static void Start()
    {

        // Названия тортов
        string[] cakesNames = { "Наполеон", "Тирамису", "Прага", "Шоколадный", "Ред Велвет", "Медовик", "Сникерс", "Фруктовый", "Картошка", "Чизкейк" };

        // Цены на торты
        int[] cakesPrices = { 900, 800, 1000, 1500, 1700, 750, 1100, 1000, 650, 1450 };

        // Делаем проверку соответсвия размеров двух массивов
        if (cakesNames.Length != cakesPrices.Length)
        {
            Console.WriteLine("Данные не верны");
            Console.WriteLine("Программа завершена");
            return; // Завершение программы
        }

        // Спрашиваем у пользователя что он хочет
        Console.WriteLine();
        Console.WriteLine("Муьлха торт еза хьуна?:");
        Console.WriteLine();

        // Счетчик для расстановки порядковых номеров
        for (int i = 0; i < cakesNames.Length; i++)
        {
            Console.WriteLine($"{i + 1}. \"{cakesNames[i]}\"");
        }
        Console.WriteLine();

        // Пользователь дает ответ
        string? userInput = Console.ReadLine();

        // Если результат null, то прощаемся
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Неверный ввод! Давай досвидания!");
            Console.WriteLine();
            return;
        }
        Console.WriteLine();

        // Переменная для дальнейшего подтверждения, что торт нашелся или не нашелся
        bool isCakeFound = false;

        /*
        Проходимся по массиву из тортов и если находим нужный,
        то выводится сообщение о его цене
        */

        for (int i = 0; i < cakesNames.Length; i++)
        {
            if (userInput.ToLower() == cakesNames[i].ToLower())
            {
                Console.WriteLine($"{cakesNames[i]} {cakesPrices[i]} сом доьху!");
                Console.WriteLine();

                // Тут даем понять нашей логической переменной, что торт нашелся и на этом все
                isCakeFound = true;

                // Подключил опереатор break, чтобы завершить цикл
                break;
            }
        }

        /* Если все-таки запрашиваемого торта нет,
        срабатывает наша логическая переменная.
        Прощаемся с пользователем и желаем дачи у моря. */
        if (!isCakeFound)
        {
            Console.WriteLine($"\"{userInput}\" яц, нету, давай досвидания!");
            Console.WriteLine();
        }

    }
}