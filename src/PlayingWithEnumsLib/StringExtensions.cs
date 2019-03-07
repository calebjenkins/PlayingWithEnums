using System;

namespace PlayingWithEnumsLib
{
	public static class StringExtensions
	{
		public static bool IsNotNullOrEmpty(this string value)
		{
			return !String.IsNullOrEmpty(value);
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
	}
}
