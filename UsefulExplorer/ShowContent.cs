using System;
using System.IO;

namespace UsefulExplorer
{
	class ShowContent
	{
		private static long totalsize;
		private static int mainpathcount;
		private static long files = 0;
		private static long folders = 0;
		private static DirectoryInfo directoryInfo;
		private static FileInfo fileinfo;

		public static void init(string mainpath)
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
				for (int i = 0; i < ShowContent.getHowManyPaths(path) - ShowContent.mainpathcount; i++)
				{
					Console.Write("----");
				}
				ShowContent.directoryInfo = new DirectoryInfo(path);
				Console.WriteLine("+" + ShowContent.directoryInfo.Name);
				ShowContent.folders++;
				foreach (string item in Directory.GetFileSystemEntries(path))
				{
					ShowContent.listFiles(item);
				}
			}
			else if (File.Exists(path))
			{
				for (int i = 0; i < ShowContent.getHowManyPaths(path) - ShowContent.mainpathcount; i++)
				{
					Console.Write("----");
				}
				ShowContent.fileinfo = new FileInfo(path);
				Console.WriteLine(ShowContent.fileinfo.Name + " - " + ShowContent.fileinfo.LastAccessTimeUtc.ToString() + " - " + ShowContent.fileinfo.Length + " Bytes");
				ShowContent.files++;
				ShowContent.totalsize += ShowContent.fileinfo.Length;
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
		public static long getFileAmount()
		{
			return ShowContent.files;
		}
		public static long getFolderAmount()	
		{
			return ShowContent.folders;
		}
	}
}
