public class MagicNumbers
{

    /* Comment section */

    // Генератор чисел
    private static int[] CreateArrayOfRandomNumbers(int a, int b)
    {
        int[] arrayOfRandomNumbers = new int[20];

        Random random = new Random();
        for (int i = 0; i < 20; i++)
        {
            arrayOfRandomNumbers[i] = random.Next(a, b);
        }
        return arrayOfRandomNumbers;
    }

    // Вывод маг. чисел
    private static void ShowMagicNumbers(string magicNumbersOutput)
    {
        Console.WriteLine("＼(＾▽＾)／ Ура! Мне удалось найти магические числа!");
        Console.WriteLine();
        /* Для вывода чисел использую magicNumbersOutput,
        при этом удаляю с конца два последних символа – точку и пробел,
        чтобы перечисление логично закончилось на точке*/
        Console.WriteLine($"Вот они: {magicNumbersOutput.Remove(magicNumbersOutput.Length - 2)}.");
        Console.WriteLine();
    }

    public static void Start()
    {

        // Приветствие
        Console.WriteLine();
        Console.WriteLine("Ассаламу алайкум! Я программа, которая ищет магические числа в массиве, представленном ниже. Магическим считается число, которое четное и если его умножить на 2, то результат уже есть в массиве. Массив состоит из 20 случайных чисел от 1 до 100.");
        Console.WriteLine();

        // Генератор чисел элементов массива
        int[] randomNumbers = CreateArrayOfRandomNumbers(1, 101);

        // Показываем пользователю наш массив, чтобы все было честно
        Console.Write("Массив чисел следующий: ");

        Console.Write(string.Join(", ", randomNumbers) + ".");
        Console.WriteLine();
        Console.WriteLine();

        // Просим пользователя принять участие в волшебстве
        Console.WriteLine("А теперь нажми Enter, чтобы увидеть чудо (^_^)");
        Console.ReadLine();

        // Лог. переменная на случай, если магия не сработает
        bool isThereAnyMagic = false;

        // Строковая переменная для сбора маг. чисел
        string magicNumbersCollection = "";

        // Перебираем весь массив
        for (int i = 0; i < randomNumbers.Length; i++)
        {
            // Проверяем каждый элемент массива на четность и тут же на магию
            if (randomNumbers[i] % 2 == 0 && Array.IndexOf(randomNumbers, randomNumbers[i] * 2) != -1)
            {
                isThereAnyMagic = true;
                // При наличии конкатенируем маг. число в magicNumbersOutput
                magicNumbersCollection += randomNumbers[i] + ", ";
            }
        }

        // Если магии не случается, то печалька
        if (!isThereAnyMagic)
        {
            Console.WriteLine("Упс, похоже сегодня волшебство объявило выходной ;(");
            Console.WriteLine();
            return;
        }

        // Показываем маг. числа
        ShowMagicNumbers(magicNumbersCollection);
    }
}