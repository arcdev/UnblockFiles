using System;
using System.Diagnostics;
using System.IO;
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
				{"get|remove", "verb", v => verb = v},
				{"d|dir:", "directory", d => directory = d},
				{"f|file:", "file", f => file = f},
				{"p|pattern:", "pattern", p => pattern = p},
				{"r|recurse", "recurse", r => recurse = true},
				{"?|h|help", "print help", h => help = true}
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
	}
}