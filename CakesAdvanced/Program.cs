using CakesAdvanced.Models;
using ConsoleUtils;

namespace CakesAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Добро пожаловать в наш клиент по организации кондитерской!");
            Console.WriteLine("Для работы в приложении, переключайтесь между пунктами меню");
            Console.Write("Нажмите клавишу Enter, чтобы продолжить ");
            Console.ReadLine();

            var store = new Store();
            store.Open();
        }
    }
}
