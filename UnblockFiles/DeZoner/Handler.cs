using System;
using System.Collections.Generic;
using System.IO;
using Lib;

namespace DeZoner
{
	public class Handler
	{
		private readonly string _verb;

		public Handler(string verb)
		{
			_verb = verb;
		}

		public void Execute(string[] files)
		{
			if ("get".Equals(_verb, StringComparison.OrdinalIgnoreCase))
			{
				Get(files);
				return;
			}

			if ("remove".Equals(_verb, StringComparison.OrdinalIgnoreCase))
			{
				Remove(files);
				return;
			}

			throw new Exception($"{_verb} is unsupported");
		}

		public void Remove(string[] files)
		{
			foreach (var file in files)
			{
				ZoneHelper.Remove(file);
				Console.WriteLine(file);
			}
		}

		public void Get(string[] files)
		{
			var maxFileLen = 0;
			var maxZoneLen = 0;
			var results = new Dictionary<string, string>();
			foreach (var file in files)
			{
				var zone = ZoneHelper.GetZone(file);
				//Console.WriteLine($"{Path.GetFileName(file)}\t{zone}");
				Console.Write(".");
				var filename = Path.GetFileName(file);
				results.Add(file, zone);
				maxFileLen = Math.Max(maxFileLen, filename.Length);
				maxZoneLen = Math.Max(maxZoneLen, zone.Length);
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"{"Filename".PadRight(maxFileLen)}\tResult");
			Console.WriteLine($"{"--------".PadRight(maxFileLen)}\t------");
			foreach (var file in results.Keys)
			{
				var filename = Path.GetFileName(file);
				Console.WriteLine($"{filename.PadRight(maxFileLen)}\t{results[file]}");
			}
		}
	}
}