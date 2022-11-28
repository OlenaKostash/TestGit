using RandomNameGeneratorLibrary;
using System.Text;

namespace TestClassRoom
{
    internal partial class Program
    {

        static void Main(string[] args)
        {
            var continueProg = true;
            do 
            {
                Console.WriteLine("Choose operation (-g) - generate, (-s) - search, (-bs) -binary search, (-out) - exit, (-p) - print all, (-e) - edit, (-c) - create:");
                string input = Console.ReadLine();
                var storage = new PhonesStorage();
                switch (input)
                {
                    case "-g":
                        RanRandomGeneration();
                        storage.OrderedByLastFirstNamePhone();
                        break;
                    case "-c":
                        storage.Save(new PhoneRecord());
                        break;
                    case "-p":
                        storage.PrintAll();
                        break;
                    case "-e":
                        storage.Edit(int.Parse(Console.ReadLine()));
                        break;
                    case "-s":
                        storage.Search();
                        break;
                    case "-bs":
                        storage.BinarySearch(int.Parse(Console.ReadLine()));
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
        private static void RanRandomGeneration()
        {
            var placeGenerator = new PersonNameGenerator();
            var randomNumberGenerator = new Random();
            var storage = new PhonesStorage();
            
            for (var i = 0; i < 10; i++)
            {
                var newRecord = new PhoneRecord(placeGenerator.GenerateRandomFirstName(),
                    placeGenerator.GenerateRandomLastName(),
                    $"{randomNumberGenerator.Next(38010, 38099)}" +
                        $"{randomNumberGenerator.Next(1111111, 9999999)}");
                storage.Save(newRecord);
            }
      
        }
    }
}