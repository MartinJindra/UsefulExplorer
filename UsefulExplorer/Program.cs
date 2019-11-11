using System;
using System.Collections.Generic;

/**
 * 
 * @author Martin Jindra
 * @version 11.11.2019
 */
namespace UsefulExplorer
{
	class Program
	{
		private Dictionary<string, string> arg;
		private Directories dir;

		public Program(string[] args)
		{
			this.dir = new Directories();
			this.init(args);
		}

		private void init(string[] args)
		{
			if (args.Length > 0)
			{
				this.arg = new Dictionary<string, string>();
				for (int i = 0; i < args.Length; i++)
				{
					if (args[i] == "-l")
					{
						this.arg.Add("-l", args[i + 1]);
					}
				}
				if (this.arg.ContainsKey("-l"))
				{
					Directories.listFiles(this.arg["-l"]);
					string s = Directories.getOutputAtOnce();
					Console.WriteLine(s.Substring(1, s.Length - 1));
				}
			}
			else
			{
				Console.WriteLine("Nothing to do");
			}
		}

		static void Main(string[] args)
		{
			new Program(args);
		}
	}
}
