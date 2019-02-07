using System;

namespace PlayingWithEnumsLib
{
	public static class StringExtensions
	{
		public static bool IsNotNullOrEmpty(this string value)
		{
			return !String.IsNullOrEmpty(value);
		}
	}
}
