public class FiveAndTen
{
    
    /* Comment section */

    public static void Start()
    {
        Console.Write("Привет! Введи любое число, а я сравню его с числами 5 и 10: ");

        int userNumber = Convert.ToInt32(Console.ReadLine());

        if ((userNumber > 5) && (userNumber < 10))
        {
            Console.WriteLine($"Число {userNumber} больше пяти и меньше десяти!");
        }
        else
        {
            Console.WriteLine(@"Неизвестное чсило ¯\_(ツ)_/¯");
        }

    }
}