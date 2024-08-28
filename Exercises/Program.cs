namespace csprojects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("utf-16");

            WeatherJournal.Start();
        }
    }
}
