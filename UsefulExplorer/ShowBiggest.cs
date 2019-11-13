using System;
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

		private static long totalsize;
		private static int mainpathcount;
		private static FileInfo fileinfo;

		public static void setMainPath(string mainpath)
		{
			ShowBiggest.mainpathcount = ShowBiggest.getHowManyPaths(mainpath);

		}

		public static long getTotalSize()
		{
			return ShowBiggest.totalsize;
		}

		public static void listFiles(string path)
		{
			if (Directory.Exists(path))
			{
				foreach (string item in Directory.GetFileSystemEntries(path))
				{
					ShowBiggest.listFiles(item);
				}
			}
			else if (File.Exists(path))
			{
				ShowBiggest.fileinfo = new FileInfo(path);

			}
		}

		private static int getHowManyPaths(string path)
		{
			int num = -1;
			string s = Path.GetFullPath(path);
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '\\' || s[i] == '/')
				{
					num++;
				}
			}
			return num;
		}
	}
}
}
