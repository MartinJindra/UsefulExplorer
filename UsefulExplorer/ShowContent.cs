using System;
using System.IO;

namespace UsefulExplorer
{
	class ShowContent
	{
		private static long totalsize;
		private static bool first;
		private static int mainpathcount;

		public ShowContent()
		{
			ShowContent.first = true;
			ShowContent.totalsize = 0;
		}

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
			int num;
			if (!ShowContent.first)
			{
				num = ShowContent.getHowManyPaths(path) - ShowContent.mainpathcount;
			}
			else
			{
				num = 0;
				ShowContent.first = false;
			}
			if (File.Exists(path))
			{
				DateTime d = File.GetLastAccessTime(path);
				for (int i = 0; i < num; i++)
				{
					Console.Write("\t");
				}
				Console.WriteLine(Path.GetFileName(path) + " - " + d.Date + " - " + new FileInfo(path).Length + " Bytes");
				ShowContent.totalsize += new FileInfo(path).Length;
			}
			else if (Directory.Exists(path))
			{
				for (int i = 0; i < num; i++)
				{
					Console.Write("\t");
				}
				Console.Write("+");
				// for the first folder full name
				if (ShowContent.first)
				{
					Console.WriteLine(Path.GetFullPath(path));
				}
				else
				{
					Console.WriteLine(Path.GetFileName(path));
				}

				foreach (string s in Directory.GetFileSystemEntries(path, "*.*", SearchOption.AllDirectories))
				{
					ShowContent.listFiles(s);
				}
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
