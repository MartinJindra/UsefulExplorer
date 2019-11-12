using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulExplorer
{
	/**
	 * This class is used to convert bytes into more human readable sizes.
	 * @author Martin Jindra
	 * @version 12.11.2019
	 */
	class ByteConverter
	{
		/**
		 * It coverts a size of a folder or file in a more human readable form.
		 * @param size the size of a file or folder in bytes
		 * @return a converted string from the size in a more human readable form
		 */
		public static string convert(double size)
		{
			string s = "";
			int j = 0;
			for (int i = 0; i < ("" + size).Length / 3 - 1; i++)
			{
				size = size / 1024;
				j = i;
			}
			switch (j)
			{
				case 0:
					s = "" + (Math.Round(size * 100.0) / 100) + " KB";
					break;
				case 1:
					s = "" + (Math.Round(size * 100.0) / 100) + " MB";
					break;
				case 2:
					s = "" + (Math.Round(size * 100.0) / 100) + " GB";
					break;
				case 3:
					s = "" + (Math.Round(size * 100.0) / 100) + " TB";
					break;
				case 4:
					s = "" + (Math.Round(size * 100.0) / 100) + " PB";
					break;
				case 5:
					s = "" + (Math.Round(size * 100.0) / 100) + " EB";
					break;
				case 6:
					s = "" + (Math.Round(size * 100.0) / 100) + " ZB";
					break;
				case 7:
					s = "" + (Math.Round(size * 100.0) / 100) + " YB";
					break;
				default:
					s = "" + size + " Bytes";
					break;
			}
			return s;
		}
	}
}
