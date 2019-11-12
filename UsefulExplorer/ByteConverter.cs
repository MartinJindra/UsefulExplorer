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
		public static string convert(long size)
		{
			string s = ""
			for (int i = 0; i < ("" + size).Length / 3 - 1; i++)
			{
				size = size / 1000;
			}

			return size;
		}
	}
}
