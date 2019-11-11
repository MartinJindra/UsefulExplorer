using System;
using System.IO;
using System.Text;

namespace UsefulExplorer
{
	class Directories
	{
		private static StringBuilder output;

		public Directories()
		{
			Directories.output = new StringBuilder();
		}

		public static string getOutput()
		{
			return Directories.output.ToString();
		}

		public static void listFiles(string path)
		{
			short num = Directories.getHowManyPaths(path);
			if (File.Exists(path))
			{
				DateTime d = File.GetLastAccessTime(path);
				for (int i = 0; i < num; i++)
				{
					Directories.output.Append("\t");
				}
				Directories.output.Append(Path.GetFileName(path));
				Directories.output.Append(" - ");
				Directories.output.Append(d.Date);
				Directories.output.Append(" - ");
				Directories.output.Append(new FileInfo(path).Length);
				Directories.output.Append(" Bytes\n");
			}
			else if (Directory.Exists(path))
			{
				for (int i = 0; i < num - 1; i++)
				{
					Directories.output.Append("\t");
				}
				Directories.output.Append("+");
				Directories.output.Append(Path.GetFullPath(path));
				Directories.output.Append("\n");


				foreach (string s in Directory.GetFileSystemEntries(path, "*.*", SearchOption.AllDirectories))
				{
					Directories.output.Append("\n");
					Directories.listFiles(s);
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
