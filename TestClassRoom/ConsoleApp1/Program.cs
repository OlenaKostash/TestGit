namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Data source
            string[] names = { "Bill", "Steve", "James", "Mohan" };

            // LINQ Query 
            var myLinqQuery = from name in names
                              where name.Contains('a')
                              select name;
            var myLinqQuery1 = from name in names
                               where name.Contains('l')
                               select name;
            

            // Query execution
            foreach (var name in myLinqQuery1)
                Console.Write(name + " ");
        }
    }
}