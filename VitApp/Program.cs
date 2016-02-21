using System;

namespace VitApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IScanner scanner = new DumbScanner(1)
            {
                { "Бухло", 10, 20 },
                { "Закусь", 5, 25 },
                { "Шлаки", 15, 50 },
                { "P4", 100, 200 }
            };

            scanner.Run(vars =>
            {
                Console.WriteLine("{0} = {1}", vars[0].Name, vars[0].Value);
                Console.WriteLine("{0} = {1}", vars[1].Name, vars[1].Value);
                Console.WriteLine("{0} = {1}", vars[2].Name, vars[2].Value);
            });
        }
    }
}
