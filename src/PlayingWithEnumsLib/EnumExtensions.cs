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

		public static T? Parse<T>(this string value) where T : struct
		{
			var match = Enum.TryParse<T>(value, out var En);
			return (match ? (T?)En : null);
		}
		public static T? Parse<T, D>(this string value)
								where T : struct
								where D : DescriptionAttribute
		{
			FieldInfo[] fis = typeof(T).GetFields();

			foreach (var fi in fis)
			{
				D[] attributes = (D[])fi.GetCustomAttributes( typeof(D), false);
				if (attributes != null && attributes.Length > 0)
				{
					foreach (var attr in attributes)
					{
						if (value == attr.Description)
						{
							var EnumName = fi.Name;
							return EnumName.Parse<T>();
						}
					}
				}
			}

			return null;
		}
	}
}
