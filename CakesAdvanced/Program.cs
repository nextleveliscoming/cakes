using CakesAdvanced.Models;
using ConsoleUtils;

namespace CakesAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            store.Open();
        }
    }
}
