﻿using System;
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
			List<string> container = new List<string>();
			if (args.Length != 0)
			{
				container = new List<string>(args);
			}
			else
			{
				Stream inputStream = Console.OpenStandardInput();
				byte[] bytes = new byte[512];
				int outputLength = inputStream.Read(bytes, 0, 512);
				char[] chars = Encoding.UTF8.GetChars(bytes, 0, outputLength);
				string input = new string(chars);
				input = input.Trim().Trim('"');
				//input = input.Substring(1, input.Length - 2);
				Console.Write(input + input.Length);
				container = new List<string>(input.Split(' '));
			}
			//Уровень 1
			Console.WriteLine(Environment.NewLine + "Level 1: ");
			foreach (string temp in container)
				Console.WriteLine(temp);
			//Уровень 2
			var sortedWords = container.OrderBy(i => i);
			Console.WriteLine(Environment.NewLine + "Level 2, sorted alphabetically: ");
			foreach (string temp in sortedWords)
				Console.WriteLine(temp);
			//Уровень 3
			var uniqWords = container.GroupBy(i => i);
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