public class ArrayInversion
{
    
    /* Comment section */

    public static void Start()
    {

        int[] arrayToInverse = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
        
        /*
        Надеюсь я правильно понял задание и результат инверсии должен
        выводиться просто в консоль, вместо того чтобы полностью менять
        всё в массиве.
        */

        Console.WriteLine();
        
        /*
        Решаю задачу с помощью цикла "for".
        
        Создаю переменную "number", чтобы привязать ее к индексу и выводить
        нужное значение из массива.
        
        Присваиваю ей значение количества элементов массива с вычетом единицы,
        чтобы попасть в нужный индекс. В данном случае получается "9 - 1".
        
        Вывожу в консоль значение массива с индексом равным "number".

        По идее цикл должен прекратиться в момент когда "number >= 1", потому что в консоли,
        где вычисляется индекс получился бы 0 и последний элемент массива стал бы первым.
        Но мне хотелось, чтобы после каждого числа ставилась запятая, а после последнего числа точка.
        Поэтому я закончил цикл в момент "number >= 2", а последнее число вывел отдельно за циклом,
        вручную с помощью индекса 0.
        */
        for (int number = arrayToInverse.Length - 1; number >= 2; number--)
        {
            Console.Write($"{arrayToInverse[number]}, ");
        }
        Console.WriteLine($"{arrayToInverse[0]}.");
        Console.WriteLine();

    }
}