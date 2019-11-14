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

		public static void init()
		{
			ShowBiggest.paths = new List<string>();
			ShowBiggest.sizes = new Dictionary<int, long>();
			ShowBiggest.index = 0;
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
				Console.WriteLine(ShowBiggest.index + ", " + ShowBiggest.fileinfo.Length);
				ShowBiggest.index++;	
			}
		}

		public static void sortBiggest(int num)
		{
			bool tausch = true;
			double cache = 0;
			for (int i = 1; i < ShowBiggest.sizes.Count; i++)
			{
				for (int i1 = 0; i1 < ShowBiggest.sizes.Count - i; i1++)
				{
					if (ShowBiggest.sizes[i1] > ShowBiggest.sizes[i1 + 1])
					{
						tausch = false;
						cache = array[i1 + 1];
						array[i1 + 1] = array[i1];
						array[i1] = cache;
					}
					if (array[i1] > array[i1 + 1] && tausch == true)
					{
						cache = array[i1];
						array[i1] = array[i1 + 1];
						array[i1 + 1] = cache;
					}
				}
			}
			return array;
		}
		*/
	}
}
