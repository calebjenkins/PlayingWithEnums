using System;
using System.ComponentModel;
using System.Reflection;

namespace PlayingWithEnumsLib
{
	public static class EnumExtensions
	{
		public static string Description(this Enum value)
		{
			return value.ToValueOrString<DescriptionAttribute>();
		}

		/// <summary>
		/// Create custom descriptor attributes based on the Description attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToValueOrString<T>(this Enum value) where T : DescriptionAttribute
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			T[] attributes =
				 (T[])fi.GetCustomAttributes(
				 typeof(T),
				 false);

			if (attributes != null &&
				 attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}
	}
}
