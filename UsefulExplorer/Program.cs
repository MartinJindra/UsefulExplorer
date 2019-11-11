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
				}
			}
			else
			{
				Console.WriteLine("Nothing to do");
			}
		}

		static void Main(string[] args)
		{
			args = new string[2];
			args[0] = "-l";
			args[1] = "D:\\Handy\\Handy.tar.gz";
			
			new Program(args);
		}
	}
}
