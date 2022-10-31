using System.Net.Security;


namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.ReadKey();

            int x, y;
            Console.WriteLine("Enter a value for x");
            bool isParseblX = Int32.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Enter a value for y");
            bool isParseblY = Int32.TryParse(Console.ReadLine(), out y);
            if (isParseblX && isParseblY)
            {

                var result1 = -6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15;
                Console.WriteLine($"result from -6*x^3+5*x^2-10*x+15 = {result1}");
                var result2 = Math.Abs(x) * Math.Sin(x);
                Console.WriteLine($"result from abs(x)*sin(x) = {result2}");
                var result3 = 2 * Math.PI * x;
                Console.WriteLine($"result from 2*pi*x = {result3}");
                var result4 = Math.Max(x, y);
                Console.WriteLine($"result from max(x, y) = {result4}");
            }
            else
            {
                Console.WriteLine("Incorrect symbols");
            }

            Console.WriteLine("");

            DateTime date1 = new DateTime(2022, 1, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2023, 1, 1, 0, 0, 0);
            TimeSpan intervalX = date2 - DateTime.Now;
            TimeSpan intervalY = DateTime.Now - date1;
            Console.WriteLine($"{intervalX.Days} days left to New Year");
            Console.WriteLine($"{intervalY.Days} days passed from New Year");
            Console.ReadKey();

        }
    }
}