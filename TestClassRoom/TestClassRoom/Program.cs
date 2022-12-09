
using TestProject;

namespace TestClassRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity;
            Console.WriteLine("Enter Capacity of Stack :");
            bool isParsebl = int.TryParse(Console.ReadLine(), out capacity);
            if (!isParsebl)
            {
                Console.WriteLine("Invalid number");
                return;
            }

            MyStack<string> stack = new MyStack<string>(capacity);
            var continueProg = true;
            do
            {
                Console.WriteLine("Choose operation (-pu) -Push, (-po) - Pop, (-cl) - Clear, " +
                    "(-ct) - Count, (-pe) - Peek, -(co) - CopyTo(arr), (-out) - exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "-pu":
                        Console.WriteLine("Enter String to Push :");
                        stack.Push(Console.ReadLine());
                        break;
                    case "-po":
                        string result = stack.Pop();
                        if (result != null)
                            Console.WriteLine("Delete Element :" + result);
                        else
                            Console.WriteLine("Stack Underflow !");
                        break;
                    case "-cl":
                        stack.ClearStack();
                        break;
                    case "-ct":
                        int resultCount = stack.CountStack();
                        Console.WriteLine($"Stack include {resultCount} element");
                        break;
                    case "-pe":
                        string resultTop = stack.Peek();
                        if (resultTop != null)
                            Console.WriteLine($"Top element is {resultTop}");
                        else
                            Console.WriteLine("Stack is empty");
                        break;
                    case "-co":
                        string[] resultArray = new string[capacity];
                        stack.CopyStackToArray(resultArray);
                        Console.WriteLine("Stack has been copied to array");
                        break;
                    case "-out":
                        continueProg = false;
                        break;
                    default:
                        continue;
                }
            }
            while (continueProg);
        }
    }
}