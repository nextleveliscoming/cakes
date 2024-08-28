using System.Xml.Serialization;

public class TemperaturesConverter
{

    public static void Start()
    {

        // Приветствие
        Console.WriteLine();
        Console.WriteLine("Добро пожаловать в конвертер температуры!");
        Console.WriteLine("Здесь вы сможете конвертировать температуру из градусов Цельсия в градусы Фаренгейта и наоборот.");
        Console.WriteLine();

        // Предлагаем ввести температуру
        Console.Write("Введите температуру. ");
        decimal userTemperature = ConsoleUtils.InputService.GetDecimal();

        // Предлагаем выбрать шкалу
        Console.Write("Выберите шкалу (\"C\" для Цельсия, \"F\" для Фаренгейта): ");
        string userScale = ConsoleUtils.InputService.GetScale();

        // Переменная для вывода итогового результата
        decimal result;

        // Строка для названия шкалы
        string theScaleIs;

        // Расчеты по формулам
        if (userScale == "f")
        {
            theScaleIs = "Фаренгейта";
            result = userTemperature * 9 / 5 + 32;
        }
        else
        {
            theScaleIs = "Цельсия";
            result = (userTemperature - 32) * 5 / 9;
        }

        // Конвертруем результат в string
        string resultConvertedToString = string.Format("{0:f1}", result);

        // Итог выводим в консоль
        Console.WriteLine($"Температура в градусах {theScaleIs}: {resultConvertedToString}");
        Console.WriteLine();

        // the end of the code
    }
}
