using System;
using System.IO;

namespace UsefulExplorer
{
	class Directories
	{
		private string path;

		public Directories() {}

		public Directories(string path)
		{
			if (path != null)
			{
				this.setPath(path);
			}
		}

		public void setPath(string path)
		{
			this.path = path;
		}

		public string getPath()
		{
			return this.path;
		}

		public static void listFiles(string path)
		{
			short num = Directories.getHowManyPaths(path);
			if (File.Exists(path))
			{
				DateTime d = File.GetLastAccessTime(path);
				for (int i = 0; i < num; i++)
				{
					Console.Write("\t");
				}
				Console.WriteLine(Path.GetFileName(path) + " - " + d.Date +  " - " + new FileInfo(path).Length + " Bytes");
			}
			else if (Directory.Exists(path))
			{
				for (int i = 0; i < num; i++)
				{
					Console.Write("\t");
				}
				Console.WriteLine("+" + Path.GetFullPath(path));
				foreach (string s in Directory.GetFiles(path))
				{
					Console.WriteLine(s);
				}
			}
		}

		private static short getHowManyPaths(string path)
		{
			short num = 0;
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
