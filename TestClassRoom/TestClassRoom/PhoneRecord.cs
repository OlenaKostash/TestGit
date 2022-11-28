using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace TestClassRoom
{
    internal partial class Program
    {
        class PhoneRecord
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }


            public PhoneRecord()
            {
                FirstName   = ReadStringFromConsole("Please enter firs name:");
                LastName    = ReadStringFromConsole("Please enter last name:");
                PhoneNumber = ReadPhoneNumberFromConsole("Please enter phone number:");
            }
            public PhoneRecord(string fName, string lName, string pNumber)
            {
                FirstName = fName;
                LastName = lName;
                PhoneNumber = pNumber;
            }

            public void Edit()
            {
                FirstName = ReadStringFromConsole("Please enter firs name:", FirstName);
                LastName = ReadStringFromConsole("Please enter last name:", LastName);
                PhoneNumber = ReadPhoneNumberFromConsole("Please enter phone number:", PhoneNumber);
            }
            private string ReadStringFromConsole(string messageText, string prefill = "")
            {
                do
                {     
                    var input = ReadLine.Read(messageText, prefill);
                    Console.WriteLine(input);
                    if (!string.IsNullOrWhiteSpace(input))
                        return input.Trim();
                    else
                        continue;
                } while (true);
            }
            private string ReadPhoneNumberFromConsole(string messageText, string prefill = "")
            {
                do
                {
                    var input = ReadLine.Read(messageText, prefill);
                    if (!string.IsNullOrWhiteSpace(input)
                        && input.Trim().Length == 12
                        && input.ToList().All(symbol => char.IsNumber(symbol)))
                        return input.Trim();
                    else
                        continue;
                } while (true);
            }
        }  
    }
}