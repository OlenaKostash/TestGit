
using Geolocation;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace LinqLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            //var male = persons.Where(p => p.Gender == Gender.Male).Count();
            //var female = persons.Where(p => p.Gender == Gender.Female).Count();
            //Console.WriteLine($"male - {male}; female - {female}");

            //var presonsFriends = persons.OrderByDescending(p => p.Friends.Length).First();

            //var maxTage = persons.OrderByDescending(p => p.Tags);

            //var listTags = new List<string>();
            //persons.ToList().ForEach(p => listTags.AddRange(p.Tags));
            //var f = listTags.GroupBy(t => t).OrderByDescending(g => g.Count()).First();

            //HOMEWORK
            var maxLatitude = persons.Max(p => p.Latitude);
            var minLatitude = persons.Min(p => p.Latitude);
            var maxLongitude = persons.Max(p => p.Longitude);
            var minLongitude = persons.Min(p => p.Longitude);

            var personFarthestNorth = persons.Where(p => p.Latitude.Equals(maxLatitude)).First().Name;
            var personFarthestSouth = persons.Where(p => p.Latitude.Equals(minLatitude)).First().Name;
            var personFarthestEast = persons.Where(p => p.Longitude.Equals(maxLongitude)).First().Name;
            var personFarthestWest = persons.Where(p => p.Longitude.Equals(minLongitude)).First().Name;

            Console.WriteLine($"the person who is farthest north - {personFarthestNorth}; farthest south - {personFarthestSouth}; " +
                $"farthest east - {personFarthestEast}; farthest west - {personFarthestWest}");

            Console.WriteLine("");
            var listOfDictance = persons.SelectMany(p =>
            {
                var result = persons.Where(fp => fp.Guid != p.Guid)
                .Select(pn => GeoCalculator.GetDistance(p.Latitude, p.Longitude, pn.Latitude, pn.Longitude, 1, DistanceUnit.Kilometers));
                return result;
            }).ToList();
            Console.WriteLine($"min distance is {listOfDictance.Min()}km and max is {listOfDictance.Max()}km");

            Console.WriteLine("");
            var listOfPersonEntety = persons.Select(p =>
            {
                var result = new 
                {
                    Id = p.Id,
                    Words = p.About.ToLower().Split(" ").Distinct().ToList(),
                    MatchResults = new Dictionary<string, int>()
                };
                return result;
            }).ToList();

            foreach (var personEntety in listOfPersonEntety)
            {
                foreach (var personEntetyX in listOfPersonEntety)
                {
                    if (personEntety.Id != personEntetyX.Id && !personEntety.MatchResults.ContainsKey(personEntetyX.Id))
                        personEntety.MatchResults.Add(personEntetyX.Id, personEntety.Words.Intersect(personEntetyX.Words).Count());
                }
            }

            var result = listOfPersonEntety.SelectMany(person =>
            {
                var stream = person
                    .MatchResults
                    .Select(dd => (person.Id, dd.Key, dd.Value));

                return stream;
            }).MaxBy(p => p.Value);
            Console.WriteLine($"person with id {result.Id} and {result.Key} have the most same words in count {result.Value}");

            Console.WriteLine("");
            var listOfPersonFriends = persons.Select(p =>
            {
                var result = new
                {
                    Id = p.Id,
                    ListOfFriends = p.Friends.Select(f => f.Name).Order()
                };
                return result;
            }).ToList();

            var listOfMachingFriends = listOfPersonFriends.SelectMany(l1 =>
            {
                var result = listOfPersonFriends
                .Where(l2 => l1.Id != l2.Id && Enumerable.SequenceEqual(l1.ListOfFriends, l2.ListOfFriends))
                .Select(l => (l1.Id, l.Id));
                return result;
            });
            if (listOfMachingFriends.Count() != 0)
            {
                Console.WriteLine("If we compare all friends - then:");
                listOfMachingFriends.ToList().ForEach(l => Console.WriteLine($"person with Id {l.Item1} have equal lists of Friends with persont {l.Item2}"));
            }
        }
    }
}
  