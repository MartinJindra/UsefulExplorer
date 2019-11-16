using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace UsefulExplorer
{
	class ShowBiggestFiles
	{
		private static List<string> paths;
		private static Dictionary<int ,long> sizes;
		private static FileInfo fileinfo;
		private static int index;
		private static int num;

		public static void init(int num)
		{
			ShowBiggestFiles.paths = new List<string>();
			ShowBiggestFiles.sizes = new Dictionary<int, long>();
			ShowBiggestFiles.index = 0;
			ShowBiggestFiles.num = num;
		}

		public static void listFiles(string path)
		{
			if (Directory.Exists(path))
			{
				foreach (string item in Directory.GetFileSystemEntries(path))
				{
					ShowBiggestFiles.listFiles(item);
				}
			}
			else if (File.Exists(path))
			{
				ShowBiggestFiles.fileinfo = new FileInfo(path);
				ShowBiggestFiles.paths.Add(path);
				ShowBiggestFiles.sizes.Add(ShowBiggestFiles.index, ShowBiggestFiles.fileinfo.Length);
				ShowBiggestFiles.index++;	
			}
		}

		public static void sortBiggest()
		{
			bool tausch = true;
			long sizetmp;
			string pathtmp;
			for (int i = 1; i < ShowBiggestFiles.sizes.Count; i++)
			{
				for (int i1 = 0; i1 < ShowBiggestFiles.sizes.Count - i; i1++)
				{
					if (ShowBiggestFiles.sizes[i1] > ShowBiggestFiles.sizes[i1 + 1])
					{
						tausch = false;

						sizetmp = ShowBiggestFiles.sizes[i1 + 1];
						ShowBiggestFiles.sizes[i1 + 1] = ShowBiggestFiles.sizes[i1];
						ShowBiggestFiles.sizes[i1] = sizetmp;

						pathtmp = ShowBiggestFiles.paths[i1 + 1];
						ShowBiggestFiles.paths[i1 + 1] = ShowBiggestFiles.paths[i1];
						ShowBiggestFiles.paths[i1] = pathtmp;
					}
					if (ShowBiggestFiles.sizes[i1] > ShowBiggestFiles.sizes[i1 + 1] && tausch == true)
					{
						sizetmp = ShowBiggestFiles.sizes[i1];
						ShowBiggestFiles.sizes[i1] = ShowBiggestFiles.sizes[i1 + 1];
						ShowBiggestFiles.sizes[i1 + 1] = sizetmp;

						pathtmp = ShowBiggestFiles.paths[i1];
						ShowBiggestFiles.paths[i1] = ShowBiggestFiles.paths[i1 + 1];
						ShowBiggestFiles.paths[i1 + 1] = pathtmp;
					}
				}
			}
		}

		public static void show()
		{
			for (int i = ShowBiggestFiles.sizes.Count - 1, j = 0; i > -1; i--, j++)
			{
				if (j < ShowBiggestFiles.num)
				{
					Console.WriteLine((j + 1) + ". " + ShowBiggestFiles.paths[i] + " - " + ByteConverter.convert(ShowBiggestFiles.sizes[i]) + " Bytes");
				}
				else break;
			}
		}
	}
}
