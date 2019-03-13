using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace PlayingWithEnumsLib
{
	public static class EnumExtensions
	{
		public static List<string> ToList(this Type value) 
		{
			var list = (value.IsEnum)? Enum.GetNames(value) : throw new ArgumentException(nameof(value) + " must be an enum value");
			return new List<string>(list);
		}

		public static string Description(this Enum value)
		{
			return value.Description<DescriptionAttribute>();
		}

		/// <summary>
		/// Create custom descriptor attributes based on the Description attribute
		/// </summary>
		/// <typeparam name="ToDesc"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string Description<ToDesc>(this Enum value) where ToDesc : DescriptionAttribute
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			ToDesc[] attributes =
				 (ToDesc[])fi.GetCustomAttributes(
				 typeof(ToDesc),
				 false);

			if (attributes != null &&
				 attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}

		public static T? Parse<T>(this string value, bool ignoreCase = false) where T : struct
		{
			var match = Enum.TryParse<T>(value, ignoreCase, out var En);
			return (match ? (T?)En : null);
		}
		public static T? Parse<T, D>(this string value, bool ignoreCase = false)
								where T : struct
								where D : DescriptionAttribute
		{
			FieldInfo[] fis = typeof(T).GetFields();

			foreach (var fi in fis)
			{
				var enumName = fi.Name;

				D[] attributes = (D[])fi.GetCustomAttributes( typeof(D), false);
				if (attributes != null && attributes.Length > 0)
				{
					foreach (var attr in attributes)
					{
						if (Compare(value, attr.Description, ignoreCase))
						{
							return (T?) enumName.Parse<T>(ignoreCase);
						}
					}
				}

				if (Compare(value, enumName, ignoreCase))
				{
					return (T?) enumName.Parse<T>(ignoreCase);
				}
			}

			return null;
		}

		private static bool Compare(string value1, string value2, bool ignoreCase)
		{
			return (ignoreCase) ? value1.ToUpper() == value2.ToUpper() : value1 == value2;
		}
	}
}
