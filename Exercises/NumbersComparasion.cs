public class NumbersComparasion
{

    /* Comment section */

    public static void Start()
    {
        // ! если ты собираешься этот код писать во всех задачах, лучше его написать в Program.cs один раз
        // Код для кириллицы
        // Done

        // Код ниже предлагает вписать числа. Сразу же идет конвертация внесенных данных в Int32, потому что изначально они видимо воспринимаются, как string. Полученные значения присваиваются к соответствующим переменным.
        // ! Можно использовать .Write чтобы вводимое число оказывалось рядом с сообщением
        // круто что сделал нормальные имена переменных и сразу сделал конвертацию
        // Thank you! And done

        Console.Write("Введите первое число ");
        int firstNumber = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Отлично! Теперь введите второе число ");
        int secondNumber = Convert.ToInt32(Console.ReadLine());

        // Далее идет процесс сравнения
        // Если возможны только три варианта, то можно сэкономить на последнем условии и 
        // просто else сделать
        // Done
        if (firstNumber == secondNumber)
        {
            Console.WriteLine("Два числа равны");
        }
        else if (firstNumber > secondNumber)
        {
            Console.WriteLine("Первое число больше второго");
        }
        else
        {
            Console.WriteLine("Первое число меньше второго");
        }
    }
}