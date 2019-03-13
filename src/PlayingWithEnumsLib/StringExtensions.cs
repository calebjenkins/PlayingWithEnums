using System;
using System.Collections.Generic;

namespace PlayingWithEnumsLib
{
	public static class StringExtensions
	{
		public static bool IsNotNullOrEmpty(this string value)
		{
			return !String.IsNullOrEmpty(value);
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return String.IsNullOrEmpty(value);
		}

		public static bool Compare(this string string1, string string2)
		{
			var returnValue = false;
			if (string1.IsNotNullOrEmpty())
			{
				returnValue = string1.Equals(string2, StringComparison.CurrentCultureIgnoreCase);
			}
			return returnValue;
		}
		public static string ToDelimitedList(this List<string> list, string delimiter)
		{
			return string.Join(delimiter, list.ToArray());
		}

		public static void ToUpper(this List<string> list)
		{
			for (var i = 0; i < list.Count; i++)
			{
				list[i] = list[i].ToUpper();
			}
		}
	}
}
