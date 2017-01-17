using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Lib;
using Mono.Options;

namespace DeZoner
{
	class Program
	{
		static void Main(string[] args)
		{
			string directory = null;
			string file = null;
			var pattern = "*.*";
			var recurse = false;
			string verb = null;
			var help = false;

			var options = new OptionSet
			{
				{ "get|remove", "verb", v => verb = v},
				{ "d|dir:", "directory", d => directory = d},
				{ "f|file:", "file", f => file = f},
				{ "p|pattern:", "pattern", p => pattern = p},
				{ "r|recurse", "recurse", r => recurse = true},
				{ "?|h|help", "print help", h => help = true},
			};

			options.Parse(args);

			if (help)
			{
				options.WriteOptionDescriptions(Console.Out);
				return;
			}

			string[] files = null;
			if (file != null)
			{
				files = new[] {file};
			}
			else
			{
				if (directory == null)
				{
					directory = Directory.GetCurrentDirectory();
				}
				files = Directory.GetFiles(directory, pattern, recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			}

			
			if (files.Length == 0)
			{
				Console.Error.WriteLine("no files");
				return;
			}

			var handler = new Handler(verb);
			handler.Execute(files);

			if (Debugger.IsAttached)
			{
				Console.WriteLine("Press ENTER to exit...");
				Console.ReadLine();
			}
		}

		static void Main0(string[] args)
		{
			if (args.Length < 2)
			{
				// error
				Console.Error.WriteLine("incorrect arguments");
				return;
			}

			var verb = args[0];

			// assume all files in current directory
			var directory = Directory.GetCurrentDirectory();
			string[] files = null;

			if (args.Length == 1)
			{
				files = Directory.GetFiles(directory);
			}
			if (args.Length == 2)
			{
				// arg might be:
				// directory
				// file
				// wildcard
				if (Directory.Exists(args[1]))
				{
					// assume all files in this directory
					files = Directory.GetFiles(args[1]);
				}
				else if (File.Exists(args[1]))
				{
					// assume on this file
					files = new[] {args[1]};
				}
				else
				{
					// assume a wildcard
					files = Directory.GetFiles(directory, args[1]);
				}
			}
			if (args.Length == 3)
			{
				files = Directory.GetFiles(args[1], args[2]);
			}

			if (files == null || files.Length == 0)
			{
				Console.Error.WriteLine("no files");
				return;
			}

			var handler = new Handler(verb);
			handler.Execute(files);

			if (Debugger.IsAttached)
			{
				Console.WriteLine("Press ENTER to exit...");
				Console.ReadLine();
			}
		}
	}

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