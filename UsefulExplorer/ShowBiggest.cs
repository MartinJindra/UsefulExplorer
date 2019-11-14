using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace UsefulExplorer
{
	class ShowBiggest
	{
		private static List<string> paths;
		private static Dictionary<int ,long> sizes;
		private static FileInfo fileinfo;
		private static int index;
		private static int num;

		public static void init(int num)
		{
			ShowBiggest.paths = new List<string>();
			ShowBiggest.sizes = new Dictionary<int, long>();
			ShowBiggest.index = 0;
			ShowBiggest.num = num;
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
				ShowBiggest.paths.Add(path);
				ShowBiggest.sizes.Add(ShowBiggest.index, ShowBiggest.fileinfo.Length);
				ShowBiggest.index++;	
			}
		}

		public static void sortBiggest()
		{
			bool tausch = true;
			long sizetmp;
			string pathtmp;
			for (int i = 1; i < ShowBiggest.sizes.Count; i++)
			{
				for (int i1 = 0; i1 < ShowBiggest.sizes.Count - i; i1++)
				{
					if (ShowBiggest.sizes[i1] > ShowBiggest.sizes[i1 + 1])
					{
						tausch = false;

						sizetmp = ShowBiggest.sizes[i1 + 1];
						ShowBiggest.sizes[i1 + 1] = ShowBiggest.sizes[i1];
						ShowBiggest.sizes[i1] = sizetmp;

						pathtmp = ShowBiggest.paths[i1 + 1];
						ShowBiggest.paths[i1 + 1] = ShowBiggest.paths[i1];
						ShowBiggest.paths[i1] = pathtmp;
					}
					if (ShowBiggest.sizes[i1] > ShowBiggest.sizes[i1 + 1] && tausch == true)
					{
						sizetmp = ShowBiggest.sizes[i1];
						ShowBiggest.sizes[i1] = ShowBiggest.sizes[i1 + 1];
						ShowBiggest.sizes[i1 + 1] = sizetmp;

						pathtmp = ShowBiggest.paths[i1];
						ShowBiggest.paths[i1] = ShowBiggest.paths[i1 + 1];
						ShowBiggest.paths[i1 + 1] = pathtmp;
					}
				}
			}
		}

		public static void show()
		{
			for (int i = ShowBiggest.sizes.Count - 1, j = 0; i > -1; i--, j++)
			{
				if (j < ShowBiggest.num)
				{
					Console.WriteLine((j + 1) + ". " + ShowBiggest.paths[i] + " - " + ByteConverter.convert(ShowBiggest.sizes[i]) + " Bytes");
				}
				else break;
			}
		}
	}
}
