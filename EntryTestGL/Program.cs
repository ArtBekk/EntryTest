using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntryTestGL
{
	class Program
	{
		static void Main(string[] args)
		{
			//Уровень 1 и 6
			List<string> parsedWords = new List<string>();
			if (args.Length != 0)
			{
				parsedWords = new List<string>(args);
			}
			else
			{
				string input = null;
				using (StreamReader reader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding))
				{
					input = reader.ReadToEnd();
				}
				input = input.Trim().Trim('"');
				parsedWords = new List<string>(input.Split(' '));
			}
			Console.WriteLine(Environment.NewLine + "Level 1: ");
			foreach (string temp in parsedWords)
				Console.WriteLine(temp);
			//Уровень 2
			var sortedWords = parsedWords.OrderBy(i => i);
			Console.WriteLine(Environment.NewLine + "Level 2, sorted alphabetically: ");
			foreach (string temp in sortedWords)
				Console.WriteLine(temp);
			//Уровень 3
			var uniqWords = parsedWords.GroupBy(i => i);
			Console.WriteLine(Environment.NewLine + "Level 3, unique only: ");
			foreach (var temp in uniqWords)
				Console.WriteLine(temp.Key);
			//Уровень 4
			Console.WriteLine(Environment.NewLine + "Level 4, counted occurrences: ");
			foreach (var temp in uniqWords)
			{
				Console.WriteLine("{0} {1}", temp.Key, temp.Count());
			}
			//Уровень 5
			Console.WriteLine(Environment.NewLine + "Level 5, sorted by occurrences then alphabetically: ");
			uniqWords = uniqWords.OrderByDescending(i => i.Count()).ThenBy(i => i.Key);
			foreach (var temp in uniqWords)
			{
				Console.WriteLine("{0} {1}", temp.Key, temp.Count());
			}
		}
	}
}