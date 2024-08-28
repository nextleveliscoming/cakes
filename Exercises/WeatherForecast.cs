using System.Security.Cryptography.X509Certificates;

public class WeatherForecast
{

    /* Comment section */

    public static void Start()
    {

        // Генератор погоды

        /* Когда в дальнейшем определяю диапазон чисел,
        то помню, что второе число исключатеся, соответственно и сами
        вторые числа на единицу больше, чем ты задавал */

        // Температуры

        int[] CreateRandomTemperatures()
        {
            int[] a = new int[30];
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                a[i] = random.Next(-40, 51);
            }
            return a;
        }

        int[] temperatures = CreateRandomTemperatures();

        // Осадки

        double[] CreateRandomPrecipitations()
        {   
            double[] a = new double[30];
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                a[i] = random.Next(0, 101);
            }
            return a;
        }

        double[] precipitation = CreateRandomPrecipitations();

        // РАСЧЕТ СРЕДНЕМЕСЯЧНОЙ ТЕМПЕРАТУРЫ

        // Вычисляем общую сумму температур с помощью цикла for
        int temperaturesTotal = 0;
        for (int i = 0; i < temperatures.Length; i++)
        {
            temperaturesTotal += temperatures[i];
        }

        /* Определяем среднюю температуру, т.е. делим общую сумму температур
        на количество элементов в массиве temperatures. И сразу же результат
        выводим в консоль. */

        int temperaturesAverage = temperaturesTotal / temperatures.Length;

        Console.WriteLine();
        Console.WriteLine("Данные о погоде в Грозном за сентябрь 2023 г.");
        Console.WriteLine();
        Console.WriteLine($"Средняя температура за месяц: {temperaturesAverage}°C");

        // ВЫВОД САМОГО ХОЛОДНОГО ДНЯ МЕСЯЦА
        /* (только первого попавшегося в массиве,
        по факту есть еще один такой же холодный день,
        но решил пока так */

        // Определяем самую низкую температуру с помощью метода Min
        int coldestTemperature = temperatures.Min();

        /* Определяем дату. За основу взят индекс минимальной температуры
        с прибавлением единицы, чтобы получить нужное число. */
        int coldestDay = Array.IndexOf(temperatures, temperatures.Min()) + 1;

        /* Тут решил заморочиться с добавлением нуля,
        если дата состоит из одной цифры, чтобы было красивее */
        string coldestDayText = coldestDay.ToString();
        if (coldestDayText.Length < 2)
        {
            coldestDayText = "0" + coldestDayText;
        }

        Console.WriteLine($"Самый холодный день месяца: {coldestDayText}.09.2023, {coldestTemperature}°C");

        // ВЫВОД САМОГО ТЕПЛОГО ДНЯ МЕСЯЦА
        // (то же самое – первый попавшийся, хоть на этот раз он и один такой)
        int warmestTemperature = temperatures.Max();
        int warmestDay = Array.IndexOf(temperatures, temperatures.Max()) + 1;

        string warmestDayText = warmestDay.ToString();
        if (warmestDayText.Length < 2)
        {
            warmestDayText = "0" + warmestDayText;
        }

        Console.WriteLine($"Самый теплый день месяца: {warmestDayText}.09.2023, {warmestTemperature}°C");

        // ОБЩЕЕ КОЛИЧЕСТВО ОСАДКОВ ЗА МЕСЯЦ

        /* Используем тип данных decimal, чтобы точно все посчиталось.
        Если оставить double, то в результате куча лишних чисел после запятой.
        По ходу кастуем precipation в decimal, потому что так надо */
        decimal precipitationTotal = 0;

        for (int i = 0; i < temperatures.Length; i++)
        {
            precipitationTotal += (decimal)precipitation[i];
        }

        Console.WriteLine($"Общее количество осадков за месяц: {precipitationTotal} мм");

        // КОЛИЧЕСТВО ДНЕЙ С ОСАДКАМИ ВЫШЕ СРЕДНЕГО

        // Считаем среднее количество осадков
        decimal precipationAverage = precipitationTotal / precipitation.Length;

        /* Тут уже считаем дни выше среднего,
        сразу создаем переменную, чтобы считала дни */
        int numberOfDays = 0;
        // Для этого перебираем весь массив с помощью цикла for 
        for (int i = 0; i < precipitation.Length; i++)
        {
            /* Всякий раз как число осадков будет выше среднего,
            счетчик дней инкрементируется */
            if ((decimal)precipitation[i] > precipationAverage)
            {
                numberOfDays++;
            }
        }
        // Выводим результат в консоль
        Console.WriteLine($"Общее количество дней с осадками выше среднего: {numberOfDays}");

        // ДНИ С ЗАМОРОЗКАМИ И УВЕЛИЧЕНИЕМ ОСАДКОВ ПО СРАВНЕНИЮ С ПРЕДЫДУЩИМ ДНЕМ
        // (все-таки я решил использовать даты вместо индексов)

        Console.WriteLine();
        Console.WriteLine("Дни с заморозками и увеличением осадков по сравнению с предыдущим днем:");
        Console.WriteLine();

        /* Использую цикл for для перебора массива температур.
        Также использую тот же самый счетчик i, чтобы манипулировать
        массивом осадков.
        
        Перебор массива надо начинать со второго дня,
        потому что если первый день месяца будет с заморозками,
        у нас нет возможности сравнить первый день с предыдущим днем месяца.
        Да и программа выдаст ошибку, т.к. мы выходим за пределы индекса во время
        условного ветвления ниже.*/
        for (int i = 1; i < temperatures.Length; i++)
        {
            /* Если температура (temperatures[i]) ниже нуля и значение элемента массива осадков
            за текущий день (precipitation[i]) выше значения того же массива
            за предыдущий день (precipitation[i - 1]), условное выражение срабатывает */
            if (temperatures[i] < 0 && precipitation[i] > precipitation[i - 1])
            {
                int date = i + 1;
                string dateText = date.ToString();
                /* Опять же для красоты заморачиваюсь с нулем перед датой,
                в случае, если дата состоит только из одной цифры */
                if (dateText.Length < 2)
                {
                    dateText = "0" + dateText;
                }
                Console.WriteLine($"{dateText}.09.2023");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Спасибо, что пользуетесь нашим сервисом! Всего наилучшего!");
        Console.WriteLine();
        
    }
}