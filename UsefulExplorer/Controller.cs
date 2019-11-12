using System;
using System.Collections.Generic;

namespace UsefulExplorer
{
	/**
	* The controller of the programm that manages the input from the cli.
	* @author Martin Jindra
	* @version 11.11.2019
	*/
	class Controller
	{
		private Dictionary<string, string> arg;

		public Controller(string[] args)
		{
			this.init(args);
		}

		/**
		 * Initializes all processes running
		 * @param args arguments given by CLI
		 */
		private void init(string[] args)
		{
			if (args.Length > 0)
			{
				this.arg = new Dictionary<string, string>();
				// goes through every argument given by CLI
				for (int i = 0; i < args.Length; i++)
				{
					// if one argument is -l for listing content on a directory
					if (args[i] == "-l")
					{
						// checks if there is a second argument
						if (args.Length > 1)
						{
							this.arg.Add("-l", args[i + 1]);
							if (this.arg.ContainsKey("-l"))
							{
								ShowContent.setMainPath(this.arg["-l"]);
								ShowContent.listFiles(this.arg["-l"]);
								Console.WriteLine("Total size of folder \'" + this.arg["-l"] + "\':\t" + ByteConverter.convert(ShowContent.getTotalSize()));
							}
						}
						// writes error message if second argument is missing. In this case the path
						else
						{
							Console.WriteLine("second argument is missing");
						}
					}
					// if one argument is -b for listing the biggest files in a directory
					else if (args[i] == "-b")
					{
						if (args.Length > 1)
						{
							this.arg.Add("-b", args[i + 1]);
							if (this.arg.ContainsKey("-b"))
							{
								ShowBiggest.listFiles(this.arg["-b"]);
								string s = ShowBiggest.getBiggest();
								Console.WriteLine(s);
							}
						}
						// writes error message if second argument is missing. In this case the path
						else
						{
							Console.WriteLine("second argument is missing");
						}
					}
				}
			}
			// writes error message if no arguments are given
			else
			{
				Console.WriteLine("Nothing to do");
			}
		}

		static void Main(string[] args)
		{
			args = new string[2];
			args[0] = "-l";
			args[1] = "E:\\TGM";
			new Controller(args);
		}
	}
}
