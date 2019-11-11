using System;
using System.Collections.Generic;

/**
 * 
 * @author Martin Jindra
 * @version 11.11.2019
 */
namespace UsefulExplorer
{
	class Controller
	{
		private Dictionary<string, string> arg;
		private ShowContent showContent;
		private ShowBiggest showBiggest;

		public Controller(string[] args)
		{
			this.showContent = new ShowContent();
			this.showBiggest = new ShowBiggest();
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
						if (args.Length > 1)
						{
							this.arg.Add("-l", args[i + 1]);
							if (this.arg.ContainsKey("-l"))
							{
								ShowContent.listFiles(this.arg["-l"]);
								string s = ShowContent.getOutputAtOnce();
								Console.WriteLine(s.Substring(1, s.Length - 1));
							}
						}
						else
						{
							Console.WriteLine("second argument is missing");
						}
					}
					else if (args[i] == "-b")
					{
						if (args.Length > 1)
						{
							this.arg.Add("-l", args[i + 1]);
							if (this.arg.ContainsKey("-b"))
							{
								ShowBiggest.listFiles(this.arg["-b"]);
								string s = ShowBiggest.getBiggest();
								Console.WriteLine(s);
							}
						}
						else
						{
							Console.WriteLine("second argument is missing");
						}
					}
				}
			}
			else
			{
				Console.WriteLine("Nothing to do");
			}
		}

		static void Main(string[] args)
		{
			new Controller(args);
		}
	}
}
