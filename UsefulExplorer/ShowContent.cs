using System;
using System.IO;
using System.Text;

namespace UsefulExplorer
{
	class ShowContent
	{
		private static StringBuilder output;
		private static bool first;

		public ShowContent()
		{
			ShowContent.output = new StringBuilder();
			ShowContent.first = true;
		}

		public static string getOutputAtOnce()
		{
			return ShowContent.output.ToString();
		}

		public static void listFiles(string path)
		{
			short num;
			if (!ShowContent.first)
			{
				num = ShowContent.getHowManyPaths(path);
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
					ShowContent.output.Append("\t");
				}
				ShowContent.output.Append(Path.GetFileName(path));
				ShowContent.output.Append(" - ");
				ShowContent.output.Append(d.Date);
				ShowContent.output.Append(" - ");
				ShowContent.output.Append(new FileInfo(path).Length);
				ShowContent.output.Append(" Bytes\n");
			}
			else if (Directory.Exists(path))
			{
				for (int i = 0; i < num; i++)
				{
					ShowContent.output.Append("\t");
				}
				ShowContent.output.Append("+");
				// for the first folder full name
				if (ShowContent.first)
				{
					ShowContent.output.Append(Path.GetFullPath(path));
				}
				else
				{
					ShowContent.output.Append(Path.GetFileName(path));
				}
				ShowContent.output.Append("\n");

				foreach (string s in Directory.GetFileSystemEntries(path, "*.*", SearchOption.AllDirectories))
				{
					ShowContent.listFiles(s);
				}
			}
			ShowContent.first = false;
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
