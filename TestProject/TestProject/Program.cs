
namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first string");
            string str1 = Console.ReadLine();

            Console.WriteLine("Enter the second string");
            string str2 = Console.ReadLine();

            bool resultOfComparison = Compare(str1, str2);
            Console.WriteLine($"The result of strings comparison is: {resultOfComparison}");

            Console.WriteLine("Enter the string for analazing method");
            string strAnalize = Console.ReadLine();
            var (alphabeticChars, digits, specialCharacters) = Analyze(strAnalize);
            Console.WriteLine($"string : {strAnalize} includes {alphabeticChars} alphabetic chars, {digits} digits, {specialCharacters} other special characters");

            Console.WriteLine("Enter the string for sorting method");
            string strSort = Console.ReadLine();
            Console.WriteLine(Sort(strSort));

            Console.WriteLine("Enter the string for chek the Duplicate method");
            string strDuplicate = Console.ReadLine();
            var arrayOfDuplicateChar = Duplicate(strDuplicate);
            if (arrayOfDuplicateChar.Count > 0)
                Console.WriteLine("Dublicated chars:");
            foreach (var item in arrayOfDuplicateChar)
            {
                Console.WriteLine(item);
            }

        }

        static bool Compare(string str1, string str2)
        {
            
            var charArr1 = str1.ToCharArray();
            var charArr2 = str2.ToCharArray();
            int maxStrLength = Math.Max(str1.Length, str2.Length);
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < maxStrLength; i++)
                {
                    if (charArr1[i] != charArr2[i])
                        return false;
                }
            }           
            return true;
        }

        static (int alphabeticChars, int digits, int specialCharacters) Analyze(string inputStr)
        {
            int alphabeticChars = 0;
            int digits = 0;
            int specialCharacters = 0;

            for (int i = 0; i < inputStr.Length; i++)
            {
                if (char.IsLetter(inputStr, i))
                    alphabeticChars++;
                else if(char.IsDigit(inputStr, i))
                    digits++;
                else
                    specialCharacters++;
            }
    
            return (alphabeticChars, digits, specialCharacters);
        }

        static string Sort(string inputStr)
        {
            var lowerStr = inputStr.ToLower();
            char[] characters = lowerStr.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        static List<char> Duplicate(string inputStr)
        {
            List<char> list = new List<char>();

            var lowerStr = inputStr.ToLower();
            char[] characters = lowerStr.ToArray();
 
            var groups = characters.GroupBy(v => v);
            foreach (var ch in groups)
            {
                if (ch.Count() > 1)
                    list.Add(ch.Key);
            }

            return list;
        }

    }
}


