using System;
using System.Reflection;

namespace EnumTests
{
	[AttributeUsage(AttributeTargets.Field)]
	public class CustomAttribute : Attribute
	{
		private string _name;
		public CustomAttribute(string name)
		{
			this._name = name;
		}

		public enum EnumTest
		{
			None,
			[CustomAttribute("(")] Left,
			[CustomAttribute(")")] Right,
		}

		public static class EnumExtensions
		{
			public static string ToDescription(Type tp, string name)
			{
				MemberInfo[] mi = tp.GetMember(name);
				if (mi != null && mi.Length > 0)
				{
					CustomAttribute attr = Attribute.GetCustomAttribute(mi[0],
						 typeof(CustomAttribute)) as CustomAttribute;
					if (attr != null)
					{
						return attr._name;
					}
				}
				return null;
			}
			public static string Get(object enm)
			{
				if (enm != null)
				{
					MemberInfo[] mi = enm.GetType().GetMember(enm.ToString());
					if (mi != null && mi.Length > 0)
					{
						CustomAttribute attr = Attribute.GetCustomAttribute(mi[0],
							 typeof(CustomAttribute)) as CustomAttribute;
						if (attr != null)
						{
							return attr._name;
						}
					}
				}
				return null;
			}
		}
	}
}
