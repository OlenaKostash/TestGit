using System.Net.Security;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int x, y;
            Console.WriteLine("Enter a value for x");
            bool isParseblX = Int32.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Enter a value for y");
            bool isParseblY = Int32.TryParse(Console.ReadLine(), out y);
            if (isParseblX && isParseblY)
            {
                int sum = 0;
                if (x > y)
                   sum = CalculateSum(x, y);
                else if (y > x)
                   sum = CalculateSum(y, x);
                else
                    Console.WriteLine($"The sum is {x}");
            }
            else 
            {
                Console.WriteLine("Incorrect symbols");
            }
            Console.ReadKey();
 
        }

        static int CalculateSum(int max, int min)
        {
            int result = 0;
            for (int i = min; i <= max; i++)
                result = result + i;
            Console.WriteLine($"The sum of all numbers between {min} and {max} is {result}");
            return result;
        }
    }
}