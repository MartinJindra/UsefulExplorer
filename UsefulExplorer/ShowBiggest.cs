using System.IO;
using System.Collections.Generic;

namespace UsefulExplorer
{
	class ShowBiggest
	{
		private static Dictionary<string, long> output = new Dictionary<string, long>();

		public static string getBiggest()
		{
			return ShowBiggest.output.ToString();
		}

		public static void listFiles(string path)
		{
			if (File.Exists(path))
			{
				System.Console.WriteLine(path + "\t" + new FileInfo(path).Length);
				// ShowBiggest.output.Add(path, new FileInfo(path).Length);
			}
			else if (Directory.Exists(path))
			{
				foreach (string s in Directory.GetFileSystemEntries(path, "*.*", SearchOption.AllDirectories))
				{
					ShowBiggest.listFiles(s);
				}
			}
		}
	}
}
