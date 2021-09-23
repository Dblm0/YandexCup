using System;
using System.Linq;

char[] J = Console.ReadLine().Distinct().ToArray();
var S = Console.ReadLine()
    .GroupBy(x => x)
    .ToDictionary(x => x.Key, x => x.Count());

Console.WriteLine($"{S.Where(x => J.Contains(x.Key)).Sum(x => x.Value)}");
