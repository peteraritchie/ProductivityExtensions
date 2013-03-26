using System;
using System.Globalization;
using System.Text;

namespace PRI.ProductivityExtensions.ByteArrayExtensions
{
	static public partial class ByteArrayable
	{
		public static string AsHexString(this byte[] buffer, int offset, int length)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int line = 0;
			int lineOctet = 0;
			for (int i = offset; i < length; ++i)
			{
				byte b = buffer[i];
				if (lineOctet > 16)
				{
					stringBuilder.Append(Environment.NewLine);
					++line;
					lineOctet = 0;
				}
				stringBuilder.Append(String.Format("{0} ", b.ToString("X2", CultureInfo.CurrentCulture)));
			}
			return stringBuilder.ToString();
		}

		public static String AsHexString(this byte[] buffer)
		{
			return AsHexString(buffer, 0, buffer.Length);
		}
	}
}