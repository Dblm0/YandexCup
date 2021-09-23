using System;
using System.IO;
using System.Linq;

Func<string> fileSource = () => File.ReadLines("input.txt").First();
Func<string> stdSource = () => Console.ReadLine();

Action<string> fileOutput = (res) => File.WriteAllText("output.txt", res);
Action<string> stdOutput = (res) => Console.WriteLine(res);

var nums = fileSource().Split(' ').Select(x => int.Parse(x)).Take(2);
fileOutput($"{nums.Sum()}");


