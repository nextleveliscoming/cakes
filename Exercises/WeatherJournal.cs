public class WeatherJournal
{
    // Ссылка на файл
    private static string GetPath()
    {
        return Directory.GetCurrentDirectory() + @"\content.txt";
    }

    private static string GetWeatherInformationByDate(string date)
    {
        // Получаем массив строк из файла
        string[] weatherData = File.ReadAllLines(GetPath());

        // Проходимся по массиву строк
        foreach (string weatherDataLine in weatherData)
        {
            /* Если есть нужная дата, сразу завершаем перебор массива.
            И возвращаем строчку со всеми данными */
            if (weatherDataLine.Contains(date))
            {
                return weatherDataLine;
            }
        }

        return "По выбранной дате нет данных. ";
    }


    // Чтение данных
    private static void RecordData()
    {
        // Дата
        string weatherDate = "Дата: " + ConsoleUtils.InputService.GetDate();

        // Температура 
        Console.Write("Введите температуру. ");
        string weatherTemperature = "Температура: " + string.Format("{0:f1}", ConsoleUtils.InputService.GetDecimal()) + "°C";

        // Влажность
        int weatherHumidityInt;

        while (true)
        {
            Console.Write("Укажите влажность от 0 до 100. ");

            weatherHumidityInt = ConsoleUtils.InputService.GetInt();

            if (weatherHumidityInt >= 0 && weatherHumidityInt <= 100)
            {
                Console.Clear();
                break;
            }
            Console.Write("Ошибка! ");
        }

        string weatherHumidity = "Влажность: " + weatherHumidityInt + "%";

        // Погода
        string weatherDescription = "Погода: " + ConsoleUtils.InputService.GetWeatherDescription();

        /* Блок try-catch на случай ошибки.
        При возниковении ошибки, программа об этом сообщает
        и возвращает к выбору режима */
        try
        {
            // Запись данных в файл
            File.AppendAllText(GetPath(), $"{weatherDate}; {weatherDescription}; {weatherTemperature}; {weatherHumidity}\n");

            // Если файл записался, то сообщаем об успехе и предлагаем продолжить
            Console.Write("Запись произведена успешно! Нажмите Enter для выбора режима ");
            Console.ReadLine();
            Console.Clear();
        }
        catch
        {
            // Сообщение на случай ошибки записи
            Console.Clear();
            Console.Write("Возникла ошибка записи! Нажмите Enter для выбора режима ");
            Console.ReadLine();
            Console.Clear();
        }
    }

    // Запись данных
    private static void ReadData()
    {
        /* Блок try-catch на случай ошибки.
        При возниковении ошибки, программа об этом сообщает
        и возвращает к выбору режима */
        try
        {
            Console.Clear();
            Console.WriteLine(GetWeatherInformationByDate(ConsoleUtils.InputService.GetDate()));
        }
        catch
        {
            Console.Clear();
            Console.Write("Возникла ошибка чтения! ");
        }

        /* Что бы не произошло выше при чтении файла,
        предлагаем снова выбрать режим*/
        Console.WriteLine();
        Console.Write("Нажмите Enter для выбора режима ");
        Console.ReadLine();
        Console.Clear();
    }
    public static void Start()
    {

        // Приветствие
        Console.Clear();
        Console.WriteLine("Добро пожаловать в приложение для записи и чтения данных о погоде из файлов!");
        Console.WriteLine();

        // Переменная для выбора пунктов меню
        string? menuSelection;

        /* Выборы режимов поставил в цикл.
        Пользователь может выбрать только режим 1 или 2,
        либо Q для выхода */

        do
        {
            Console.WriteLine("Выберите один из режимов:");
            Console.WriteLine();
            Console.WriteLine("1. Запись данных");
            Console.WriteLine("2. Чтение данных");
            Console.WriteLine();
            Console.Write("Введите соответствующий номер или \"Q\" для выхода: ");

            // Пользователь выбирает пункт меню
            menuSelection = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(menuSelection))
            {
                menuSelection = menuSelection.ToLower();
            }

            /* Применил switch-case, потому что он посимпатичнее выглядит
            и в проекте от курса Microsoft использовался в похожей ситуцаии
            при выборе пунктов меню */

            switch (menuSelection)
            {
                // Запись данных
                case "1":
                    Console.Clear();
                    RecordData();
                    break;

                // Чтение данных
                case "2":
                    Console.Clear();
                    ReadData();
                    break;

                /* Если пользователь во время выбора режима,
                выбирает всё, что угодно кроме 1, 2 или Q,
                сообщаем об ошибке и заново просим ввести то,
                что нужно */
                default:
                    Console.Clear();
                    Console.Write("Ошибка! ");
                    break;
            }
            /* Завершение цикла и выход из программы
            при нажатии нужной клавиши */
        } while (menuSelection != "q");

        // the end of the code    
    }
}