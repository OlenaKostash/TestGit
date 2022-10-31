using System.Net.Security;


namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1,2,4 Paragraph
            Random random = new Random();
            List<int> sorseArray = new List<int>(); 
            for(int i = 0; i < 4; i++)
                sorseArray.Add(random.Next(0, 20));

            Console.WriteLine($"max number from {sorseArray[0]} and {sorseArray[1]}"
                + " is " + MaxNumber(sorseArray[0], sorseArray[1]));
            Console.WriteLine($"min number from {sorseArray[0]} and {sorseArray[1]}"
               + " is " + MinNumber(sorseArray[0], sorseArray[1]));
            #endregion

            #region 3 Paragraph
            int sum;
            bool resultFromSum = TrySumIfOdd(sorseArray[0], sorseArray[1],out sum);
            Console.WriteLine($"{resultFromSum}: the sum between " +
                $"{sorseArray[0]} and {sorseArray[1]} is {sum}");
            #endregion

            Console.WriteLine("Enter a value for x");
            bool isParseblX = Int32.TryParse(Console.ReadLine(), out x);

            Console.ReadKey();
        }

        #region 1,2,4 Paragraph
        static int MaxNumber(int num1, int num2)
        { 
            return Math.Max(num1, num2);
        }

        static int MaxNumber(int num1, int num2, int num3)
        {
            return Math.Max(num1, Math.Max(num2, num3));
        }

        static int MaxNumber(int num1, int num2, int num3, int num4)
        {
            return Math.Max(num1, Math.Max(num2, Math.Max(num3, num4)));
        }

        static int MinNumber(int num1, int num2)
        {
            return Math.Min(num1, num2);
        }

        static int MinNumber(int num1, int num2, int num3)
        {
            return Math.Min(num1, Math.Min(num2, num3));
        }

        static int MinNumber(int num1, int num2, int num3, int num4)
        {
            return Math.Min(num1, Math.Min(num2, Math.Min(num3, num4)));
        }
        #endregion

        #region 3 Paragraph
        static bool TrySumIfOdd(int num1, int num2, out int sum)
        {
            sum = 0;

            for (int i = Math.Min(num1, num2)+1; i < Math.Max(num1, num2);i++)
                sum = sum + i;

            if (sum % 2 == 0)
                return false;
            else
                return true; 
        }
        #endregion



    }
}