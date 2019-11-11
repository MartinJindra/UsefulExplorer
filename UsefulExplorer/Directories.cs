using System;
using System.IO;
using System.Text;

namespace UsefulExplorer
{
	class Directories
	{
		private static StringBuilder output;
		private static bool first;

		public Directories()
		{
			Directories.output = new StringBuilder();
			Directories.first = true;
		}

		public static string getOutputAtOnce()
		{
			return Directories.output.ToString();
		}

		public static void listFiles(string path)
		{
			short num;
			if (!Directories.first)
			{
				num = Directories.getHowManyPaths(path);
			}
			else
			{
				num = 1;
			}
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
				for (int i = 0; i < num; i++)
				{
					Directories.output.Append("\t");
				}
				Directories.output.Append("+");
				// for the first folder full name
				if (Directories.first)
				{
					Directories.output.Append(Path.GetFullPath(path));
				}
				else
				{
					Directories.output.Append(Path.GetFileName(path));
				}
				Directories.output.Append("\n");

				foreach (string s in Directory.GetFileSystemEntries(path, "*.*", SearchOption.AllDirectories))
				{
					Directories.listFiles(s);
				}
			}
			Directories.first = false;
		}

		private static short getHowManyPaths(string path)
		{
			short num = -3;
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
