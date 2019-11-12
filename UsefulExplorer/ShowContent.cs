using System;
using System.IO;

namespace UsefulExplorer
{
	class ShowContent
	{
		private static long totalsize;
		private static bool first = true;
		private static int mainpathcount = 0;
		private static FileInfo fileinfo;
		private static DateTime d;

		public static void setMainPath(string mainpath)
		{
			ShowContent.mainpathcount = ShowContent.getHowManyPaths(mainpath);

		}

		public static long getTotalSize()
		{
			return ShowContent.totalsize;
		}

		public static void listFiles(string path)
		{
			if (Directory.Exists(path))
			{
				Console.WriteLine(path);
				foreach (string item in Directory.GetFileSystemEntries(path))
				{
					
					ShowContent.listFiles(item);
				}
			}
			else if (File.Exists(path))
			{
				ShowContent.fileinfo = new FileInfo(path);
				Console.WriteLine(path + " - " + ShowContent.fileinfo.LastAccessTimeUtc.ToString() + " - " + ShowContent.fileinfo.Length + " Bytes");
			}
		}

		private static short getHowManyPaths(string path)
		{
			short num = -1;
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
