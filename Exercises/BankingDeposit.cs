public class BankingDeposit
{

    /* Comment section */

    public static void Start()
    {
        /*
        Стандартное приветствие. Для удобства пользователя использовал метод WriteLine, чтобы разделить абзацы.
        В то же время другим разработчикам должно быть удобнее разбирать код.
        */
        Console.WriteLine();
        Console.WriteLine("Добро поаловать в банк \"Чечня – Круто\"!");
        Console.WriteLine();
        Console.Write("Пожалуйста, введите сумму вклада и мы посчитаем проценты: ");

        // Переменная для суммы вклада
        double depositAmount = Convert.ToDouble(Console.ReadLine());

        // Переменная для дальнейшего подбора процентов
        int depositorPercentage = 0;

        // Далее в зависимости от условия меняется процент   
        if (depositAmount < 100)
        {
            depositorPercentage = 5;
        }
        else if (depositAmount <= 200)
        {
            depositorPercentage = 7;
        }
        else
        {
            depositorPercentage = 10;
        }

        // Итоговая сумма с процентами вычисляется за пределами блока if.
        depositAmount += depositAmount / 100 * depositorPercentage;

        // В консоль выводится процент по вкладу, а также общая сумма с начисленными процентами
        Console.WriteLine();
        Console.WriteLine($"Ваш процент по вкладу равен: {depositorPercentage}%");
        Console.WriteLine($"Cумма вклада с начисленными процентами составит: {depositAmount}$");
        Console.WriteLine();
    }
}