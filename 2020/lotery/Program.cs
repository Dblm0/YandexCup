using System;
using System.Collections.Generic;
using System.Linq;

namespace lotery
{
    class Program
    {
        static void Main(string[] args)
        {
            var chosenPool = ReadIntLine().Take(10);
            var playersCount = ReadIntLine().First();
            var playersPicks = new List<IEnumerable<int>>();
            for (int i = 0; i < playersCount; i++)
            {
                playersPicks.Add(ReadIntLine().Take(6));
            }
          
            foreach (var p in playersPicks)
            {
                Console.WriteLine(IsLucky(p, chosenPool) ? "Lucky" : "Unlucky");
            }
        }
        static bool IsLucky(IEnumerable<int> check, IEnumerable<int> target)
        {
            return check.Intersect(target).Count() >= 3;
        }
        static IEnumerable<int> ReadIntLine()
        {
            return Console.ReadLine().Split(' ').Select(x => int.Parse(x));
        }
    }
}
