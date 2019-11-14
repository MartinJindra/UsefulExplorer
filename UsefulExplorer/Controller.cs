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
			// if no argument has been given
			if (args.Length > 0)
			{
				// if one argument is -l for listing content on a directory
				if (args[0] == "-l")
				{
					// checks if there is a second argument
					if (args.Length > 1)
					{
						try
						{
							ShowContent.init(args[1]);
							ShowContent.listFiles(args[1]);
							Console.WriteLine("Total size of folder \'" + args[1] + "\': " + ByteConverter.convert(ShowContent.getTotalSize()));
						} catch (UnauthorizedAccessException unauthorized)
						{
							Console.WriteLine("A path is not accessable:\t" + unauthorized.Message);
						}			
					}
					// writes error message if second argument is missing. In this case the path
					else
					{
						Console.WriteLine("second argument is missing");
					}
				}
				// if one argument is -b for listing the biggest files in a directory
				else if (args[0] == "-b")
				{
					if (args.Length > 2)
					{
						try
						{
							ShowBiggest.init();
							ShowBiggest.listFiles(args[2]);
						}
						catch(UnauthorizedAccessException unauthorized)
						{
							Console.WriteLine("A path is not accessable:\t" + unauthorized.Message);
						}
						// ShowBiggest.showBiggest(int.Parse(args[1]));
					}
					// writes error message if second argument is missing. In this case the path
					else
					{
						Console.WriteLine("second and/or thired argument(s) is/are missing");
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
			args = new string[3];
			args[0] = "-b";
			args[1] = "10";
			args[2] = "E:\\TGM\\4.Klasse";
			
			new Controller(args);
		}
	}
}
