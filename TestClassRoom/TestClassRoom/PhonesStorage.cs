using System;
using System.Reflection;
using System.Security.Cryptography;

namespace TestClassRoom
{
    internal partial class Program
    {
        class PhonesStorage
        {
            private readonly string DbFilePath = @"C:\Users\olena\Desktop\Study\Phonebook\phondb.csv";
            private readonly char ColumnSeparator = ',';

            public PhonesStorage()
            {
                EnshureDBFile();
            }

            public void Edit(int orderNumber)
            {
                var records = GetAllRecord();
                var index = orderNumber - 1;
                if (index < 0 || index > records.Length - 1)
                { 
                    var redBuffer = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong order number");
                    Console.ForegroundColor = redBuffer;
                }

                var yellowBuffer = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                var recordObj = DeserializeRecord(records[index]);
                Console.WriteLine("You are going to edit:");
                Print(recordObj);
                Console.ForegroundColor = yellowBuffer;

                recordObj.Edit();

                records[index] = SerializRecord(recordObj);

                File.WriteAllLines(DbFilePath, records.Select(x => x.Trim()));
            }
            public void PrintAll()
            { 
                var records = GetAllRecord();
                for (int i = 0; i < records.Length; i++)
                {
                    string? record = records[i];     
                    var deserializeRecord = DeserializeRecord(record);
                    Print(deserializeRecord, i+1);
                }
            }
            public void Search()
            {
                Console.WriteLine("Choose criteria for searching -fn (first name) -ln (last name) -p (phone number)");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "-fn":
                    case "-ln":
                    case "-p":
                        Console.WriteLine("Enter the search string:");
                        SearchByCriteria(Console.ReadLine(), input);
                        break;
                    case "-out":
                        break;
                    default:
                        break;
                }
            }

            public void BinarySearch(int orderNumber)
            {
                var records = GetAllRecord();
                int lo = 0;
                int hi = records.Length - 1;
                int mid;
                while (hi - lo > 1)
                {
                    mid = (hi + lo) / 2;
                    if (mid < orderNumber - 1)
                        lo = mid + 1;
                    else
                        hi = mid;
                }
                if (lo == orderNumber - 1)
                {
                    var recordObj = DeserializeRecord(records[lo]);
                    Print(recordObj);
                }
                else if (hi == orderNumber - 1)
                {
                    var recordObj = DeserializeRecord(records[hi]);
                    Print(recordObj);
                }
                else
                {
                    Console.WriteLine("Not Found");
                };
            }
            public void SearchByCriteria(string input, string criteria)
            {
                var records = GetAllRecord();

                List<PhoneRecord> filteredRrecords = new List<PhoneRecord>();
                if (criteria == "-fn")
                    filteredRrecords = GetAllRecord().Select(DeserializeRecord).Where(r => 
                    r.FirstName.Contains(input,StringComparison.OrdinalIgnoreCase)).ToList();
                else if (criteria == "-ln")
                    filteredRrecords = GetAllRecord().Select(DeserializeRecord).Where(r => 
                    r.LastName.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
                else
                    filteredRrecords = GetAllRecord().Select(DeserializeRecord).Where(r => 
                    r.PhoneNumber.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();

                filteredRrecords.ForEach(Print);   

            }
            public void Print(PhoneRecord phoneRecord)
            {
                Console.WriteLine($"+{phoneRecord.PhoneNumber} - {phoneRecord.FirstName} {phoneRecord.LastName}");
            }
            public void Print(PhoneRecord phoneRecord, int orderNumber)
            {
                Console.WriteLine($"[{orderNumber}]: +{phoneRecord.PhoneNumber} - {phoneRecord.FirstName} {phoneRecord.LastName}");
            }
            public void Save(PhoneRecord phoneRecord)
            {
                File.AppendAllLines(DbFilePath, new[] { SerializRecord(phoneRecord) });
            }
            public void OrderedByLastFirstNamePhone()
            {
                var records = GetAllRecord();
                List<PhoneRecord> recordsList = new List<PhoneRecord>();

                for (int i = 0; i < records.Length; i++)
                    recordsList.Add(DeserializeRecord(records[i]));

                var sortedRecords = recordsList.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.PhoneNumber).ToList();
                for (int i = 0; i < sortedRecords.Count; i++)
                  
                File.WriteAllLines(DbFilePath, sortedRecords.Select(p => SerializRecord(p).Trim()));
            }
            private string[] GetAllRecord()
            { 
                return File.ReadAllText(DbFilePath).Split('\n', StringSplitOptions.RemoveEmptyEntries);
            }
            private string SerializRecord(PhoneRecord phoneRecord)
            {
                return $"{phoneRecord.FirstName}{ColumnSeparator}" +
                    $"{phoneRecord.LastName}{ColumnSeparator}" +
                    $"{phoneRecord.PhoneNumber}{ColumnSeparator}";    
            }

            private PhoneRecord DeserializeRecord(string record)
            {
                string[] cellValues = record.Split(ColumnSeparator);
                var parsdedRecord = new PhoneRecord(cellValues[0], cellValues[1], cellValues[2]);
                return parsdedRecord;
            }
            private void EnshureDBFile()
            {
                if (!File.Exists(DbFilePath))
                {
                    using (File.Create(DbFilePath));
                }
            }
        }
    }
}